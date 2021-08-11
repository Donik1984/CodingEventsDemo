﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class EventCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event> events { get; set; }
        public EventCategory()
        {
        }
        public EventCategory(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is EventCategory @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
