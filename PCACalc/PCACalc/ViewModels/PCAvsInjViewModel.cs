using PCACalc.Helpers;
using PCACalc.Models;
using PCACalc.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PCACalc.ViewModels
{
    public class PCAvsInjViewModel : PCACBaseViewModel
    {
        public List<Med> medicationList { get; set; }
        public List<PCA> pcaList { get; set; }
        public List<PCABags> pcabaglist { get; set; }
        public ObservableCollection<PCAInfo> pcasandbags { get; set; }
        public Command LoadAssocPCAs { get; set; }
        public Command RunCalcs { get; set; }
        public Med selectedMed { get; set; } = new Med();
        public PCA selectedPCA { get; set; } = new PCA();

        public PCADataAccess PCADataStore = new PCADataAccess();

        MedicationHelper medicationHelper = new MedicationHelper();
        public InjVsPCACalcs calcService = new InjVsPCACalcs();

        public PCAvsInjViewModel()
        {
            medicationList = medicationHelper.GetAllMeds();
            pcaList = PCADataStore.GetPCAList();

            pcasandbags = new ObservableCollection<PCAInfo>();

            RunCalcs = new Command(async () => await RunCalculations());

            //PCAs = new ObservableCollection<PCA>();
            //LoadAssocPCAs = new Command(async () => await LoadAssociatedPCAs());
        }

        #region Properties
        private string _pumprental = Preferences.Get(nameof(PumpRental), "10");
        public string PumpRental
        {
            get => _pumprental;
        }
        private string _units;
        public string Units
        {
            get
            {
                if(_units != null)
                {
                    return _units.ToUpper();
                }
                return _units;
            }
            set
            {
                _units = value;
                OnPropertyChanged(nameof(Units));
            }
        }
        public object PickedMed
        {
            get
            {
                return selectedMed;
            }
            set
            {
                selectedMed = value as Med;
                Units = selectedMed.VialUnits;
                OnPropertyChanged(nameof(PickedMed));
            }
        }
        public object PickedPCA
        {
            get
            {
                return selectedPCA;
            }
            set
            {
                selectedPCA = value as PCA;
                GetPCAsAndBags();
                OnPropertyChanged(nameof(PickedPCA));
            }
        }
        
        public string ATCOrderUnits
        {
            get => calcService.AtcUnits.ToString();
               
            set
            {
                calcService.AtcUnits = double.Parse(value);
                OnPropertyChanged(nameof(ATCOrderUnits));
                var c = RunCalculations();
            }
        }
        public string ATCOrderInterval
        {
            get => calcService.AtcInterval.ToString();
            set
            {
                calcService.AtcInterval = int.Parse(value);
                OnPropertyChanged(nameof(ATCOrderInterval));
                var c = RunCalculations();
            }
        }
        public string PRNOrderUnits
        {
            get => calcService.PrnUnits.ToString();
            set
            {
                calcService.PrnUnits = double.Parse(value);
                OnPropertyChanged(nameof(PRNOrderUnits));
                var c = RunCalculations();
            }
        }
        public string PRNOrderInterval
        {
            get => calcService.PrnInterval.ToString();
            set
            {
                calcService.PrnInterval = int.Parse(value);
                OnPropertyChanged(nameof(PRNOrderInterval));
                var c = RunCalculations();
            }
        }

        private string _atcunitsperhour;
        public string ATCUnitsPerHour
        {
            get
            {
                return _atcunitsperhour;
            }
            set
            {
                _atcunitsperhour = value;
                OnPropertyChanged(nameof(ATCUnitsPerHour));
            }
        }
        private string _atcvialsperday;
        public string ATCVialsPerDay
        {
            get
            {
                return _atcvialsperday;
            }
            set
            {
                _atcvialsperday = value;
                OnPropertyChanged(nameof(ATCVialsPerDay));
            }
        }
        private string _atccostperday;
        public string ATCCostPerDay
        {
            get
            {
                return _atccostperday;
            }
            set
            {
                _atccostperday = value;
                OnPropertyChanged(nameof(ATCCostPerDay));
            }
        }
        private string _prnunitsperhour;
        public string PRNUnitsPerHour
        {
            get
            {
                return _prnunitsperhour;
            }
            set
            {
                _prnunitsperhour = value;
                OnPropertyChanged(nameof(PRNUnitsPerHour));
            }
        }
        private string _prnvialsperday;
        public string PRNVialsPerDay
        {
            get
            {
                return _prnvialsperday;
            }
            set
            {
                _prnvialsperday = value;
                OnPropertyChanged(nameof(PRNVialsPerDay));
            }
        }
        private string _prncostperday;
        public string PRNCostPerDay
        {
            get
            {
                return _prncostperday;
            }
            set
            {
                _prncostperday = value;
                OnPropertyChanged(nameof(PRNCostPerDay));
            }
        }
        private string _totalunitsperday;
        public string TotalUnitsPerDay
        {
            get
            {
                return _totalunitsperday;
            }
            set
            {
                _totalunitsperday = value;
                OnPropertyChanged(nameof(TotalUnitsPerDay));
            }
        }
        private string _totalvialsperday;
        public string TotalVialsPerDay
        {
            get
            {
                return _totalvialsperday;
            }
            set
            {
                _totalvialsperday = value;
                OnPropertyChanged(nameof(TotalVialsPerDay));
            }
        }
        private string _vialscostperday;
        public string VialsCostPerDay
        {
            get
            {
                return _vialscostperday;
            }
            set
            {
                _vialscostperday = value;
                OnPropertyChanged(nameof(VialsCostPerDay));
            }
        }
        #endregion

        public async Task<bool> GetPCAsAndBags()
        {
            pcasandbags.Clear();

            var bags = await PCADataStore.GetPCABagsAsync(selectedPCA.ID);

            foreach(var _bag in bags)
            {
                PCAInfo info = new PCAInfo
                {
                    PCAID = selectedPCA.ID,
                    PCABagID = _bag.ID,
                    PCAConcentration = selectedPCA.PCAConcn,
                    PCADrug = selectedPCA.PCADrug,
                    PCASize = _bag.PCASize,
                    PCAPrice = _bag.PCAPrice,
                    PCAPricePerUnit = Math.Round(_bag.PCAPrice / (_bag.PCASize * selectedPCA.PCAConcn), 2),
                    DaysSupply = Math.Round((_bag.PCASize * selectedPCA.PCAConcn) / double.Parse(TotalUnitsPerDay), 2)
                };
                pcasandbags.Add(info);
            }
            return true;

        }
        public async Task<bool> RunCalculations()
        {
            calcService.VialConcentration = selectedMed.VialConcentration;
            calcService.VialPrice = selectedMed.VialPrice;

            ATCUnitsPerHour = calcService.UnitsPerHour(false).ToString();
            ATCVialsPerDay = calcService.VialsPerDay(false).ToString();
            ATCCostPerDay = (selectedMed.VialPrice * int.Parse(ATCVialsPerDay)).ToString("c");

            PRNUnitsPerHour = calcService.UnitsPerHour(true).ToString();
            PRNVialsPerDay = calcService.VialsPerDay(true).ToString();
            PRNCostPerDay = (selectedMed.VialPrice * int.Parse(PRNVialsPerDay)).ToString("c");

            TotalUnitsPerDay = calcService.TotalUnitsPerDay().ToString();
            TotalVialsPerDay = calcService.TotalVialsPerDay().ToString();
            VialsCostPerDay = (selectedMed.VialPrice * int.Parse(TotalVialsPerDay)).ToString("c");

            GetPCAsAndBags();
            return true;
        }
    }

    public class PCAInfo
    {
        public int PCAID { get; set; }
        public int PCABagID { get; set; }
        public int PCAConcentration { get; set; }
        public string PCADrug { get; set; }
        public int PCASize { get; set; }
        public decimal PCAPrice { get; set; }

        public decimal PCAPricePerUnit { get; set; }
        public decimal PCAPricePerDay { get; set; }
        public double DaysSupply { get; set; }
    }
}
