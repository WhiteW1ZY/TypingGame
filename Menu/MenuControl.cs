using System;
using TypingGame.Auxiliary;

namespace TypingGame.Menu
{
    internal class MenuControl
    {

        public void LoadMenu()
        {
            Console.Clear();
            MessageTemplatesAuxiliary.OutputMenuMessage();
            switch (SwitchAuxiliary.GetValueForSwitch(5))
            {
                case 1: FormsControlAuxiliary.gameControl.LoadGameMenu(); break;
                case 2: FormsControlAuxiliary.wordsControl.LoadWordsMenu(); break;
                case 3: FormsControlAuxiliary.settingsControl.LoadSettingMenu(); break;
                case 4: FormsControlAuxiliary.resultControl.LoadResultMenu(); break;
                case 5: FormsControlAuxiliary.exitControl.LoadExitMenu(); break;
            }
        }
    }
}
