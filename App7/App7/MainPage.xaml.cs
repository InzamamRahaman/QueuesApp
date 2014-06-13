using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App7
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }


        private bool Authenticate_Users(string email, string password)
        {
            return true;
        }

        private bool Register_Users(string email, string pass1, string pass2,
            string fname, string lname)
        {
            if(pass1.Equals(pass2))
            {
                // DO Registration stuff here
                return true;
            }

            return false;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string email = this.EmailBox.Text;
            string password = this.PasswordBox.Password;
            bool passed = Authenticate_Users(email, password);
            
            if(passed == true)
            {
                this.Frame.Navigate(typeof(BankingQueuePage));
            }

        }

        private void RegisterFlyoutButton_Click(object sender, RoutedEventArgs e)
        {
            string email = this.EmailFlyoutBox.Text;
            string pass1 = this.PasswordFlyoutBox.Password;
            string pass2 = this.RetypePasswordFlyoutBox.Password;
            string fname = this.FirstNameFlyoutBox.Text;
            string lname = this.LastNameFlyoutBox.Text;

            if(!pass1.Equals(pass2))
            {
                this.InformationFlyoutBox.Text = "Your passwords do not match.";
            }

            if(Register_Users(email, pass1, pass2, fname, lname))
            {
                this.InformationFlyoutBox.Text = "You have been successfully registered :)";
            }
            else
            {
                this.InformationFlyoutBox.Text = "We are sorry, but there\n was an error";
            }
        }
    }
}
