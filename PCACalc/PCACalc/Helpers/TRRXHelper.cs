using System;
using System.Collections.Generic;
using System.Text;

namespace PCACalc.Helpers
{
    public class TRRXHelper
    {
        public double BagConcentration { get; set; }
        public double BasalRate { get; set; }
        public double BolusAmount { get; set; }
        public int BolusInterval { get; set; }
        public double VolumeRemaining { get; set; }

        public TRRXHelper()
        {
            BagConcentration = 0;
            BasalRate = 0;
            BolusAmount = 0;
            BolusInterval = 15;
            VolumeRemaining = 0;
        }

        private bool CheckEntries()
        {
            if (BagConcentration == 0) return false;
            if (BasalRate + BolusAmount == 0) return false;
            if (BolusInterval < 1) return false;
            if (VolumeRemaining < 1) return false;

            return true;
        }

        public double UnitsPerHour()
        {
            double unitsperhour = 0;

            if (CheckEntries() == true)
            {
                try
                {
                    unitsperhour = BasalRate + ((60 / BolusInterval) * BolusAmount);
                }
                catch
                {
                    return unitsperhour;
                }
            }
            return unitsperhour;
        }

        public double MLPerHour()
        {
            double mlperhour = 0;

            if (CheckEntries() == true)
            {
                try
                {
                    mlperhour = UnitsPerHour() / BagConcentration;
                }
                catch
                {
                    return mlperhour;
                }
            }

            return mlperhour;
        }
    }
}
