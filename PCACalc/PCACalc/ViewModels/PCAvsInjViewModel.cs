using System;
using System.Collections.Generic;
using System.Text;

using PCACalc.Models;
using PCACalc.Services;
using PCACalc.Helpers;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PCACalc.ViewModels
{
    public class PCAvsInjViewModel
    {
        public List<Med> medicationList { get; set; }
        public List<PCA> pcaList { get; set; }
        public List<PCABags> pcabaglist { get; set; }
        public ObservableCollection<PCAInfo> pcasandbags { get; set; }
        public Command LoadAssocPCAs { get; set; }
        public Med selectedMed = new Med();
        public PCA selectedPCA = new PCA();

        public PCADataAccess PCADataStore = new PCADataAccess();

        MedicationHelper medicationHelper = new MedicationHelper();
        public InjVsPCACalcs calcService = new InjVsPCACalcs();

        public PCAvsInjViewModel()
        {
            medicationList = medicationHelper.GetAllMeds();
            pcaList = PCADataStore.GetPCAList();

            pcasandbags = new ObservableCollection<PCAInfo>();

            //PCAs = new ObservableCollection<PCA>();
            //LoadAssocPCAs = new Command(async () => await LoadAssociatedPCAs());
        }

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
                    PCAPricePerUnit = Math.Round(_bag.PCAPrice / (_bag.PCASize * selectedPCA.PCAConcn),2)
                };
                pcasandbags.Add(info);
            }
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
    }
}
