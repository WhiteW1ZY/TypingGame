using System;
using TypingGame.Auxiliary;
using TypingGame.Entities;

namespace TypingGame.Settings
{
    internal class SettingsControl
    {
        
        private void ChangeAnything(byte value)
        {
            Console.Clear();

            int[] allowableValues;

            switch (value)
            {
                case 1:
                    allowableValues = Time.GetAllowableTimer;
                    for (int element = 0; element < allowableValues.Length; element++)
                        Console.WriteLine("{0}. {1}s", element + 1, allowableValues[element]);
                    break;
                case 2:
                    allowableValues = DifficultyLevel.GetAllowableDifficulties;
                    for (int element = 0; element < allowableValues.Length; element++)
                        Console.WriteLine("{0}. {1}", element + 1, DifficultyLevel.ChoosenLevelOfDifficultiesToString(allowableValues[element]));
                    break;
                default:
                    allowableValues = WordCount.GetAllowableCount;
                    for (int element = 0; element < allowableValues.Length; element++)
                        Console.WriteLine("{0}. {1}", element + 1, allowableValues[element]);
                    break;
            }

            byte choose = SwitchAuxiliary.GetValueForSwitch((byte)allowableValues.Length);

            switch (value)
            {
                case 1: ActualSettings.actualTime.Timer = allowableValues[choose - 1]; break;
                case 2: ActualSettings.actualDifficulty.LevelOfDifficulties = allowableValues[choose - 1]; break;
                default: ActualSettings.actualWordCount.Count = allowableValues[choose - 1]; break;
            }

            LoadSettingMenu();
        }

        public void LoadSettingMenu()
        {
            Console.Clear();

            MessageTemplatesAuxiliary.OutputSettingsMenuMessage();
            switch (SwitchAuxiliary.GetValueForSwitch(4))
            {
                case 1: ChangeAnything(1); break;
                case 2: ChangeAnything(2); break;
                case 3: ChangeAnything(3); break;
                case 4: FormsControlAuxiliary.menuControl.LoadMenu(); break;
            }
            
            Console.ReadLine();
        }
    }
}
