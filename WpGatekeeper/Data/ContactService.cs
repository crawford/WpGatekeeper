using System.Collections.Generic;
using WpGatekeeper.Models;
using System;

namespace WpGatekeeper.Data
{
    public class ContactService
    {
        // Dummy call to an online service
        public void GetContacts(Action<List<Door>> callback)
        {
            List<Door> contacts = new List<Door>();

            contacts.Add(new Door() { Name = "Runtime 1", Status = Door.LockStatus.LOCKED});
            contacts.Add(new Door() { Name = "Runtime 2", Status = Door.LockStatus.UNKNOWN });
            contacts.Add(new Door() { Name = "Runtime 3", Status = Door.LockStatus.UNLOCKED });

            callback(contacts);
        }
    }
}
