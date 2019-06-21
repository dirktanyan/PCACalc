using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TRRxPage : ContentPage
    {
        public TRRxPage()
        {
            InitializeComponent();
        }

        private bool checkEntries()
        {
            //if (BagConcEntry.Text != null)
            //{
            //    if (BasalEntry.Text != null)
            //    {
            //        if (IntervalEntry.Text != null)
            //        {
            //            if (RemainingEntry.Text != null)
            //            {
            //                return true;
            //            }
            //            else { return false; }
            //        }
            //        else { return false; }
            //    }
            //    else { return false; }
            //}
            //else { return false; }

            return false;
        }


        private void selectUOM(object sender, ToggledEventArgs e)
        {
            if (sender.Equals(SwitchMG))
            {
                if (SwitchMG.IsToggled == true)
                {
                    SwitchMCG.IsToggled = false;
                    BagConcEntry.FormatString = "mg/hr";
                    BasalEntry.FormatString = "mg";
                    BolusEntry.FormatString = "mg";
                    MGPHLabel.Text = "MG Per Hour:";
                    MGPDLabel.Text = "MG Per Day:";
                    MGP7DLabel.Text = "MG Per 7 Days:";
                }
                else
                {
                    SwitchMCG.IsToggled = true;
                    BagConcEntry.FormatString = "mcg/hr";
                    BasalEntry.FormatString = "mcg";
                    BolusEntry.FormatString = "mcg";
                    MGPHLabel.Text = "MCG Per Hour:";
                    MGPDLabel.Text = "MCG Per Day:";
                    MGP7DLabel.Text = "MCG Per 7 Days:";
                }
            }
            else
            {
                if (SwitchMCG.IsToggled == true)
                {
                    SwitchMG.IsToggled = false;
                    BagConcEntry.FormatString = "mcg/hr";
                    BasalEntry.FormatString = "mcg";
                    BolusEntry.FormatString = "mcg";
                    MGPHLabel.Text = "MCG Per Hour:";
                    MGPDLabel.Text = "MCG Per Day:";
                    MGP7DLabel.Text = "MCG Per 7 Days:";
                }
                else
                {
                    SwitchMG.IsToggled = true;
                    BagConcEntry.FormatString = "mg/hr";
                    BasalEntry.FormatString = "mg";
                    BolusEntry.FormatString = "mg";
                    MGPHLabel.Text = "MG Per Hour:";
                    MGPDLabel.Text = "MG Per Day:";
                    MGP7DLabel.Text = "MG Per 7 Days:";
                }
            }
        }

        private void CalcRemainingTime(object sender, EventArgs e)
        {
            double unitsperhour;
            double mlperhour;

            if (checkEntries() == true)
            {
                try
                {
                    //mlperhour = double.Parse(AmtUsedEntry.Text) / double.Parse(IntervalEntry.Text);
                    //MLPH.Text = mlperhour.ToString("F2");
                    //MLPD.Text = (mlperhour * 24).ToString("F2");
                    //MLP7D.Text = (mlperhour * 24 * 7).ToString("F2");

                    //unitsperhour = (double.Parse(AmtUsedEntry.Text) * double.Parse(BagConcEntry.Text)) / double.Parse(IntervalEntry.Text);
                    //MGPH.Text = unitsperhour.ToString("F2");
                    //MGPD.Text = (unitsperhour * 24).ToString("F2");
                    //MGP7D.Text = (unitsperhour * 24 * 7).ToString("F2");

                    //HoursRemaining.Text = (double.Parse(RemainingEntry.Text) / mlperhour).ToString("F2");
                    //DaysRemaining.Text = (double.Parse(RemainingEntry.Text) / (mlperhour * 24)).ToString("F2");
                }
                catch
                {
                    // Don't do anything, just don't crash
                }
            }
        }

        private void StepDays_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            CalcRemainingTime(sender, e);
        }
    }
}