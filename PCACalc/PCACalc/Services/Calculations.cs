using System;
using System.Collections.Generic;
using System.Text;
using PCACalc.Views;

namespace PCACalc.Services
{
    public static class Calculations
    {
        public static double CalcTPH(double basal, double bolus, double interval)
        {
            double dosesPerHour = 60 / interval;
            double bolusTPH = dosesPerHour * bolus;

            double totalPerHour = basal + bolusTPH;

            return Math.Round(totalPerHour, 2);
                 
        }

    }
    public class InjVsPCACalcs
    {
        public double AtcUnits { get; set; }
        public int AtcInterval { get; set; }
        public double PrnUnits { get; set; }
        public int PrnInterval { get; set; }
        public double VialConcentration { get; set; }
        public decimal VialPrice { get; set; }

        public InjVsPCACalcs()
        {
            AtcUnits = 0;
            AtcInterval = 1;
            PrnUnits = 0;
            PrnInterval = 1;
            VialConcentration = 0;
            VialPrice = 0;
        }

        public double UnitsPerHour(bool PRN)
        {
            double mgperhour = 0;
            if (PRN == false)
            {
                mgperhour = AtcUnits / AtcInterval;
            }
            else
            {
                mgperhour= PrnUnits / PrnInterval;
            }
            
            return Math.Round(mgperhour, 3);
        }

        public double TotalUnitsPerDay()
        {
            double atcperhour = AtcUnits / AtcInterval;
            double prnperhour = PrnUnits / PrnInterval;
            double unitsperhour = atcperhour + prnperhour;

            return Math.Round(unitsperhour * 24,3);
        }

        public int VialsPerDay(bool PRN)
        {
            int vialsPerDose, dosesPerDay;

            if(PRN == false)
            {
                vialsPerDose = (int)Math.Ceiling(AtcUnits / VialConcentration);
                dosesPerDay = 24 / AtcInterval;
            }
            else
            {
                vialsPerDose = (int)Math.Ceiling(PrnUnits / VialConcentration);
                dosesPerDay = 24 / PrnInterval;
            }
            
            return vialsPerDose * dosesPerDay;
        }
        public int TotalVialsPerDay()
        {
            int atc = VialsPerDay(false);
            int prn = VialsPerDay(true);

            return atc + prn;
        }
        
}

}
