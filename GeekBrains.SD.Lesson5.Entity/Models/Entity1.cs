using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBrains.SD.Lesson5.Entity.Models
{
    public abstract class Entity1
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", GetType().Name, Id);
        }
    }
}
