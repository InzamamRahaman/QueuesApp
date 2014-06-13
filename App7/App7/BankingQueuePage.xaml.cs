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
    public sealed partial class BankingQueuePage : Page
    {

        private BankingQueueListing listing;
        private DispatcherTimer countDownTimer;
        private int selected = -1;
        private BankingQueueViewModel selectedModel = null;

        public BankingQueuePage()
        {
            listing = BankingQueueListing.GetInstance();
            this.InitializeComponent();
            this.ListView.ItemsSource = listing.Queues;
            countDownTimer = new DispatcherTimer();
            countDownTimer.Interval = new TimeSpan(0, 1, 0);
            countDownTimer.Tick += handleCountDown;
            countDownTimer.Start();
            //this.ListView.IsItemClickEnabled = true;
            //this.ListView.ItemClick += ListView_ItemClick;
            this.Swap_Button.IsEnabled = false;
            this.ListView.Tapped += ListView_Tapped;
            //this.ListView.SelectionChanged += ListView_SelectionChanged;
            //this.ListView.SelectionMode = ListViewSelectionMode.Single;
            
        }

        void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BankingQueueViewModel key = this.ListView.SelectedItem as BankingQueueViewModel;

           
            if (selectedModel == null)
            {
                selectedModel = key;
                key.Color = "Green";
                this.Swap_Button.IsEnabled = true;
            
            }
            else if(selectedModel.Equals(key))
            {
                this.Swap_Button.IsEnabled = false;
                selectedModel.Color = "White";
                selectedModel = null;

            }
            else if (!selectedModel.Equals(key))
            {
                selectedModel.Color = "White";
                selectedModel = key;
                key.Color = "Green";
            }
        }

        void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BankingQueueViewModel key = this.ListView.SelectedItem as BankingQueueViewModel;


            if (selectedModel == null)
            {
                selectedModel = key;
                key.Color = "Green";
                this.Swap_Button.IsEnabled = true;

            }
            else if (selectedModel.Equals(key))
            {
                this.Swap_Button.IsEnabled = false;
                selectedModel.Color = "White";
                selectedModel = null;

            }
            else if (!selectedModel.Equals(key))
            {
                selectedModel.Color = "White";
                selectedModel = key;
                key.Color = "Green";
            }
        }

        void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            BankingQueueViewModel key = this.ListView.SelectedItem as BankingQueueViewModel;


            if (selectedModel == null)
            {
                selectedModel = key;
                key.Color = "Green";
                this.Swap_Button.IsEnabled = true;

            }
            else if (selectedModel.Equals(key))
            {
                this.Swap_Button.IsEnabled = false;
                selectedModel.Color = "White";
                selectedModel = null;

            }
            else if (!selectedModel.Equals(key))
            {
                selectedModel.Color = "White";
                selectedModel = key;
                key.Color = "Green";
            }
        }


        private void handleCountDown(object o, object e)
        {
            listing.DecrementAll();
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
            this.Frame.Navigate(typeof(CollectionQueuePage));
        }

        private void Swap_Button_Click(object sender, RoutedEventArgs e)
        {
            if(selectedModel != null)
            {
                listing.UseSwap(selectedModel.ID);
                selectedModel.Color = "White";
                selectedModel = null;
                this.Swap_Button.IsEnabled = false;
            }
        }
    }
}
