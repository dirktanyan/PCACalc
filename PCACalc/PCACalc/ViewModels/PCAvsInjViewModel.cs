using System;
using System.Collections.Generic;
using System.Text;

using PCACalc.Models;
using PCACalc.Services;
using PCACalc.Helpers;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PCACalc.ViewModels
{
    public class PCAvsInjViewModel
    {
        public List<Med> medicationList { get; set; }
        public ObservableCollection<MedsPCA> PCAs { get; set; }
        public Command LoadAssocPCAs { get; set; }
        public Med selectedMed = new Med();
        public PCADataAccess PCADataStore = new PCADataAccess();

        MedicationHelper medicationHelper = new MedicationHelper();

        public PCAvsInjViewModel()
        {
            medicationList = medicationHelper.GetAllMeds();

            PCAs = new ObservableCollection<MedsPCA>();
            LoadAssocPCAs = new Command(async () => await LoadAssociatedPCAs());
        }

        async Task LoadAssociatedPCAs()
        {
            try
            {
                PCAs.Clear();
                var _pcas = await PCADataStore.GetMedsPCAAsync(selectedMed.ID);
                foreach (var _pca in _pcas)
                {
                    PCAs.Add(_pca);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
