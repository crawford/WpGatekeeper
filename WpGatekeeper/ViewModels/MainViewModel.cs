using System.ComponentModel;
using WpGatekeeper.Models;
using System.Collections.ObjectModel;
using WpGatekeeper.Data;
using System.Collections.Generic;

namespace WpGatekeeper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Contact> _contacts;
        private ContactService _service;

        // Parameterless contructor used for designtime contruction
        public MainViewModel()
        {
            _contacts = new ObservableCollection<Contact>();
            _contacts.CollectionChanged += (s, e) => { NotifyPropertyChanged("Contacts"); };
        }

        // Parametered contructor used for runtime construction
        public MainViewModel(ContactService service)
            : this()
        {
            _service = service;
            _service.GetContacts((list) =>
            {
                foreach (Contact contact in list)
                {
                    _contacts.Add(contact);
                }
            });
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Getters and Setters

        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }

            private set
            {
                if (_contacts != value)
                {
                    _contacts = value;
                    NotifyPropertyChanged("Contacts");
                }
            }
        }

        #endregion
    }
}
