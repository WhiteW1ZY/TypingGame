using System;
using System.Linq;
namespace TypingGame.Entities
{
    internal class Time
    {
        private static int[] allowableTimer = new int[] { 30, 60, 90 };
        private int timer;

        public static int[] GetAllowableTimer => allowableTimer;

        public int Timer
        {
            get => timer;
            set
            {
                if (allowableTimer.Contains(value))
                    timer = value;
                else
                    throw new Exception();
            }
        }

        public Time()
        {
           Timer = allowableTimer[0];
        }
        public Time(int value)
        {
            Timer = value;
        }
    }
}
