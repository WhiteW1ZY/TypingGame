using System;
using System.Linq;
using TypingGame.Auxiliary;

namespace TypingGame.Result
{
    internal class ResultControl
    {

        private void ManyResults()
        {
            int counter = 0;

            using (var db = new ResultDB())
            {
                MessageTemplatesAuxiliary.ResultLogoMessage();

                Console.WriteLine("1. Sort by date");
                Console.WriteLine("2. Sort by points");
                Console.WriteLine("3. Back to the main menu");

                IQueryable score = db.Scores;

                switch (SwitchAuxiliary.GetValueForSwitch(3))
                {
                    case 1: score = db.Scores.OrderBy(element => element.Dates); break;
                    case 2: score = db.Scores.OrderBy(element => element.Point); break;
                    case 3: FormsControlAuxiliary.menuControl.LoadMenu(); break;
                }

                Console.Clear();

                MessageTemplatesAuxiliary.ResultLogoMessage();

                foreach (var sc in score)
                {
                    Console.WriteLine($"{++counter}. {sc.ToString()}");
                }
            }
        }
        public void LoadResultMenu()
        {
            Console.Clear();

            MessageTemplatesAuxiliary.WaitMessage();

            int count;

            using(var db = new ResultDB())
            {
                count = db.GetCount();
            }

            Console.Clear();

            switch (count)
            {
                case 0: MessageTemplatesAuxiliary.ZeroResultMessage(); break;
                case 1: MessageTemplatesAuxiliary.OneResultMessage(); break;
                default: ManyResults();  break;
            }

            Console.Write("\nPress enter to back the main menu.");
            Console.ReadLine();
            FormsControlAuxiliary.menuControl.LoadMenu();
        }
    }
}
