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

        private int VialsPerDose(double mgPerDose, double mgPerVial)
        {
           
            return (int)Math.Ceiling(mgPerVial / mgPerDose);
                        
        }

        private bool VerifyEntryFields()
        {
            try // This will fail if either of the Entries' values are null
            {
                if (int.Parse(EntryATCHours.Value.ToString()) == 0)
                    return false;

                if (int.Parse(EntryPRNHours.Value.ToString()) == 0)
                    return false;
            }
            catch { return false; }

            return true;
        }

        private double GetATCMGPerHour()
        {
            try
            {
                return Calculations.MGPerHour(double.Parse(EntryATCmg.Value.ToString()), double.Parse(EntryATCHours.Value.ToString()));
            }
            catch
            {
                return 0;
            }
        }

        private double GetPRNMGPerHour()
        {
            try
            {
                return Calculations.MGPerHour(double.Parse(EntryPRNmg.Value.ToString()), double.Parse(EntryPRNHours.Value.ToString()));
            }
            catch
            {
                return 0;
            }
        }

        private void MedicationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            viewModel.selectedMed = MedicationPicker.SelectedItem as Med;
            viewModel.LoadAssocPCAs.Execute(null);
        }

        private void PCAsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //nothing for now
        }

        private void RunCalcs(object sender, ValueEventArgs e)
        {
            bool result = VerifyEntryFields();
            if (result == false)
                return;

            if (sender == EntryATCHours || sender == EntryATCmg)          
                LabelATCMGPerHour.Text = GetATCMGPerHour().ToString();

            if (sender == EntryPRNHours || sender == EntryPRNmg)
                LabelPRNMGPerHour.Text = GetPRNMGPerHour().ToString();
        }

    }
}