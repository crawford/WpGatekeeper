using System.Collections.Generic;
using WpGatekeeper.Models;
using System;

namespace WpGatekeeper.Data
{
    public class ContactService
    {
        // Dummy call to an online service
        public void GetContacts(Action<List<Contact>> callback)
        {
            List<Contact> contacts = new List<Contact>();

            contacts.Add(new Contact() { Name = "Runtime 1", PhoneNumber = 1231111111 });
            contacts.Add(new Contact() { Name = "Runtime 2", PhoneNumber = 1232222222 });
            contacts.Add(new Contact() { Name = "Runtime 3", PhoneNumber = 1233333333 });

            callback(contacts);
        }
    }
}
