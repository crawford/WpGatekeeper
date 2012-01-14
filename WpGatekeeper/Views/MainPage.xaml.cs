using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Controls;
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
    }
}
