using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QuranAppTest.Resources;
using System.Windows.Threading;
using System.Windows.Documents;
using System.Windows.Media;

namespace QuranAppTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool _isPlaying = false;
        DispatcherTimer _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        int _timerLastSec = 0;
        Run _lastRun = null;

        SolidColorBrush _red = new SolidColorBrush(Colors.Red);
        SolidColorBrush _black = new SolidColorBrush(Colors.Black);

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            _timer.Tick += _timer_Tick;
            mp3.MediaEnded += mp3_MediaEnded;
        }

        void mp3_MediaEnded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _timerLastSec = 0;
            _isPlaying = false;
            _lastRun.Foreground = _black;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            ++_timerLastSec;

            switch (_timerLastSec)
            {
                case 6:
                    a1.Foreground = _red;
                    _lastRun = a1;
                    break;

                case 12:
                    _lastRun.Foreground = _black;
                    a2.Foreground = _red;
                    _lastRun = a2;
                    break;

                case 18:
                    _lastRun.Foreground = _black;
                    a3.Foreground = _red;
                    _lastRun = a3;
                    break;

                case 22:
                    _lastRun.Foreground = _black;
                    a4.Foreground = _red;
                    _lastRun = a4;
                    break;

                case 27:
                    _lastRun.Foreground = _black;
                    a5.Foreground = _red;
                    _lastRun = a5;
                    break;

                case 33:
                    _lastRun.Foreground = _black;
                    a6.Foreground = _red;
                    _lastRun = a6;
                    break;

                case 38:
                    _lastRun.Foreground = _black;
                    a7.Foreground = _red;
                    _lastRun = a7;
                    break;
            }
        }

        private void LayoutRoot_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            _isPlaying = !_isPlaying;
            if (!_isPlaying)
            {
                // Pause
                _timer.Stop();
                mp3.Pause();
                return;
            }

            _timer.Start();
            mp3.Play();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}