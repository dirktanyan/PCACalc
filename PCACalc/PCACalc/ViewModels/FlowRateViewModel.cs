using System;
using System.Collections.Generic;
using System.Text;

namespace PCACalc.ViewModels
{
    public class FlowRateViewModel : PCACBaseViewModel
    {
        public FlowRateViewModel()
        {
            Units = "mg";
        }
        private decimal _orderedbasalrate;
        public decimal OrderedBasalRate
        {   get
            {
                return _orderedbasalrate;
            }
            set
            {
                bool x = SetProperty(ref _orderedbasalrate, value);
                if (x == true && _pcaconcentration != 0)
                    CalcFlowRate();
            }
        }

        private decimal _pcaconcentration;
        public decimal PCAConcentration
        {
            get
            {
                return _pcaconcentration;
            }
            set
            {
                bool x = SetProperty(ref _pcaconcentration, value);
                if (x == true && _pcaconcentration != 0)
                    CalcFlowRate();
            }
        }
        private decimal _flowrate;
        public decimal FlowRate
        {
            get
            {
                return _flowrate;
            }
            set
            {
                SetProperty(ref _flowrate, value);
            }
        }
        private bool _unitchoice;
        public bool UnitChoice
        {
            // True: mcg
            // False: mg
            get
            {
                return _unitchoice;
            }
            set
            {
                SetProperty(ref _unitchoice, value);
                if (value == true)
                {
                    Units = "mcg";
                }
                else
                {
                    Units = "mg";
                }
            }
        }
        private string _units;
        public string Units
        {
            get
            {
                return _units;
            }
            set
            {
                SetProperty(ref _units, value);
            }
        }
        private void CalcFlowRate()
        {
            FlowRate = OrderedBasalRate / PCAConcentration;
        }

    }
}
