using System;
using System.Collections.Generic;
using System.Text;
using PCACalc.Views;

namespace PCACalc
{
    public static class Calculations
    {
        public static double CalcTPH(double basal, double bolus, double interval)
        {
            double totalPerHour;
            double bolusTPH;
            double dosesPerHour;

            dosesPerHour = 60 / interval;
            bolusTPH = dosesPerHour * bolus;

            totalPerHour = basal + bolusTPH;

            return Math.Round(totalPerHour, 2);
                 
        }

        public static double MGPerHour(double mg, double hours)
        {
            double mgperhour;

            mgperhour = mg / hours;

            return Math.Round(mgperhour, 3);
        }

    }

}
