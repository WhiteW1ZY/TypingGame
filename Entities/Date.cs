using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TypingGame.Entities
{
    internal class Date
    {
        [Column(TypeName="Date")]
        public DateTime dateTime { get; set; }

        public Date()
        {
            dateTime = DateTime.Now;
        }
        public Date(DateTime dt)
        {
            dateTime = dt;
        }
    }
}
