using TypingGame.Exit;
using TypingGame.Menu;
using TypingGame.Settings;
using TypingGame.Words;
using TypingGame.Game;
using TypingGame.Result;

namespace TypingGame.Auxiliary
{
    internal static class FormsControlAuxiliary
    {
        public static GameControl gameControl = new GameControl();
        public static MenuControl menuControl = new MenuControl();
        public static WordsControl wordsControl = new WordsControl();
        public static SettingsControl settingsControl = new SettingsControl();
        public static ResultControl resultControl = new ResultControl();
        public static ExitControl exitControl = new ExitControl();
    }
}
