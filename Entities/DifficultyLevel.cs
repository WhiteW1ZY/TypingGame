using System;
using System.Linq;

namespace TypingGame.Entities
{
    internal class DifficultyLevel
    {
        private static int[] allowableEasyLimits = { 1, 5 };
        private static int[] allowableNormalLimits = { 6, 7 };
        private static int[] allowableHardLimits = { 8, 20 };
        private static int[] allowableDifficulties = new int[] { 1, 2, 3 };
        private int levelOfDifficulties;

        public static int[] GetAllowableEasyLimits => allowableEasyLimits;
        public static int[] GetAllowableNormalLimits => allowableNormalLimits;
        public static int[] GetAllowableHardLimits => allowableHardLimits;
        public static int[] GetAllowableDifficulties => allowableDifficulties;

        public int LevelOfDifficulties
        {
            get => levelOfDifficulties;
            set
            {
                if (allowableDifficulties.Contains(value))
                    levelOfDifficulties = value;
                else
                    throw new Exception();
            }
        }

        public string LevelOfDifficultiesToString => ((LevelsAndNumbers)levelOfDifficulties).ToString();

        public static string ChoosenLevelOfDifficultiesToString(int number) => ((LevelsAndNumbers)number).ToString();

        public DifficultyLevel()
        {
            LevelOfDifficulties = allowableDifficulties[0];
        }
        public DifficultyLevel(int value)
        {
            LevelOfDifficulties = value;
        }

        private enum LevelsAndNumbers
        {
            Easy = 1,
            Normal,
            Hard
        }
    }
}
