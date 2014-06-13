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
using App7.ViewModels;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App7
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CollectionQueuePage : Page
    {

        private BankingQueueListing listings;
        private DispatcherTimer timer;

        public CollectionQueuePage()
        {
            listings = BankingQueueListing.GetInstance();
            this.InitializeComponent();
            this.ListView.ItemsSource = listings.Queues;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Tick += handleCountDown;
            timer.Start();
        }

        private void handleCountDown(object sender, object e)
        {
            listings.DecrementAll();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void MonitorButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BankingQueuePage));
        }
    }
}
