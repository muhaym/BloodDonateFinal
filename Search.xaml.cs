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
using BloodDonateShared;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BloodDonate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search : Page
    {
        public Search()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                    Windows.Phone.UI.Input.HardwareButtons.BackPressed += BackButtonPress;
        }

        private void BackButtonPress(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            e.Handled = true;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= BackButtonPress;
            Frame.Navigate(typeof(MainPage));
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            Progress.IsActive = true;
            string location= _Location.SelectedItem.ToString();
            string group=_BloodGroup.SelectedItem.ToString();
            //MessageDialog messageDialog = new MessageDialog(location+" "+group);
            //await messageDialog.ShowAsync();
            List<BBDb> searchResults = await functions.Searchdb(group, location);
            if (!(searchResults == null))
            {
                Progress.IsActive = false;
                SearchResult.ItemsSource = searchResults;
            }
            else
            {
                MessageDialog msg = new MessageDialog("No data found according to yoru query");
                await msg.ShowAsync();
                
            }


        }

      

        private void MyClick(object sender, TappedRoutedEventArgs e)
        {
            var data = sender as Image;
            var cellnumber = data.Tag.ToString();
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(cellnumber, "Donor");
        }
    }
}
