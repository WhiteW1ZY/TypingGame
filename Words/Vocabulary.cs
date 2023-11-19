using System;
using System.IO;
using System.Linq;
using TypingGame.Entities;

namespace TypingGame.Words
{
    internal static class Vocabulary
    {
        private static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\Words\Levels\Words.txt";
        private static bool[] allowableDifficultyLevels = { false, false, false };

        public const int minVocabularyDifficultyLength = 300;

        public static string GetPath => path;
        public static bool SetPath(string pathToFile, int difficultyLevel)
        {
            if (CheckVocabulary(pathToFile, difficultyLevel))
                return true;
            else
                return false;
        }

        public static bool[] AllowableDifficultyLevels
        {
            get => allowableDifficultyLevels;
            set
            {
                if (value.Length == 3)
                    allowableDifficultyLevels = value;
                else
                    throw new Exception();
            }
        }


        public static string[] GetEasyLevelWords(string[] vocabulary) => GetAnythingWords(vocabulary, 0);
        public static string[] GetNormalLevelWords(string[] vocabulary) => GetAnythingWords(vocabulary, 1);
        public static string[] GetHardLevelWords(string[] vocabulary) => GetAnythingWords(vocabulary, 2);

        private static string[] GetAnythingWords(string[] vocabulary, byte difficultyLevel)
        {
            int[] allowableValues;

            switch (difficultyLevel)
            {
                case 0: allowableValues = DifficultyLevel.GetAllowableEasyLimits; break;
                case 1: allowableValues = DifficultyLevel.GetAllowableNormalLimits; break;
                default: allowableValues = DifficultyLevel.GetAllowableHardLimits; break;
            }
            return (from words in vocabulary
                    where words.Length >= allowableValues[0] && words.Length <= allowableValues[1]
                    select words).ToArray();
        }

        public static bool CheckVocabulary(string pathToFile, int difficultyLevel = -1)
        {
            if (File.Exists(pathToFile))
            {
                string[] vocabulary = File.ReadAllText(pathToFile).Split('\n');

                bool[] allowableLevels = {
                    GetEasyLevelWords(vocabulary).Length > minVocabularyDifficultyLength ? true : false,
                    GetNormalLevelWords(vocabulary).Length > minVocabularyDifficultyLength ? true : false,
                    GetHardLevelWords(vocabulary).Length > minVocabularyDifficultyLength ? true : false
                };

                if (difficultyLevel == -1 || allowableLevels[difficultyLevel - 1] == true)
                {
                    AllowableDifficultyLevels = allowableLevels;
                    path = pathToFile;
                    return true;
                }
            }
            return false;
        }

        static Vocabulary()
        {
            CheckVocabulary(path);
        }
    }
}
