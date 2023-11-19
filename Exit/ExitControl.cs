using System;
using TypingGame.Auxiliary;

namespace TypingGame.Exit
{
    internal class ExitControl
    {
        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("See you next time!");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }


        public void LoadExitMenu()
        {
            Console.Clear();

            MessageTemplatesAuxiliary.OutputExitMessage();

            switch (SwitchAuxiliary.GetValueForSwitch(2))
            {
                case 1: Exit(); break;
                case 2: FormsControlAuxiliary.menuControl.LoadMenu(); break;
            }
        }
    }
}
