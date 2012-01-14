using System.ComponentModel;
using WpGatekeeper.Models;
using System.Collections.ObjectModel;
using WpGatekeeper.Data;
using System.Collections.Generic;
using System.Windows;

namespace WpGatekeeper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Door> _doors;
        private GatekeeperService _service;

        // Parameterless contructor used for designtime contruction
        public MainViewModel()
        {
            _doors = new ObservableCollection<Door>();
            _doors.CollectionChanged += (s, e) => { NotifyPropertyChanged("Doors"); };
        }

        // Parametered contructor used for runtime construction
        public MainViewModel(GatekeeperService service)
        {
            _service = service;
            UpdateDoors();
        }

        public void PopDoor(Door door) {
            _service.PopDoor(door, (response) =>
            {
                if (!response.Success)
                {
                    System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        MessageBox.Show(response.Error);
                    });
                }
            });
        }

        public void UpdateDoors()
        {
            _service.FetchDoorStates((list) =>
            {
                _doors = new ObservableCollection<Door>(list);
                System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    NotifyPropertyChanged("Doors");
                });
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
