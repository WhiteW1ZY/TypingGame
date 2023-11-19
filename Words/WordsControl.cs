using System;
using TypingGame.Auxiliary;
using TypingGame.Entities;
using TypingGame.Settings;

namespace TypingGame.Words
{
    internal class WordsControl
    {
        private int choosenDifficulty = DifficultyLevel.GetAllowableDifficulties[0];

        public void LoadWordsMenu()
        {
            Console.Clear();

            MessageTemplatesAuxiliary.OutputWordsMessage();

            switch (SwitchAuxiliary.GetValueForSwitch(3))
            {
                case 1: LoadWordsMenuChangePath(); break;
                case 2: FormsControlAuxiliary.menuControl.LoadMenu(); break;
            }
        }

        private void LoadWordsMenuChangePath()
        {
            Console.Clear();

            MessageTemplatesAuxiliary.OutputWordsChangePathMessage();

            switch (SwitchAuxiliary.GetValueForSwitch(4))
            {
                case 1: choosenDifficulty = DifficultyLevel.GetAllowableDifficulties[0]; LoadWordsMenuChangePathConfirmation(); break;
                case 2: choosenDifficulty = DifficultyLevel.GetAllowableDifficulties[1]; LoadWordsMenuChangePathConfirmation(); break;
                case 3: choosenDifficulty = DifficultyLevel.GetAllowableDifficulties[2]; LoadWordsMenuChangePathConfirmation(); break;
                case 4: FormsControlAuxiliary.menuControl.LoadMenu(); break;
            }
        }

        private void LoadWordsMenuChangePathConfirmation()
        {
            Console.Clear();
            Console.WriteLine($"Selected difficulty level: {DifficultyLevel.ChoosenLevelOfDifficultiesToString(choosenDifficulty)}");
            Console.Write("Enter the absolute path to the vocabulary: ");
            InputPath();
        }

        private void InputPath()
        {
            string pathToFile = Console.ReadLine();
            while (!Vocabulary.CheckVocabulary(pathToFile, choosenDifficulty))
            {
                Console.WriteLine("File does not exist or does not math the condition.");
                Console.Write("\nTry again or type the word 'back' to return to the difficulty selection: ");
                pathToFile = Console.ReadLine();

                if (pathToFile == "back")
                    LoadWordsMenuChangePath();
            }
            ActualSettings.actualDifficulty.LevelOfDifficulties = choosenDifficulty;
            FormsControlAuxiliary.wordsControl.LoadWordsMenu();
        }
    }
}
