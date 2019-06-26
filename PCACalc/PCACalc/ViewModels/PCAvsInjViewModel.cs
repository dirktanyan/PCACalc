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
        public ObservableCollection<PCA> PCAs { get; set; }
        public Command LoadAssocPCAs { get; set; }
        public Med selectedMed = new Med();
        public PCADataAccess PCADataStore = new PCADataAccess();

        MedicationHelper medicationHelper = new MedicationHelper();

        public PCAvsInjViewModel()
        {
            medicationList = medicationHelper.GetAllMeds();

            //PCAs = new ObservableCollection<PCA>();
            //LoadAssocPCAs = new Command(async () => await LoadAssociatedPCAs());
        }

        
    }
}
