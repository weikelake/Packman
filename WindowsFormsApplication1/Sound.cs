using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;//подключаем звук

namespace WindowsFormsApplication1
{
    public static class Sound
    {
        static bool change = true;

        static SoundPlayer sound_Exit = new SoundPlayer(Properties.Resources.ExitGame);
        static SoundPlayer sound_Fail = new SoundPlayer(Properties.Resources.FailGame);
        static SoundPlayer sound_Start = new SoundPlayer(Properties.Resources.StartGame);
        static SoundPlayer sound_Key = new SoundPlayer(Properties.Resources.KeyGame);
        static SoundPlayer sound_Win = new SoundPlayer(Properties.Resources.youWinGame);
        static SoundPlayer sound_Food_1 = new SoundPlayer(Properties.Resources.food1);
        static SoundPlayer sound_Food_2 = new SoundPlayer(Properties.Resources.food2);
        static SoundPlayer sound_intro = new SoundPlayer(Properties.Resources.intro);
        static SoundPlayer sound_dead = new SoundPlayer(Properties.Resources.Dead);
        public static bool soundEnabled = true;//звук включен

        public static void SoundOn()
        { 
        soundEnabled = true;
        Sound.PlayKey();
        }
        public static void PlayDead()
        {
            if (soundEnabled)
                sound_dead.Play();
        }
        public static void SoundOff()
        { 
        soundEnabled = false;
        }


        //Функции для воспроизведения звуковых файлов

        public static void PlayFail()
        {
            if (soundEnabled)
                sound_Fail.Play();
        }

        public static void PlayStart()
        {
            if (soundEnabled)
            {
                sound_intro.Play();
            }
        }

        public static void Food()
        {
            if (soundEnabled)
                if (change)
                {
                    sound_Food_1.Play();
                    change = false;
                    return;
                }
                else
                {
                    sound_Food_2.Play();
                    change = true;
                    return;
                }
        }

        public static void PlayExit()
        {
            if (soundEnabled)
                sound_Exit.Play();
        }

        public static void PlayKey()
        {
            if (soundEnabled)
                sound_Key.Play();
        }

        public static void PlayWin()
        {
            if (soundEnabled)
                sound_Win.Play();
        }





    }//class Sound
}//namespace Labirint2D


