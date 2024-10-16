using ContactManagementApp.Models;

public interface IContactService{
    List<Contact> Get();
    Contact CreateContact(Contact contact);
    Contact UpdateContact(int id, Contact updatedContact);
    bool DeleteContact(int id);
    Contact GetContactById(int id);
}