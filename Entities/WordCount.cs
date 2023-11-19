using System;
using System.Linq;

namespace TypingGame.Entities
{
    internal class WordCount
    {
        private static int[] allowableCount = new int[] { 1, 3, 9 };
        private int count;

        public static int[] GetAllowableCount => allowableCount;

        public int Count
        {
            get => count;
            set
            {
                if (allowableCount.Contains(value))
                    count = value;
                else
                    throw new Exception();
            }
        }

        public WordCount()
        {
            Count = allowableCount[0];
        }
        public WordCount(int value)
        {
            Count = value;
        }
    }
}
