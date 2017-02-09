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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FakeTravel.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BackupLogin : Page
    {
        public BackupLogin()
        {
            this.InitializeComponent();
        }

        private void BackupLoginbutton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainContent));
        }

        private void control_name_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if(args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if(sender.Text.Length > 1)
                {
                    sender.ItemsSource = this.GetSuggestions(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new string[] { "Your name is not registered" };
                    BackupLoginbutton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private string[] suggestions = new string[] { "Louise", "Devraj", "sampleUser", "newUser", "louise", "devraj" };
        private string[] GetSuggestions(string text)
        {
            string[] result = null;
            result = suggestions.Where(x => x.StartsWith(text)).ToArray();
            BackupLoginbutton.Visibility = Visibility.Visible;
            return result;
        }
    }
}
