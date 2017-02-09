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
    public sealed partial class OrderPage : Page
    {
        private string _location;
        private string _adult;
        private string _child;
        private string _luxary;
        private string _flightClass;
        private int _flightClassNo;
        private int _luxaryNo;
        private int _adultNo;
        private int _adultPrice;
        private int _childNo;
        private int _childPrice;
        private int _flightPrice;
        private int _nightNo;
        private int _cost;
        private int _flightCost;
        private int _hotelCost;
        private int _nosbooked = 0;
        private int _totalpay = 0;

        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _location = selected.Text;

            if (_location == "Australia")
            {
                _adultPrice = 50;
                _childPrice = 25;
                _flightPrice = 1800;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "Czech")
            {
                _adultPrice = 25;
                _childPrice = 00;
                _flightPrice = 500;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "Italy")
            {
                _adultPrice = 30;
                _childPrice = 10;
                _flightPrice = 500;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "Japan")
            {
                _adultPrice = 125;
                _childPrice = 75;
                _flightPrice = 1600;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "Spain")
            {
                _adultPrice = 50;
                _childPrice = 10;
                _flightPrice = 500;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "Turkey")
            {
                _adultPrice = 25;
                _childPrice = 00;
                _flightPrice = 1000;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "UK")
            {
                _adultPrice = 100;
                _childPrice = 25;
                _flightPrice = 400;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else if (_location == "USA")
            {
                _adultPrice = 70;
                _childPrice = 20;
                _flightPrice = 150;
                displayResult();
                ErrorTextBlock.Text = " ";
            }

            else
            {
                displayError();
            }
                       
        }

        

        private void Adult_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _adult = selected.Text;

            if(_adult != "00")
            {
                _adultNo = (Int32.Parse(_adult));
                displayResult();
                ErrorTextBlock.Text = " ";
            }
            else
            {
                displayError();
            }
            
        }

        private void Child_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _child = selected.Text;
            _childNo = (Int32.Parse(_child));
            displayResult();
            ErrorTextBlock.Text = " ";
        }

        private void Luxary_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _luxary = selected.Text;

            if(_luxary != "00")
            {
                _luxaryNo = Int32.Parse(_luxary);
                displayResult();
                ErrorTextBlock.Text = " ";
            }
            else
            {
                displayError();
            }
        }

        private void Flight_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _flightClass = selected.Text;

            if (_flightClass == "Economy")
            {
                _flightClassNo = 1;
                displayResult();
                ErrorTextBlock.Text = " ";
            }
            else if (_flightClass == "Premium")
            {
                _flightClassNo = 2;
                displayResult();
                ErrorTextBlock.Text = " ";
            }
            else if (_flightClass == "Business")
            {
                _flightClassNo = 3;
                displayResult();
                ErrorTextBlock.Text = " ";
            }
            else if (_flightClass == "First")
            {
                _flightClassNo = 4;
                displayResult();
                ErrorTextBlock.Text = " ";
            }
        }

        private void PickDate_Click(object sender, RoutedEventArgs e)
        {
            if ((StartDate.Date != null) && (EndDate.Date != null))
            {
                calculateNights();
                displayResult();
                ErrorTextBlock.Text = " ";
                showButton();       
            }
            else
            {
                displayError();
            }
            
        }

        private void calculateNights()
        {
            if (EndDate.Date > StartDate.Date)
            {
                DateTime outdate = EndDate.Date.Value.Date;
                DateTime indate = StartDate.Date.Value.Date;
                TimeSpan ts = outdate - indate;
                _nightNo = ts.Days;
            }
            else
            {
                DateTime indate = EndDate.Date.Value.Date;
                DateTime outdate = StartDate.Date.Value.Date;
                TimeSpan ts = outdate - indate;
                _nightNo = ts.Days;
            }                                    
       }

        private void showButton()
        {
            PayButton.Visibility = Visibility.Visible;
        }

        private void displayResult()
        {
            ResultTextBlock.Text = "Location : " + _location;
            ResultTextBlock.Text += "\nNumber of Adults : " + _adult;
            ResultTextBlock.Text += "\nNumber of Children : " + _child;
            ResultTextBlock.Text += "\nLuxary Level : " + _luxary;
            ResultTextBlock.Text += "\nFlight Class : " + _flightClass;
            ResultTextBlock.Text += "\nNumber of Nights : " + _nightNo;

            _flightCost = (_adultNo + _childNo) * _flightPrice * _flightClassNo;
            _hotelCost = ((_adultNo * _adultPrice) + (_childNo * _childPrice)) * _nightNo*_luxaryNo;
            _cost = _hotelCost + _flightCost;
            
            ResultTextBlock.Text += "\nPrice : Flight => $"+_flightCost+".00\n\tHotel => $"+_hotelCost+"\nTotal Price for this destination : $" + _cost + ".00";
        }

        private void displayError()
        {
            if(_location == "None")
            {
                ErrorTextBlock.Text = "Must select a location for booking a tour";
                return;
            }

            if (_adult == "00")
            {
                ErrorTextBlock.Text = "At least 1 Adult needed for a tour";
                return;
            }

            if (_luxary == "00")
            {
                ErrorTextBlock.Text = "You must select a luxary level";
                return;
            }

            if ((StartDate.Date == null) || (EndDate.Date == null))
            {
                ErrorTextBlock.Text = "Dont forget to checkout your travel dates!";
            }

            else
            {
                ErrorTextBlock.Text = "";
                return;
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            _nosbooked++;
            _totalpay = _totalpay + _cost;
            ResultTextBlock.Text = " ";
            ConfirmationBox.Text = "THANK YOU\n\nWe received your payment.\nYou booked "+_nosbooked+" tours.\nTotal payment = $"+_totalpay+".00\nOur representative will contact you shortly.";
            payclickVisibility();
            
        }

        private void payclickVisibility()
        {
            BuyAnother.Visibility = Visibility.Visible;
            PayButton.Visibility = Visibility.Collapsed;
            LocationButton.Visibility = Visibility.Collapsed;
            AdultsButton.Visibility = Visibility.Collapsed;
            ChildrenButton.Visibility = Visibility.Collapsed;
            LuxaryButton.Visibility = Visibility.Collapsed;
            FlightButton.Visibility = Visibility.Collapsed;
            StartDate.Visibility = Visibility.Collapsed;
            EndDate.Visibility = Visibility.Collapsed;
            PickDate.Visibility = Visibility.Collapsed;
        }

        private void BuyAnother_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = " ";
            ErrorTextBlock.Text = " ";
            ConfirmationBox.Text = " ";
            buyanotherVisibility();
        }

        private void buyanotherVisibility()
        {
            BuyAnother.Visibility = Visibility.Collapsed;
            LocationButton.Visibility = Visibility.Visible;
            AdultsButton.Visibility = Visibility.Visible;
            ChildrenButton.Visibility = Visibility.Visible;
            LuxaryButton.Visibility = Visibility.Visible;
            FlightButton.Visibility = Visibility.Visible;
            StartDate.Visibility = Visibility.Visible;
            EndDate.Visibility = Visibility.Visible;
            PickDate.Visibility = Visibility.Visible;
        }
    }
}
