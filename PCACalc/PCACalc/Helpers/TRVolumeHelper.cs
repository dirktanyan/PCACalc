using System;
using System.Collections.Generic;
using System.Text;

namespace PCACalc.Helpers
{
    public class TRVolumeHelper
    {
        public double BagConcentration { get; set; }

        public double Interval { get; set; }

        public double VolumeUsed { get; set; }
        public double VolumeRemaining { get; set; }

        public TRVolumeHelper()
        {
            BagConcentration = 0;
            Interval = 24;
            VolumeUsed = 0;
            VolumeRemaining = 0;
        }

        private bool CheckEntries()
        {
            if (BagConcentration == 0) return false;
            if (Interval < 1) return false;
            if (VolumeUsed < 1) return false;
            if (VolumeRemaining < 1) return false;

            return true;
        }

        public double MLPerHour()
        {
            double mlperhour = 0;

            if (CheckEntries() == true)
            {
                try
                {
                    mlperhour = VolumeUsed / Interval;
                }
                catch
                {
                    return mlperhour;
                }
            }
            return mlperhour;
        }

        public double UnitsPerHour()
        {
            double unitsperhour = 0;

            if (CheckEntries() == true)
            {
                try
                {
                    unitsperhour = (VolumeUsed * BagConcentration) / Interval;
                }
                catch
                {
                    return unitsperhour;
                }
            }
            return unitsperhour;
        }
    }
}
