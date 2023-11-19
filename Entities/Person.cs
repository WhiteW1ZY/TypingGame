namespace TypingGame.Entities
{
    internal class Person
    {
        public string nickname { get; set; }

        public Person()
        {
            nickname = "noname";
        }
        public Person(string nick)
        {
            if (nick == "")
                nickname = "noname";
            else
                nickname = nick;
        }
    }
}
