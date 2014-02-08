using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework.Input.Touch;

namespace BreakIt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           
            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            //detect is accelerometer supported by the phone
            if (!Accelerometer.IsSupported)
            {
                btnPlay.IsEnabled = false;
                //show the warning message
                txtTotal.Text = "Can't continue: No accelerometer!";
                txtTotal.Foreground = new SolidColorBrush(Colors.Red);
                txtTotal.FontSize = 30;

            }
            else
            {

                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                //get personal settings
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Amount"))
                {
                    btnPlay.Content = "Start Over";
                    if (!( Convert.ToInt16(IsolatedStorageSettings.ApplicationSettings["Amount"].ToString()) > 112))
                    {
                        btnContinue.IsEnabled = true;
                    }
                   
                }

                if (IsolatedStorageSettings.ApplicationSettings.Contains("Level"))
                {
                    txtTotal.Text = "Current Level: level " +
                     IsolatedStorageSettings.ApplicationSettings["Level"] as string+" !";

                }
                else
                {
                    txtTotal.Text = "";
                }
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (btnPlay.Content.ToString() == "Play")
            {
                btnContinue.IsEnabled = true;
                btnPlay.Content ="Start Over";
                this.NavigationService.Navigate(new Uri("/PlayPage.xaml", UriKind.Relative));
            }
            if (btnPlay.Content.ToString() == "Start Over")
            {
                btnContinue.IsEnabled = false;
                txtTotal.Text = "";
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Amount"))
                {
                    IsolatedStorageSettings.ApplicationSettings.Remove("Amount");
                }
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Level"))
                {
                    IsolatedStorageSettings.ApplicationSettings.Remove("Level");
                }
                btnPlay.Content = "Play";
            }
           
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PlayPage.xaml", UriKind.Relative));
        }
    }
}