using System;
using System.Windows.Navigation;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using WpGatekeeper.Models;

namespace WpGatekeeper.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // When page is navigated to, set the data context 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (DataContext == null)
                DataContext = App.MainViewModel;
        }

        private void Pop_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = sender as Button;
            App.MainViewModel.PopDoor(button.DataContext as Door);
        }

        private void abbSettings_Click(object sender, System.EventArgs e)
        {
            App.SettingsViewModel.ShowView(NavigationService);
        }

        private void abbRefresh_Click(object sender, System.EventArgs e)
        {
            App.MainViewModel.UpdateDoors();
        }

        private void abmAbout_Click(object sender, System.EventArgs e)
        {
            NavigationService.Navigate(new Uri("/views/AboutPage.xaml", UriKind.Relative));
        }
    }
}
