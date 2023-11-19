
using System;
using TypingGame.Entities;
using TypingGame.Result;
using TypingGame.Settings;
using TypingGame.Words;

namespace TypingGame.Auxiliary
{
    internal static class MessageTemplatesAuxiliary
    {
        public static void OutputActualSetting()
        {
            Console.WriteLine("Settings:\n");
            
            Console.WriteLine($"Timer: {ActualSettings.actualTime.Timer}s");
            Console.WriteLine($"Difficulty level: {ActualSettings.actualDifficulty.LevelOfDifficultiesToString}");
            Console.WriteLine($"Word count: {ActualSettings.actualWordCount.Count}\n");
        }

        public static void OutputExitMessage()
        {
            Console.WriteLine("Are you confirming the exit?\n");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }

        public static void OutputMenuMessage()
        {
            Console.WriteLine("1. Game");
            Console.WriteLine("2. Words import");
            Console.WriteLine("3. Settings");
            Console.WriteLine("4. Results");
            Console.WriteLine("5. Exit");
        }

        public static void OutputSettingsMenuMessage()
        {
            MessageTemplatesAuxiliary.OutputActualSetting();

            Console.WriteLine("1. Change time");
            Console.WriteLine("2. Change difficulty level");
            Console.WriteLine("3. Change word count");
            Console.WriteLine("4. Back to the main menu");
        }

        public static void OutputWordsRules()
        {
            Console.WriteLine("Rules:\n" +
                              "\nTo import a new vocabulary you must select a difficulty level" +
                              "\nand enter the absolute path to a vocabulary in .txt format" +
                              $"\nwhich stores at least than {Vocabulary.minVocabularyDifficultyLength} words of the selected difficulty level." +
                              "\nEach new word in vocabulary must start on a new line." +
                              "\n\nThe complexity of a word directly depends on the number of letters:" +
                              $"\n\n{DifficultyLevel.GetAllowableEasyLimits[0]}-{DifficultyLevel.GetAllowableEasyLimits[1]} is an difficulty level" +
                              $"\n{DifficultyLevel.GetAllowableNormalLimits[0]}-{DifficultyLevel.GetAllowableNormalLimits[1]} is an normal difficulty level" +
                              $"\n{DifficultyLevel.GetAllowableHardLimits[0]}-{DifficultyLevel.GetAllowableHardLimits[1]} is an hard difficulty level\n");
        }

        public static void OutputWordsChangePathMessage()
        {
            MessageTemplatesAuxiliary.OutputWordsRules();

            Console.WriteLine("1. Easy difficulty");
            Console.WriteLine("2. Normal difficulty");
            Console.WriteLine("3. Hard difficulty");
            Console.WriteLine("4. Back to main menu");
        }

        public static void OutputSuppurtedLevels()
        {
            Console.WriteLine($"Easy level support: {Vocabulary.AllowableDifficultyLevels[0]}");
            Console.WriteLine($"Normal level support: {Vocabulary.AllowableDifficultyLevels[1]}");
            Console.WriteLine($"Hard level support: {Vocabulary.AllowableDifficultyLevels[2]}\n");
        }

        public static void OutputWordsMessage()
        {
            Console.WriteLine("Words import:\n");

            Console.WriteLine($"Actual path to vocabulary: {Vocabulary.GetPath}\n");

            OutputSuppurtedLevels();

            Console.WriteLine("1. Change vocabulary path");
            Console.WriteLine("2. Back to the main menu");

        }

        public static void OutputGameRules()
        {
            Console.WriteLine("Rules:\n");

            Console.WriteLine("The game includes a time that shows the countdown time" +
                              "\nFor which the player must enter as many words as possible" +
                              "\nThe words will appear in front of him on the screen" +
                              "\n\nWords are entered on a line with a space" +
                              "\nFor rach correctly entered word the player gets one point\n");
        }

        public static void OutputGameMessage()
        {
            OutputGameRules();
            OutputActualSetting();

            Console.WriteLine("1. Start the game");
            Console.WriteLine("2. Go to settings");
            Console.WriteLine("3. Back to the main menu");
        }

        public static void OutputGameFailedStartMessage()
        {
            Console.WriteLine("Failed to launch the game." +
                              "\nTry changing the difficulty level of vocabulary");
            Console.WriteLine();
            OutputSuppurtedLevels();
            Console.Write("Press enter to continue.");
        }

        public static void CheckPassResultMessage(int points)
        {
            Console.WriteLine("Pass result:\n");

            OutputActualSetting();
            Console.WriteLine($"Points: {points}\n");

            Console.WriteLine("Do you want save that score?\n");
            
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

        }

        public static void WaitMessage()
        {
            Console.WriteLine("Please, wait..");
        }

        public static void ZeroResultMessage()
        {
            ResultLogoMessage();
            Console.Write("Records are not set.");
        }

        public static void ResultLogoMessage()
        {
            Console.WriteLine("Results:\n");
        }
        public static void OneResultMessage()
        {
            ResultLogoMessage();

            using (var db = new ResultDB())
            {
                foreach(var record in db.Scores)
                {
                    Console.WriteLine($"{record.id}. {record.ToString()}");
                }
            }
        }
    }
}
