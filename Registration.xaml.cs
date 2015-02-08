using BloodDonateShared;
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
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BloodDonate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {
        public Registration()
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


        async private void _Submit(object sender, RoutedEventArgs e)
        {
           
           
            var position = "";
           if(!(_RegName.Text==""||_RegEmail.Text==""||_RegPhone.Text==""))
           {
               BBDb data = new BBDb
               {
                   _name = _RegName.Text,
                   _dob = _RegDOB.Date.Date,
                   _phone = _RegPhone.Text,
                   _sex = _RegSex.SelectedItem.ToString(),
                   _bloodgroup = _RegGroup.SelectedItem.ToString(),
                   email = _RegEmail.Text,
                   _location = _Regloc.SelectedItem.ToString(),
                   _position = position.ToString()
               };
               Progress.IsActive = true;
               functions.Insertdb(data);
               Progress.IsActive = false;
               MessageDialog msg = new MessageDialog("Data uploaded successfully");
               await msg.ShowAsync();
           }
           else
           {
               MessageDialog messageDialog = new MessageDialog("Enter Complete Data");
               await messageDialog.ShowAsync();
           }
          
          

           }
    }
}
