using ContactManagementApp.Models;
using Newtonsoft.Json;
using System.IO;

namespace ContactManagementApp.Services
{
    public class ContactService
    {
        private readonly string filePath = "contacts.json"; // Adjust path as needed

        // Read contacts from the JSON file
        public List<Contact> Get()
        {
            if (!File.Exists(filePath))
            {
                return new List<Contact>();
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Contact>>(jsonData) ?? new List<Contact>();
        }

        // Save Contacts to the JSON file
        private void Save(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        // Create a new Contact
        public Contact CreateContact(Contact contact)
        {
            var Contacts = Get();

            // Simulate auto-incrementing Id
            contact.Id = Contacts.Count > 0 ? Contacts.Max(u => u.Id) + 1 : 1;
            Contacts.Add(contact);

            Save(Contacts);
            return contact;
        }

        // Update an existing Contact
        public Contact UpdateContact(int id, Contact updatedContact)
        {
            var Contacts = Get();
            var existingContact = Contacts.FirstOrDefault(u => u.Id == id);
            if (existingContact == null) return null;

            existingContact.FirstName = updatedContact.FirstName;
            existingContact.LastName = updatedContact.LastName;
            existingContact.Email = updatedContact.Email;

            Save(Contacts);
            return existingContact;
        }

        // Delete a Contact
        public bool DeleteContact(int id)
        {
            var Contacts = Get();
            var ContactToDelete = Contacts.FirstOrDefault(u => u.Id == id);
            if (ContactToDelete == null) return false;

            Contacts.Remove(ContactToDelete);
            Save(Contacts);
            return true;
        }

        // Get a Contact by Id
        public Contact GetContactById(int id)
        {
            var Contacts = Get();
            return Contacts.FirstOrDefault(u => u.Id == id);
        }
    }
}
