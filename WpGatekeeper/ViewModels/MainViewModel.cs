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
        private ObservableCollection<Door> _doors;
        private ContactService _service;

        // Parameterless contructor used for designtime contruction
        public MainViewModel()
        {
            _doors = new ObservableCollection<Door>();
            _doors.CollectionChanged += (s, e) => { NotifyPropertyChanged("Doors"); };
        }

        // Parametered contructor used for runtime construction
        public MainViewModel(ContactService service)
            : this()
        {
            _service = service;
            _service.GetContacts((list) =>
            {
                foreach (Door contact in list)
                {
                    _doors.Add(contact);
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

        public ObservableCollection<Door> Doors
        {
            get
            {
                return _doors;
            }

            private set
            {
                if (_doors != value)
                {
                    _doors = value;
                    NotifyPropertyChanged("Doors");
                }
            }
        }

        #endregion
    }
}
