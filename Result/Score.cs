using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypingGame.Entities
{
    internal class Score
    {
        public int id { get; set; }
        private Person person = new Person();
        private DifficultyLevel difficultyLevel = new DifficultyLevel();
        private Time timer = new Time();
        private Date DateAndTime = new Date();
        private Points points = new Points();

        public string PersonNickName
        {
            get => person.nickname;
            set
            {
                person.nickname = value;
            }
        }

        public int DifficultyLevelValue
        {
            get => difficultyLevel.LevelOfDifficulties;
            set
            {
                difficultyLevel.LevelOfDifficulties = value;
            }
        }

        public int Time
        {
            get => timer.Timer;
            set
            {
                timer.Timer = value;
            }
        }

        [Column(TypeName = "Date")]
        public DateTime Dates
        {
            get => DateAndTime.dateTime;
            set
            {
                DateAndTime.dateTime = value;
            }
        }

        public int Point
        {
            get => points.points;
            set
            {
                points.points = value;
            }
        }

        public override string ToString() => string.Format($"Name: {PersonNickName} | Difficulty level: {DifficultyLevel.ChoosenLevelOfDifficultiesToString(DifficultyLevelValue)} " +
            $"| Time: {Time}s | Date: {DateAndTime.dateTime.ToShortDateString()} | Points: {Point}");

        public Score()
        {
        }

        public Score(Person p, DifficultyLevel diffLevel, Time timer, Date dt, Points point)
        {
            PersonNickName = p.nickname;
            DifficultyLevelValue = diffLevel.LevelOfDifficulties;
            Time = timer.Timer;
            Dates = dt.dateTime;
            Point = point.points;
        }
    }
}
