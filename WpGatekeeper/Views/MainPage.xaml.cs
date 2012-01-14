using Microsoft.Phone.Controls;
using System.Windows.Navigation;

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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
