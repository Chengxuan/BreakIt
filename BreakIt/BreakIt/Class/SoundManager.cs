using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BreakIt
{
    public class SoundManager
    {
        public static void BarSound()
        {
            Stream stream = TitleContainer.OpenStream("Sound/Bar.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }
        public static void WallSound()
        {
            Stream stream = TitleContainer.OpenStream("Sound/Wall.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }

        public static void BrickSound()
        {
            Stream stream = TitleContainer.OpenStream("Sound/Brick.wav");
            SoundEffect effect = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            effect.Play();
        }
       
       
    }
}
