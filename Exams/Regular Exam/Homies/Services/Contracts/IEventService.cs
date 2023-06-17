namespace Homies.Services.Contracts
{
    using Homies.Models.Event;
    public interface IEventService
    {
        public Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync();
        public Task<IEnumerable<EventAllViewModel>> GetUserEventsAsync(string userId);
        public Task AddEventAsync(string userId, EventAddViewModel eventAddViewModel);
        public Task<EventViewModel> FindEventByIdAsync(int id);
        public Task LeaveEventAsync(int eventId, string userId);
        public Task JoinEventToUserAsync(int eventId, string userId);
        public Task<EventAddViewModel> GetEventToEditAsync(int id);
        public Task EditEventAsync(int eventId, EventAddViewModel eventAddViewModel);
    }
}
