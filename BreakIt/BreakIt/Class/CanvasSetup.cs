using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BreakIt
{
    public class CanvasSetup
    {
        private static List<Rectangle> rectList;
        private static List<List<Double>> indexList;
        private static Double width;
        private static Double height;
        private static Int16 level;
        private static CanvasSetup cavset = new CanvasSetup();

        private CanvasSetup()
        {
          
            if (IsolatedStorageSettings.ApplicationSettings.Contains("Level"))
            {
                level = Convert.ToInt16(IsolatedStorageSettings.ApplicationSettings["Level"].ToString());

            }
            else
            {
                level = 0;
            }
        }
      
        private static void saveLevel()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (IsolatedStorageSettings.ApplicationSettings.Contains("Level"))
            {
                Int16 temp = Convert.ToInt16(IsolatedStorageSettings.ApplicationSettings["Level"].ToString());
                if (level > temp)
                {
                    settings["Level"] = level.ToString();
                }
            }
            else
            {
                settings.Add("Level", level.ToString());
            }
            settings.Save();
        }
        public static CanvasSetup GetSetup(Double width, Double height)
        {
            CanvasSetup.width = width;
            CanvasSetup.height = height;
            indexList = new List<List<Double>>();
            List<Double> tempList = new List<Double>();
            for (int i = 0; i < 112; i++)
            {
                tempList = new List<Double>();
                tempList.Add(Convert.ToDouble(Convert.ToInt16((14 + i) / 14) * (height / 16)));
                tempList.Add(Convert.ToDouble(Convert.ToInt16((i + 1) % 14) * (width / 16)));
                indexList.Add(tempList);

            }
            return cavset;
        }

        //private Storyboard setAnimation(Rectangle rect)
        //{
        //    // Create a duration of 2 seconds.
        //    Duration duration = new Duration(TimeSpan.FromSeconds(1));
        //    ObjectAnimationUsingKeyFrames oA = new ObjectAnimationUsingKeyFrames();
        //    ColorAnimation clorAnimation = new ColorAnimation();
        //    clorAnimation.From = Color.FromArgb(255, Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
        //    clorAnimation.To = Color.FromArgb(255, Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)));
        //    clorAnimation.Duration = duration;
        //    clorAnimation.AutoReverse = true;
        //    clorAnimation.RepeatBehavior = RepeatBehavior.Forever;
         
        //    LinearGradientBrush tempBrush = new LinearGradientBrush();
        //    tempBrush.StartPoint = new Point(0, 0);
        //    tempBrush.EndPoint = new Point(1, 1);
        //    GradientStop gs = new GradientStop();
        //    gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(200, 255)), Convert.ToByte(new Random().Next(50, 255)), Convert.ToByte(new Random().Next(0, 120)));
        //    gs.Offset = 0.25;
        //    tempBrush.GradientStops.Add(gs);
        //    gs = new GradientStop();
        //    gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(200, 255)), Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 120)));
        //    gs.Offset = 0.55;
        //    gs = new GradientStop();
        //    gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(200, 255)), Convert.ToByte(new Random().Next(150, 255)), Convert.ToByte(new Random().Next(0, 120)));
        //    gs.Offset = 0.75;
        //    tempBrush.GradientStops.Add(gs);
            
        //    rect.Fill = tempBrush;
        //    Storyboard sb = new Storyboard();
        //    sb.AutoReverse = true;
        //    sb.RepeatBehavior = RepeatBehavior.Forever;
        //    sb.Duration = duration;
        //    sb.Children.Add(clorAnimation);
        //    Storyboard.SetTarget(clorAnimation, gs);
        //    Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        //    return sb;
          
        //}


        public static Int16 DetectCollision(Canvas cnv,Ellipse els, Double speedX, Double speedY)
        {

            Int16 dir = 0;
            Double ballX = Convert.ToDouble(els.GetValue(Canvas.LeftProperty));
            Double ballY = Convert.ToDouble(els.GetValue(Canvas.TopProperty));
            for (int i = 0; i < rectList.Count; i++)
            {
                Rectangle tempRect = rectList.ElementAt(i);
                Double x = Convert.ToDouble(tempRect.Tag.ToString().Split(',').ElementAt(1));
                Double y = Convert.ToDouble(tempRect.Tag.ToString().Split(',').ElementAt(0));
                if (ballY + els.Height > y && ballY + els.Height < y + height / 16 && ballX + els.Width / 2 > x && ballX + els.Width / 2 < x + width / 16)
                {
                    dir += 2;
                    cnv.Children.Remove(tempRect);
                    rectList.Remove(tempRect);
                    cnv.Resources.Remove("sotryboard" + tempRect.Tag);
                    SoundManager.BrickSound();
                    if (rectList.Count == 0)
                    {
                        saveLevel();
                        dir = 9;
                    }
                    break;
                }
                if (ballY < y + height / 16 && ballY > y && ballX + els.Width / 2 > x && ballX + els.Width / 2 < x + width / 16)
                {
                    dir += 2;
                    cnv.Children.Remove(tempRect);
                    rectList.Remove(tempRect);
                    cnv.Resources.Remove("sotryboard" + tempRect.Tag);
                    SoundManager.BrickSound();
                    if (rectList.Count == 0)
                    {
                        saveLevel();
                        dir = 9;
                    }
                    break;
                }

                if (ballX + els.Width > x && ballX + width < x + width / 16 && ballY + els.Height / 2 > y && ballY + els.Height / 2 < y + height / 16)
                {
                    dir += 1;
                    cnv.Children.Remove(tempRect);
                    rectList.Remove(tempRect);
                    cnv.Resources.Remove("sotryboard" + tempRect.Tag);
                    SoundManager.BrickSound();
                    if (rectList.Count == 0)
                    {
                        saveLevel();
                        dir = 9;
                    }
                    break;
                }
                if (ballX < x + width / 16 && ballX > x && ballY + els.Height / 2 > y && ballY + els.Height / 2 < y + height / 16)
                {
                    dir += 1;
                    cnv.Children.Remove(tempRect);
                    rectList.Remove(tempRect);
                    cnv.Resources.Remove("sotryboard" + tempRect.Tag);
                    SoundManager.BrickSound();
                    if (rectList.Count == 0)
                    {
                        saveLevel();
                        dir = 9;
                    }
                    break;
                }
            }


            #region Wrong Logic
            //    if (speedX > 0)
            //    {
            //        if (ballX + els.Width > x)
            //        {
            //            if (ballY + els.Height / 2 > y && ballY + els.Height < y + height)
            //            {
            //                dir += 1;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (ballX < x + width)
            //        {
            //            if (ballY + els.Height / 2 > y && ballY + els.Height < y + height)
            //            {
            //                dir += 1;
            //                break;
            //            }
            //        }

            //    }


            //    if (speedY > 0)
            //    {
            //        if (ballY + els.Height > y)
            //        {
            //            if (ballX + els.Width / 2 > x && ballX + els.Width / 2 < x + width)
            //            {
            //                dir += 2;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (ballY < y + height)
            //        {
            //            if (ballX + els.Width / 2 > x && ballX + els.Width / 2 < x + width)
            //            {
            //                dir+=2;
            //                break;
            //            }
            //        }

            //    }

                
            //}
            #endregion Wrong Logic

            return dir;

        }

        public void Initialise(Int16 count, Canvas cnv)
        {


            // count here is how many rectangles you want to add
            level = Convert.ToInt16((count - 8) / 2);
            rectList = new List<Rectangle>();
            for (int i = 0; i < count; i++)
            {
                int ran = new Random().Next(0, indexList.Count - 1);
                List<Double> tempChoose = indexList.ElementAt(ran);
                indexList.RemoveAt(ran);

                BricksFactory brickFac = BricksFactory.GetFactory();

                Bricks brick = brickFac.CreateRectangle(width, height);
                Rectangle rect = brick.GetRectangle();
                rect.Tag = tempChoose.ElementAt(0).ToString() + ',' + tempChoose.ElementAt(1).ToString();
                rect.SetValue(Canvas.LeftProperty, tempChoose.ElementAt(1));
                rect.SetValue(Canvas.TopProperty, tempChoose.ElementAt(0));
                Storyboard sb = brick.GetStoryboard();
                rectList.Add(rect);
                cnv.Children.Add(rect);
                cnv.Resources.Add("sotryboard" + rect.Tag, sb);
                sb.Begin();
            }

        }

    }
}
