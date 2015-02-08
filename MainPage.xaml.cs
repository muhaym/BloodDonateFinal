using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BloodDonateShared;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace BloodDonate
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

        private void search_Click(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
        private void donate_Click(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Registration));
        }
        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            //predefine Recipient
            EmailRecipient sendTo = new EmailRecipient()
            {
                Address = "muhaymin@muhaym.in"
            };

            //generate mail object
            EmailMessage mail = new EmailMessage();
            mail.Subject = "Feedback for Blood Donate";
            mail.Body = "Write your feedback here!";

            //add recipients to the mail object
            mail.To.Add(sendTo);
            //mail.Bcc.Add(sendTo);
            //mail.CC.Add(sendTo);

            //open the share contract with Mail only:
            await EmailManager.ShowComposeNewEmailAsync(mail);
        }





        private async void about(object sender, RoutedEventArgs e)
        {
            MessageDialog messageDialog = new MessageDialog("About Blood Donate!\n\nBring a life back to power. Make blood donation your responsibility.");
            await messageDialog.ShowAsync();
        }
    }
}
