namespace Contacts.Contracts
{
    using Models.Contact;
    public interface IContacService
    {
        Task<IEnumerable<ContactAllViewModel>> GetAllAsync();
        Task<IEnumerable<ContactAllViewModel>> GetUserContactTeamsAsync(string userId);
        Task CreateContactAsync(ContactAddViewModel contact);
        Task AddContactToUserAsync(int contactId, string userId);
        Task RemoveContactFromUserAsync(int contactId, string userId);
        Task<ContactAddViewModel> FindContactToEdit(int contactId);
        Task EditContactAsync(int contactId, ContactAddViewModel edditedContact);
    }
}
