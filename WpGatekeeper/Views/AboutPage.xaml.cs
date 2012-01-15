using System;
using System.Windows;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;

namespace WpGatekeeper
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(@"https://github.com/crawford/WpGatekeeper/issues");
            task.Show();
        }
    }
}
