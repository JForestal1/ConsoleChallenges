using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge4_repo
{
    public class Outing
    {
        public enum EventType
        {
            Golf = 1,
            Bowling,
            Amusement_Park,
            Concert
        }

        public int Attendees { get; set; }
        public EventType Type { get; set; }
        public DateTime EventDate { get; set; }
        public double CostPP { get; set; }
        public double CostTotal { get; set; }

        public Outing() { }

        public Outing(EventType type, int attendees, DateTime eventDate, double costPP, double costTotal)
        {
            Type = type;
            Attendees = attendees;
            EventDate = eventDate;
            CostPP = costPP;
            CostTotal = costTotal;
        }
    }
}
