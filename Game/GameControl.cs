using System;
using System.IO;
using TypingGame.Auxiliary;
using TypingGame.Words;
using System.Timers;
using TypingGame.Entities;
using TypingGame.Result;

namespace TypingGame.Game
{
    internal class GameControl
    {

        private bool exitFlag;
        private int secondLeft;
        private int points;
        private string[] wordsForGame;
        private string[] actualWords;
        private Timer timer;

        public void LoadGameMenu()
        {
            Console.Clear();

            Vocabulary.CheckVocabulary(Vocabulary.GetPath);
            MessageTemplatesAuxiliary.OutputGameMessage();

            switch (SwitchAuxiliary.GetValueForSwitch(3))
            {
                case 1: FormsControlAuxiliary.gameControl.CheckingBeforeStartGame(); break;
                case 2: FormsControlAuxiliary.settingsControl.LoadSettingMenu(); break;
                case 3: FormsControlAuxiliary.menuControl.LoadMenu(); break;
            }

            Console.ReadLine();
        }

        private void CheckingBeforeStartGame()
        {
            if (Vocabulary.AllowableDifficultyLevels[Settings.ActualSettings.actualDifficulty.LevelOfDifficulties - 1])
            {
                LaunchTheGame();
            }
            else
            {
                Console.Clear();
                MessageTemplatesAuxiliary.OutputGameFailedStartMessage();
                Console.ReadLine();
                FormsControlAuxiliary.gameControl.LoadGameMenu();
            }
        }

        private void ResetValues()
        {
            exitFlag = false;
            secondLeft = Settings.ActualSettings.actualTime.Timer;
            points = 0;

            string[] vocabulary = File.ReadAllText(Vocabulary.GetPath).Split('\n');

            switch(Settings.ActualSettings.actualDifficulty.LevelOfDifficulties - 1)
            {
                case 0: wordsForGame = Vocabulary.GetEasyLevelWords(vocabulary); break;
                case 1: wordsForGame = Vocabulary.GetNormalLevelWords(vocabulary); break;
                default: wordsForGame = Vocabulary.GetHardLevelWords(vocabulary); break;
            }
        }

        private string[] GetWordsByGame()
        {
            string[] words = new string[Settings.ActualSettings.actualWordCount.Count];
            var rand = new Random();
            
            for (int element = 0; element < words.Length; element++)
                words[element] = wordsForGame[rand.Next(wordsForGame.Length)];

            return words;
        }

        private int CountCorrectlyWords(string[] tested, string[] verifiable)
        {
            int limit = tested.Length < verifiable.Length ? tested.Length : verifiable.Length;
            int count = 0;
            
            for (int element = 0; element < limit; element++)
                if (tested[element] == verifiable[element])
                    count++;
            
            return count;
        }

        private void SetCurcors(int left, int top)
        {
            Console.CursorLeft = left;
            Console.CursorTop = top;
        }

        private void GameMessage()
        {
            SetCurcors(0, 0);
            Console.WriteLine($"Points: {points}");

            SetCurcors(0, 1);
            Console.WriteLine($"Time left: {secondLeft}s");

            SetCurcors(0, 2);
            Console.WriteLine("Type in the following words:");

            SetCurcors(0, 4);
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach (string word in actualWords)
                Console.Write(word + " ");

            Console.ForegroundColor = ConsoleColor.White;
            
            SetCurcors(0, 6);

            Console.WriteLine("Your input:");

            SetCurcors(0, 8);
        }

        private void LaunchTheGame()
        {

            ResetValues();

            timer = new Timer(1000);
            timer.Elapsed += GameTimer;
            timer.Start();

            while (exitFlag == false)
            {
                actualWords = GetWordsByGame();
                Console.Clear();

                GameMessage();

                points += CountCorrectlyWords(actualWords, (Console.ReadLine() + ' ').Split(' '));
            }

            CheckPassResult();
        }

        private void UpdateTimer()
        {
            var leftPosition = Console.CursorLeft;

            Console.SetCursorPosition(0, 1);

            Console.Write($"Time left: {secondLeft}s\t");

            Console.SetCursorPosition(leftPosition, 8);
        }

        private void GameTimer(object sender, EventArgs e)
        {
            secondLeft--;

            if (secondLeft > 0)
            {
                UpdateTimer();
            }
            else
            {
                timer.Stop();
                exitFlag = true;

                Console.Clear();

                Console.WriteLine("Time's up. Press enter to continue. ");
            
            }

        }

        private void CheckPassResult()
        {
            Console.Clear();

            MessageTemplatesAuxiliary.CheckPassResultMessage(points);

            switch (SwitchAuxiliary.GetValueForSwitch(2))
            {
                case 1: SaveScore(); break;
                case 2: FormsControlAuxiliary.menuControl.LoadMenu(); break;
            }
        }

        private void SaveScore()
        {
            Console.Clear();
            
            Console.Write("Input your nickname: ");

            var nickname = Console.ReadLine();

            Console.Clear();

            MessageTemplatesAuxiliary.WaitMessage();

            try
            {
                using (var db = new ResultDB())
                {
                    db.Scores.Add(new Score(new Person(nickname), new DifficultyLevel(), new Time(), new Date(), new Points(points)));
                    db.SaveChanges();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Failed to keep the record");
                Console.Write("Press enter to continue.");
                Console.ReadLine();
            }
            
            FormsControlAuxiliary.menuControl.LoadMenu();

        }
    }
}
