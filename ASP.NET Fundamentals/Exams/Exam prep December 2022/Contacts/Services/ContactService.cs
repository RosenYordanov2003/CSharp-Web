namespace Contacts.Services
{
    using Contracts;
    using Data;
    using Contacts.Models.Contact;
    using Microsoft.EntityFrameworkCore;
    using Contacts.Data.Models;

    public class ContactService : IContacService
    {
        private readonly ContactsDbContext contactsDbContext;

        public ContactService(ContactsDbContext contactsDbContext)
        {
            this.contactsDbContext = contactsDbContext;
        }

        public async Task<IEnumerable<ContactAllViewModel>> GetAllAsync()
        {
            IEnumerable<ContactAllViewModel> allContacts = await contactsDbContext.Contacts
                 .Select(c => new ContactAllViewModel()
                 {
                     ContactId = c.Id,
                     FirstName = c.FirstName,
                     LastName = c.LastName,
                     Email = c.Email,
                     PhoneNumber = c.PhoneNumber,
                     Address = c.Address ?? "",
                     Website = c.Website
                 }).ToArrayAsync();
            return allContacts;
        }

        public async Task<IEnumerable<ContactAllViewModel>> GetUserContactTeamsAsync(string userId)
        {
            IEnumerable<ContactAllViewModel> allContacts = await contactsDbContext.ApplicationUserContacts
                .Where(uc => uc.ApplicationUserId == userId)
                .Select(uc => new ContactAllViewModel()
                {
                    ContactId = uc.ContactId,
                    FirstName = uc.Contact.FirstName,
                    LastName = uc.Contact.LastName,
                    Email = uc.Contact.Email,
                    PhoneNumber = uc.Contact.PhoneNumber,
                    Address = uc.Contact.Address ?? "",
                    Website = uc.Contact.Website
                }).ToArrayAsync();
            return allContacts;
        }
        public async Task CreateContactAsync(ContactAddViewModel contact)
        {
            Contact contactToCreate = new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Website = contact.Website,
                Address = contact.Address
            };
            await contactsDbContext.Contacts.AddAsync(contactToCreate);
            await contactsDbContext.SaveChangesAsync();
        }

        public async Task AddContactToUserAsync(int contactId, string userId)
        {
            if (await IsExist(contactId, userId))
            {
                throw new InvalidOperationException("Contact already exist's");
            }
            else
            {
                ApplicationUserContact userContact = new ApplicationUserContact()
                {
                    ApplicationUserId = userId,
                    ContactId = contactId
                };
                await contactsDbContext.ApplicationUserContacts.AddAsync(userContact);
                await contactsDbContext.SaveChangesAsync();
            }
        }
        public async Task RemoveContactFromUserAsync(int contactId, string userId)
        {
            if (!await IsExist(contactId, userId))
            {
                throw new InvalidOperationException("Not existing contact id");
            }
            else
            {
                ApplicationUserContact userContact = await contactsDbContext.ApplicationUserContacts
                    .FirstAsync(uc => uc.ApplicationUserId == userId && uc.ContactId == contactId);
                contactsDbContext.Remove(userContact);
                await contactsDbContext.SaveChangesAsync();
            }
        }
        public async Task<ContactAddViewModel> FindContactToEdit(int contactId)
        {
            Contact contactToFind = await contactsDbContext.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);
            if (contactToFind != null)
            {
                return new ContactAddViewModel()
                {
                    FirstName = contactToFind.FirstName,
                    LastName = contactToFind.LastName,
                    Email = contactToFind.Email,
                    Address = contactToFind.Email,
                    PhoneNumber = contactToFind.PhoneNumber,
                    Website = contactToFind.Website
                };
            }
            throw new InvalidOperationException("Invalid contact id");
        }
        public async Task EditContactAsync(int contactId, ContactAddViewModel edditedContact)
        {
            Contact contactToEdit = await contactsDbContext.Contacts.FirstAsync(c => c.Id == contactId);
            contactToEdit.PhoneNumber = edditedContact.PhoneNumber;
            contactToEdit.LastName = edditedContact.LastName;
            contactToEdit.FirstName = edditedContact.FirstName;
            contactToEdit.Email = edditedContact.Email;
            contactToEdit.Address = edditedContact.Address;
            contactToEdit.Website = edditedContact.Website;
            await contactsDbContext.SaveChangesAsync();
        }
        private async Task<bool> IsExist(int contactId, string userId) => await contactsDbContext.ApplicationUserContacts
            .AnyAsync(uc => uc.ContactId == contactId && uc.ApplicationUserId == userId);


    }
}
