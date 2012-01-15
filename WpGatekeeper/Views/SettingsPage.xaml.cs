using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace WpGatekeeper
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        // When page is navigated to, set the data context 
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (DataContext == null)
                DataContext = App.SettingsViewModel;
        }
    }
}
