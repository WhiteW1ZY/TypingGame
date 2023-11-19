using System;

namespace TypingGame.Auxiliary
{
    internal static class SwitchAuxiliary
    {
        public static byte GetValueForSwitch(byte limit, byte min = 1)
        {

            Console.Write("\nChoose action: ");

            byte value = byte.MaxValue;

            while (value > limit || value < min)
            {
                try
                {
                    value = byte.Parse(Console.ReadLine());
                    if (value > limit || value < min)
                        throw new Exception();
                }
                catch
                {
                    Console.Write("Invalid input. Enter a value between {0} and {1}: ", min, limit);
                }
            }
            return value;
        }
    }
}
