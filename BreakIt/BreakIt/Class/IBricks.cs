using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BreakIt
{
    public abstract class Bricks
    {

        protected Rectangle rect;
        protected Storyboard sb;
        public abstract Rectangle GetRectangle();
        public abstract Storyboard GetStoryboard();
        protected Bricks(Double heigt, Double width)
        {
            rect = new Rectangle();
            sb = new Storyboard();
        }
    }

    public class RedBrick : Bricks
    {
        public RedBrick(Double height,Double width)
            : base(height,width)
        {
            //set height and width in constuctor
          
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,255,0,0);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
    
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
       
    }
    public class GreenBrick : Bricks
    {
        public GreenBrick(Double height,Double width)
            : base(height,width)
        {
            //set height and width in constuctor
          
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,0,255,0);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
           
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
    }
    public class OrangeBrick : Bricks
    {

        public OrangeBrick(Double height, Double width)
            : base(height,width)
        {
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(140, 170)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,255,165,0);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(140, 170)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(140, 170)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
       
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
    }
    public class YellowBrick : Bricks
    {
        public YellowBrick(Double height,Double width)
            : base(height,width)
        {
            //set height and width in constuctor
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,255,255,0);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color =Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
    }
    public class BlueBrick : Bricks
    {
        public BlueBrick(Double height,Double width)
            : base(height,width)
        {
            //set height and width in constuctor
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,0,0,255);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
    }
    public class CyanBrick : Bricks
    {
        public CyanBrick(Double height,Double width)
            : base(height,width)
        {
            //set height and width in constuctor
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,0,255,255);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(180, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
    }
    public class PurpleBrick : Bricks
    {
        public PurpleBrick(Double height,Double width)
            : base(height,width)
        {
            //set height and width in constuctor
            rect.Width = width;
            rect.Height = height;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            ColorAnimation clorAnimation = new ColorAnimation();
            clorAnimation.From = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(160, 200)), Convert.ToByte(new Random().Next(0, 100)), Convert.ToByte(new Random().Next(220, 255)));
            clorAnimation.To = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(0, 255)), Convert.ToByte(new Random().Next(180, 255)), Convert.ToByte(new Random().Next(0, 255)));
            clorAnimation.Duration = duration;
            clorAnimation.AutoReverse = true;
            clorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            LinearGradientBrush tempBrush = new LinearGradientBrush();
            tempBrush.StartPoint = new Point(0, 0);
            tempBrush.EndPoint = new Point(1, 1);
            GradientStop gs = new GradientStop();
            gs.Color = Color.FromArgb(255,160,32,240);
            gs.Offset = 0.25;
            tempBrush.GradientStops.Add(gs);
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(160, 200)), Convert.ToByte(new Random().Next(0, 100)), Convert.ToByte(new Random().Next(220, 255)));
            gs.Offset = 0.55;
            gs = new GradientStop();
            gs.Color = Color.FromArgb(Convert.ToByte(new Random().Next(100, 255)), Convert.ToByte(new Random().Next(160, 200)), Convert.ToByte(new Random().Next(0, 100)), Convert.ToByte(new Random().Next(220, 255)));
            gs.Offset = 0.75;
            tempBrush.GradientStops.Add(gs);

            rect.Fill = tempBrush;
            sb.AutoReverse = true;
            sb.RepeatBehavior = RepeatBehavior.Forever;
            sb.Duration = duration;
            sb.Children.Add(clorAnimation);
            Storyboard.SetTarget(clorAnimation, gs);
            Storyboard.SetTargetProperty(clorAnimation, new PropertyPath(GradientStop.ColorProperty));
        }
        public override Rectangle GetRectangle()
        {
            //throw new NotImplementedException();
            return rect;
        }

        public override Storyboard GetStoryboard()
        {
            //throw new NotImplementedException();
            return sb;
        }
    }
}
