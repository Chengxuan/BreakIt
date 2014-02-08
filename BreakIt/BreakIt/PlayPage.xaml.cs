using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.Input.Touch;
using System.Windows.Threading;
using System.Windows.Input;
using Microsoft.Devices.Sensors;
using System.IO.IsolatedStorage;

namespace BreakIt
{
    public partial class PlayPage : PhoneApplicationPage
    {
        private Boolean isPlaying = false; // define game is playing or pause
        private Double speedX = -5; // horizontal speed of the ball
        private Double speedY = -5; // vertical speed of the ball
        private Double speedBar = 0; // horizontal speed of the bar
        private Int16 rectsAmount = 10; // how many bricks in this level
        private Accelerometer acl = new Accelerometer();
        private Boolean isStarted = false; // determine whether the level has started


        public PlayPage()
        {
            InitializeComponent();

        }

        void LayoutRoot_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

            //get touchPanne gesture
            if (TouchPanel.IsGestureAvailable)
            {
                //read gesture
                GestureSample gs = TouchPanel.ReadGesture();
                switch (gs.GestureType)
                {
                        //tap to pause start or continue
                    case GestureType.Tap:
                        if (isPlaying)
                        {
                            //pause game
                            txtLevelUp.Text = "Paused!";
                            txtLevelUp.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            txtLevelUp.Visibility = System.Windows.Visibility.Collapsed;
                        }
                        isPlaying = !isPlaying;
                        if (!isStarted)
                        {
                            if (rectsAmount == 10)
                            {
                                txtLevelUp.Visibility = System.Windows.Visibility.Collapsed;
                            }
                            // play bar sound if it's the beginning of the level
                            SoundManager.BarSound();
                        }
                        // the level started
                        isStarted = true;
                        break;
                    default:
                        break;
                }

            }

        }

        private void startAcc()
        {
            //seems this function is duplicated, but it's work better than the newer in my game
            acl.ReadingChanged += acl_ReadingChanged;
            //start accelerometre reading
            acl.Start();
           
        }


        void acl_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                //get bar and ball position
                Double ballX = Convert.ToDouble(elsHit.GetValue(Canvas.LeftProperty));
                Double ballY = Convert.ToDouble(elsHit.GetValue(Canvas.TopProperty));
                Double rectX = Convert.ToDouble(rctControl.GetValue(Canvas.LeftProperty));
                Double rectY = Convert.ToDouble(rctControl.GetValue(Canvas.TopProperty));
                if (isPlaying)
                {
                    //ball moving logic here
                    //if ball is inside canvas horizontally
                    if (ballX > 0 && (ballX + elsHit.Width) < cnvMain.ActualWidth)
                    {
                        //can move in x dysh
                        //next move won't cause ball outside
                        if ((ballX + speedX) > 0 && ((ballX + elsHit.Width) + speedX) < cnvMain.ActualWidth)
                        {
                            // continue going
                            ballX += speedX;
                        }
                        else
                        {
                            //will go outside
                            SoundManager.WallSound();
                            //if moving left, set leftproperty to very left of canvas, otherwise set to the very right of canvas
                            ballX = speedX > 0 ? (cnvMain.ActualWidth - elsHit.Width) : 0;
                        }
                    }
                    else
                    {
                        //you will be outside
                        // turn over the direction of ball going 
                        speedX = -speedX;
                        ballX += speedX;
                    }

                    // if ball is inside canvas vertically
                    if (ballY > 0 && ballY < cnvMain.ActualHeight)
                    {
                        //can move in y dysh
                        //next move won't go outside
                        if ((ballY + speedY) > 0 && ((ballY + elsHit.Height) + speedY) < cnvMain.ActualHeight)
                        {
                            //continue going
                            ballY += speedY;
                        }
                        else
                        {
                            //will go outside
                            SoundManager.WallSound();
                            //if moving upwards, set topproperty to very top of canvas, otherwise set to the very bottom of canvas
                            ballY = speedY > 0 ? Convert.ToDouble(cnvMain.ActualHeight) : 0;
                        }
                    }
                    else
                    {
                        if (ballY > 0)
                        {
                            //ball outside from bottom
                            // loose life
                            
                            stopGame();
                            isPlaying = false;
                        }
                        else
                        {
                            //ball outside from the top
                            SoundManager.WallSound();
                            //turn over the direction of ball
                            speedY = -speedY;
                            ballY += speedY;
                        }
                    }
                    //move the ball
                    elsHit.SetValue(Canvas.LeftProperty, ballX);
                    elsHit.SetValue(Canvas.TopProperty, ballY);

                    //if the ball hit the bar
                    if (rectY < ballY + elsHit.Height && rectY + rctControl.Height > ballY + elsHit.Height && rectX < ballX + elsHit.Width && rectX + rctControl.Width > ballX)
                    {
                        //move it above the bar first
                        elsHit.SetValue(Canvas.TopProperty, rectY - elsHit.Height);
                        SoundManager.BarSound();
                        //turn over the ball dirction vertically make it go upwards
                        speedY = -speedY;
                        //if hit by the end of bar in opposite direction should be turn over horizontally as well
                        if (rectX + rctControl.Width * 1 / 3 > ballX + elsHit.Width / 2 && speedX > 0 || rectX + rctControl.Width * 2 / 3 < ballX + elsHit.Width / 2 && speedX < 0)
                        {
                            if (rectX + rctControl.Width * 1 / 4 > ballX + elsHit.Width / 2 && speedX > 0 || rectX + rctControl.Width * 3 / 4 < ballX + elsHit.Width / 2 && speedX < 0)
                            {
                                if (rectX + rctControl.Width * 1 / 6 > ballX + elsHit.Width / 2 && speedX > 0 || rectX + rctControl.Width * 5 / 6 < ballX + elsHit.Width / 2 && speedX < 0)
                                {
                                    if (rectX + rctControl.Width * 1 / 12 > ballX + elsHit.Width / 2 && speedX > 0 || rectX + rctControl.Width * 11 / 12 < ballX + elsHit.Width / 2 && speedX < 0)
                                    {
                                        //if at the very end 1/12 of the bar reflect it by highly inverse speed
                                        speedX = speedX > 0 ? -5 : 5;
                                    }
                                    else
                                    {
                                        //if at the nearly end 1/6 - 1/12 of the bar reflect it by high inverse speed
                                        speedX = speedX > 0 ? -4 : 4;
                                    }
                                }
                                else
                                {
                                    //if at the 1/4 - 1/6 of the bar reflect it by highly inverse speed
                                    speedX = speedX > 0 ? -3 : 3;
                                }
                            }
                            else
                            {
                                //if at the 1/3 - 1/4 of the bar reflect it by highly inverse speed
                                speedX = speedX > 0 ? -2 : 2;
                            }
                        }
                        else
                        {
                            if(speedX<5&&speedX>-5){
                                //greater the speed if the ball haven't touched the about area
                                speedX = speedX > 0 ? ++speedX : --speedX;
                            }
                        }
                


                    }
                    //get the speed from accel, but i don't want the number after dot
                    //so use convert to cut the number
                    Int64 x = Convert.ToInt64(e.Y * 50);
                    //determine the value depends on the Orientation of the phone
                    if (this.Orientation == PageOrientation.LandscapeLeft)
                    {
                        speedBar = -Convert.ToDouble(x);
                    }
                    else
                    {
                        speedBar = Convert.ToDouble(x);
                    }
                    //bar won't move out of canvas is there's less than 60 rectangle in canvas
                    if (rectsAmount < 60)
                    {
                        // bar touched left border
                        if (rectX + speedBar < 0)
                        {
                            //set its leftproperty to the very left of canvas
                            rctControl.SetValue(Canvas.LeftProperty, Convert.ToDouble(0));
                        }
                        // bar touched right border
                        else if (rectX + speedBar > cnvMain.ActualWidth - rctControl.Width)
                        {
                            //set its leftproperty to the very left of canvas
                            rctControl.SetValue(Canvas.LeftProperty, cnvMain.ActualWidth - rctControl.Width);
                        }
                        else
                        {
                            //set moving speed of bar
                            rectX += speedBar;
                            //move the ball with bar when game haven't start
                            if (!isStarted)
                            {
                                //set moving speed of ball same as bar
                                ballX += speedBar;
                                elsHit.SetValue(Canvas.LeftProperty, ballX);
                            }
                            // move the bar by accel
                            rctControl.SetValue(Canvas.LeftProperty, rectX);
                        }
                    }
                    else
                    {
                        //bar will be out of border
                        rectX += speedBar;
                        //move the ball with bar when game haven't start
                        if (!isStarted)
                        {
                            ballX += speedBar;
                            elsHit.SetValue(Canvas.LeftProperty, ballX);
                        }
                        // move the bar by accel
                        rctControl.SetValue(Canvas.LeftProperty, rectX);
                    }
                    // detect collision between ball and rectangle
                    switch (CanvasSetup.DetectCollision(cnvMain, elsHit, speedX, speedY))
                    {
                        case 0:
                            break;
                        case 1:
                            //touch left or right side of the rectangle
                            speedX = -speedX;
                            break;
                        case 2:
                            //touch top or bottom of the rectangle
                            speedY = -speedY;
                            break;
                        case 3:
                            //touch the corners of the rectangle
                            speedX = -speedX;
                            speedY = -speedY;
                            break;
                        default:
                            //no rectangle left, start a new game
                            rectsAmount += 2;
                            initialLevel();
                            break;
                    }
                }
            });

        }

        private void stopGame()
        {
           // show game over
            txtGameOver.Text = "Game Over";
            //start a new timer to prepare go back to the main page
            DispatcherTimer stopTimer = new DispatcherTimer();
            stopTimer.Interval = TimeSpan.FromSeconds(1);
            stopTimer.Tick += stopTimer_Tick;
            stopTimer.Start();
        }

        void stopTimer_Tick(object sender, EventArgs e)
        {
            //navigate to the main page
            DispatcherTimer a = sender as DispatcherTimer;
            a.Stop();
            if (this.NavigationService.CanGoBack)
            {
                //this should happen every time ideally
                this.NavigationService.GoBack();
            }
            else
            {
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }

        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
           //stop and reset the game when go away from this page
            isPlaying = false;
            isStarted = false;
            //stop accelerometre reading
            acl.Stop();
            //reset the speed of the ball
            speedX = -5;
            speedY = -5;
            //stop the bar
            speedBar = 0;
            //save the existing amount for new level calculating
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("Amount"))
            {
                //create the data if it hasn't been created yet
                settings.Add("Amount", rectsAmount.ToString());
            }
            else
            {
                settings["Amount"] = rectsAmount.ToString();
            }
            settings.Save();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //initial the game when come into this page
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            //try to read the amount from isolated storge
            if (IsolatedStorageSettings.ApplicationSettings.Contains("Amount"))
            {
                rectsAmount = Convert.ToInt16(IsolatedStorageSettings.ApplicationSettings["Amount"].ToString());
            }
            else
            {
                //if it's not exist set it to initial value
                rectsAmount = 10;
            }
            //initialise the touchpanel detection
            TouchPanel.EnabledGestures = GestureType.Tap;
            LayoutRoot.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(LayoutRoot_ManipulationCompleted);
            //start accelerometre.
            startAcc();
            //pass in the width and height of the screen
            
            //start the level
            initialLevel();
           
        }

        private void initialLevel()
        {
            if (rectsAmount > 112)
            {
                //user finish all level
                txtLevelUp.Text = "Congratulations!\nYou have finish the game.";
            }
            else
            {
                //start a new game
                isPlaying = false;
                isStarted = false;
                //ball speed depends on the level
                speedX = -5 - rectsAmount / 10;
                speedY = -5 - rectsAmount / 10;
                speedBar = 0;
                //show level label
                txtLevelUp.Visibility = System.Windows.Visibility.Visible;
                if (rectsAmount == 10)
                {
                    //if this is the first level show the game's introduction
                    txtLevelUp.Text = "Tap screen to Start and Pause.\nTilt your device to control the bar!";
                }
                else
                {
                    //show present level
                    txtLevelUp.Text = "Level " + ((rectsAmount - 10) / 2).ToString();
                }
                
                
            }
            //satrt a new time to set up next level
            DispatcherTimer ac = new DispatcherTimer();
            ac.Interval = TimeSpan.FromSeconds(1);
            ac.Tick += ac_Tick;
            ac.Start();
            //stop the accelerometre reading
            acl.Stop();
        }

        void ac_Tick(object sender, EventArgs e)
        {
            if (rectsAmount != 10)
            {
                //if this is not the first level hide the level label automatic
                txtLevelUp.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (rectsAmount > 112) {
                if (this.NavigationService.CanGoBack)
                {
                    //this should happen every time ideally
                    this.NavigationService.GoBack();
                }
                else
                {
                    this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
            else
            {
                //initial the next level
                elsHit.SetValue(Canvas.LeftProperty, Convert.ToDouble(385));
                elsHit.SetValue(Canvas.TopProperty, Convert.ToDouble(420));
                rctControl.SetValue(Canvas.LeftProperty, Convert.ToDouble(300));
                rctControl.SetValue(Canvas.TopProperty, Convert.ToDouble(450));
                CanvasSetup cavSet = CanvasSetup.GetSetup(800, 400);//rectsAmount, cnvMain);
                cavSet.Initialise(rectsAmount, cnvMain);
                //start accelerometre reading
                acl.Start();
            }
            //stop this timer
                DispatcherTimer a = sender as DispatcherTimer;
                a.Stop();
          
        }





    }
}