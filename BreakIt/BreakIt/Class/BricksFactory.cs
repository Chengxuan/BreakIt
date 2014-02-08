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
    public class BricksFactory
    {
        private static BricksFactory bricksFac = new BricksFactory();
        private BricksFactory()
        {
          
        }
        public static BricksFactory GetFactory()
        {
            return bricksFac;
        }

        public Bricks CreateRectangle(Double width, Double height)
        {
            Bricks brick;
            int rand = new Random().Next(0, 7);
            switch (rand)
            {
                case 0:
                    brick = new RedBrick(height / 16,width / 16 );
                    break;
                case 1:
                    brick = new GreenBrick(height / 16, width / 16);
                    break;
                case 2:
                    brick = new BlueBrick(height / 16, width / 16);
                    break;
                case 3:
                    brick = new YellowBrick(height / 16, width / 16);
                    break;
                case 4:
                    brick = new CyanBrick(height / 16, width / 16);
                    break;
                case 5:
                    brick = new PurpleBrick(height / 16, width / 16);
                    break;
                case 6:
                    brick = new OrangeBrick(height / 16, width / 16);
                    break;
                default:
                    brick = new RedBrick(height / 16, width / 16);
                    break;
            }
            return brick;

        }

    }
}
