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
using FakeTravel.Models;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FakeTravel.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainContent : Page
    {
        private ObservableCollection<NewsItem> NewsItems;

        public MainContent()
        {
            this.InitializeComponent();
            NewsItems = new ObservableCollection<NewsItem>();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ListBox_SeletionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Europe.IsSelected)
            {
                NewsManager.GetNews("Europe", NewsItems);
                TitleTextBlock.Text = "European Destinations";
            }
            else if (Other.IsSelected)
            {
                NewsManager.GetNews("Other", NewsItems);
                TitleTextBlock.Text = "Non-European Destinations";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Europe.IsSelected = true;
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrderPage));
        }
    }
}
