using System;
using System.ComponentModel;
using System.Windows.Navigation;

namespace WpGatekeeper.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _username;
        private string _password;

        public SettingsViewModel()
        {
            Username = App.SettingsService.Username;
            Password = App.SettingsService.Password;
        }

        public void ShowView(NavigationService navigation)
        {
            navigation.Navigate(new Uri("/Views/SettingsPage.xaml", UriKind.Relative));
        }

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Getters and Setters

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    NotifyPropertyChanged("Username");
                    App.SettingsService.Username = _username;
                    App.GatekeeperService.SetUsernamePassword(_username, _password);
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    NotifyPropertyChanged("Password");
                    App.SettingsService.Password = _password;
                    App.GatekeeperService.SetUsernamePassword(_username, _password);
                }
            }
        }

        #endregion
    }
}
