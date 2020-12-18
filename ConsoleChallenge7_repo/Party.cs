using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChallenge7_repo
{
    public class Party
    {
        public string PartyTitle { get; set; }
        public DateTime PartyDate { get; set; }
        public double PartyCost { get; set; }
        public int TotalTickets { get; set; }
        public int BurgerTickets { get; set; }
        public int TreatTickets { get; set; }
        public double BBoothTotalCost { get; set; }
        public double TBoothTotalCost { get; set; }
        public double BurgerBoothOverhead { get; set; }
        public double TreatBoothOverhead { get; set; }
        public double BurgerUnitCost { get; set; }
        public double BurgerTotalCost { get; set; }
        public int BurgerVolume { get; set; }
        public double VeggieUnitCost { get; set; }
        public double VeggieTotalCost { get; set; }
        public int VeggieVolume { get; set; }
        public double HotDogUnitCost { get; set; }
        public double HotDogTotalCost { get; set; }
        public int HotDogVolume { get; set; }
        public double PopcornUnitCost { get; set; }
        public double PopcornTotalCost { get; set; }
        public int PopcornVolume { get; set; }
        public double IcecreamUnitCost { get; set; }
        public double IcecreamTotalCost { get; set; }
        public int IcecreamVolume { get; set; }

        public Party() { }

        public Party(string name, DateTime date, double burgerOverhead, double treatOverhead, double burgerUCost, int burgerVol, double veggieUCost, int veggieVol, double hotdogUCost, int hotdogVol, double popUCost, int popVol, double iceUCost, int iceVol)
        {

            PartyTitle = name;
            PartyDate = date;
            BurgerBoothOverhead = burgerOverhead;
            TreatBoothOverhead = treatOverhead;
            BurgerUnitCost = burgerUCost;
            BurgerVolume = burgerVol;
            VeggieUnitCost = veggieUCost;
            VeggieVolume = veggieVol;
            HotDogUnitCost = hotdogUCost;
            HotDogVolume = hotdogVol;
            PopcornUnitCost = popUCost;
            PopcornVolume = popVol;
            IcecreamUnitCost = iceUCost;
            IcecreamVolume = iceVol;
            /// caluculated fields           
            BurgerTotalCost = burgerUCost * burgerVol;
            VeggieTotalCost = veggieUCost * veggieVol;
            HotDogTotalCost = hotdogUCost * hotdogVol;
            BBoothTotalCost = BurgerTotalCost + VeggieTotalCost + HotDogTotalCost;
            PopcornTotalCost = popUCost * popVol;
            IcecreamTotalCost = iceUCost * iceVol;
            TBoothTotalCost = PopcornTotalCost + IcecreamTotalCost;
            BurgerTickets = burgerVol + veggieVol + hotdogVol;
            TreatTickets = popVol + iceVol;
            TotalTickets = burgerVol + veggieVol + hotdogVol + popVol + iceVol;
            PartyCost = BurgerTotalCost + VeggieTotalCost + HotDogTotalCost + PopcornTotalCost + IcecreamTotalCost + burgerOverhead + treatOverhead;
        }
    }
}
