namespace Homies.Services
{
    using Homies.Data;
    using Homies.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration.UserSecrets;
    using Models.Event;
    using Services.Contracts;
    public class EventService : IEventService
    {
        private readonly HomiesDbContext homiesDbContext;
        public EventService(HomiesDbContext homiesDbContext)
        {
            this.homiesDbContext = homiesDbContext;
        }

        public async Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync()
        {
            IEnumerable<EventAllViewModel> allEvents = await homiesDbContext.Events
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                }).ToListAsync();
            return allEvents;
        }

        public async Task<IEnumerable<EventAllViewModel>> GetUserEventsAsync(string userId)
        {
            IEnumerable<EventAllViewModel> userEvenets = await homiesDbContext.EventsParticipants
                .Where(ev => ev.HelperId == userId)
                .Select(e => new EventAllViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Event.Organiser.UserName,
                    Type = e.Event.Type.Name
                }).ToListAsync();
            return userEvenets;
        }
        public async Task AddEventAsync(string userId, EventAddViewModel eventAddViewModel)
        {
            Event eventToAdd = new Event()
            {
                Name = eventAddViewModel.Name,
                Description = eventAddViewModel.Description,
                OrganiserId = userId,
                Start = eventAddViewModel.Start,
                End = eventAddViewModel.End,
                CreatedOn = DateTime.Now,
                TypeId = eventAddViewModel.TypeId
            };
            await homiesDbContext.Events.AddAsync(eventToAdd);
            await homiesDbContext.SaveChangesAsync();
        }
        public async Task JoinEventToUserAsync(int eventId, string userId)
        {
            if (!homiesDbContext.EventsParticipants.Any(ev => ev.EventId == eventId && ev.HelperId == userId))
            {
                EventParticipant eventParticipant = new EventParticipant()
                {
                    EventId = eventId,
                    HelperId = userId
                };
                await homiesDbContext.EventsParticipants.AddAsync(eventParticipant);
                await homiesDbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Already existing event");
            }
        }

        public async Task<EventViewModel> FindEventByIdAsync(int id)
        {
            EventViewModel eventViewModel = await homiesDbContext.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Description = e.Description,
                    Type = e.Type.Name,
                    Name = e.Name,
                    Organiser = e.Organiser.UserName
                }).FirstOrDefaultAsync(e => e.Id == id);
            return eventViewModel;
        }

        public async Task LeaveEventAsync(int eventId, string userId)
        {
            EventParticipant eventParticipant = await homiesDbContext.EventsParticipants.
                FirstOrDefaultAsync(ev => ev.EventId == eventId && ev.HelperId == userId);
            homiesDbContext.EventsParticipants.Remove(eventParticipant);
            await homiesDbContext.SaveChangesAsync();
        }

        public async Task<EventAddViewModel> GetEventToEditAsync(int id)
        {
            Event eventToGet = await homiesDbContext.Events.FirstAsync(e => e.Id == id);
            EventAddViewModel eventAddViewModel = new EventAddViewModel()
            {
                Description = eventToGet.Description,
                Name = eventToGet.Name,
                End = eventToGet.End,
                Start = eventToGet.Start,
                TypeId = eventToGet.TypeId
            };
            return eventAddViewModel;
        }

        public async Task EditEventAsync(int eventId, EventAddViewModel eventAddViewModel)
        {
            Event eventToEdit = await homiesDbContext.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            if (eventToEdit != null)
            {
                eventToEdit.Description = eventAddViewModel.Description;
                eventToEdit.Name = eventAddViewModel.Name;
                eventToEdit.Start = eventAddViewModel.Start;
                eventToEdit.End = eventAddViewModel.End;
                eventToEdit.TypeId = eventAddViewModel.TypeId;
                await homiesDbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Invalid event id!");
            }
        }
    }
}
