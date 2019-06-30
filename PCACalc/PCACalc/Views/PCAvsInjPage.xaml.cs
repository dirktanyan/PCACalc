using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfNumericTextBox.XForms;

using PCACalc.ViewModels;
using PCACalc.Models;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCAvsInjPage : ContentPage
    {
        PCAvsInjViewModel viewModel;
        public PCAvsInjPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PCAvsInjViewModel();
        }

        private bool VerifyEntryFields()
        {
            try // This will fail if either of the Entries' values are null
            {
                if (int.Parse(EntryATCHours.Value.ToString()) == 0)
                    return false;
                //if (double.Parse(EntryATCmg.Value.ToString()) == 0)
                //    return false;
                if (int.Parse(EntryPRNHours.Value.ToString()) == 0)
                    return false;
                //if (double.Parse(EntryPRNmg.Value.ToString()) == 0)
                //    return false;
            }
            catch { return false; }

            return true;
        }

        private void MedicationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            viewModel.selectedMed = MedicationPicker.SelectedItem as Med;
            //viewModel.LoadAssocPCAs.Execute(null);
        }

        private void PCAsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // nothing for now

        }

        private void RunCalcs(object sender, ValueEventArgs e)
        {
            bool result = VerifyEntryFields();
            if (result == false)
                return;

            if (MedicationPicker.SelectedItem == null)
            {
                DisplayAlert("Select an Injectable", "Please select a medication in order to run the calculations.","OK");
                return;
            }

            viewModel.calcService = new Services.InjVsPCACalcs
            {
                AtcUnits = double.Parse(EntryATCmg.Value.ToString()),
                AtcInterval = int.Parse(EntryATCHours.Value.ToString()),
                PrnUnits = double.Parse(EntryPRNmg.Value.ToString()),
                PrnInterval = int.Parse(EntryPRNHours.Value.ToString()),
                VialConcentration = viewModel.selectedMed.VialConcentration,
                VialPrice = viewModel.selectedMed.VialPrice
            };
            
            LabelATCMGPerHour.Text = viewModel.calcService.MGPerHour(false).ToString();
            int atcVPD = viewModel.calcService.VialsPerDay(false);
            LabelATCVialsPerDay.Text = atcVPD.ToString();
            LabelATCCostPerDay.Text = (atcVPD * viewModel.selectedMed.VialPrice).ToString("c");

            LabelPRNMGPerHour.Text = viewModel.calcService.MGPerHour(true).ToString();
            int prnVPD = viewModel.calcService.VialsPerDay(true);
            LabelPRNVialsPerDay.Text = prnVPD.ToString();
            LabelPRNCostPerDay.Text = (prnVPD * viewModel.selectedMed.VialPrice).ToString("c");

            LabelUnitsPerDay.Text = viewModel.calcService.UnitsPerDay().ToString();

        }
        private async void PCAPicker_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            viewModel.selectedPCA = PCAPicker.SelectedItem as PCA;
            await viewModel.GetPCAsAndBags();
        }
    }
}