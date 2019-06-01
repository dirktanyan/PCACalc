using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCACalc;
using System.Diagnostics;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TRVolumePage : ContentPage
    {
        private string unitOfMeasure = "mg";
        public TRVolumePage()
        {
            InitializeComponent();
        }

        private bool checkEntries()
        {
            if(BagConcEntry.Text != null)
            {
                if(AmtUsedEntry.Text != null)
                {
                    if(IntervalEntry.Text != null)
                    {
                        if(RemainingEntry.Text != null)
                        {
                            return true;
                        } else { return false; }
                    } else { return false; }
                } else { return false; }
            } else { return false; }
        }
        

        private void selectUOM(object sender, ToggledEventArgs e)
        {
            if (sender.Equals(SwitchMG))
            {
                if (SwitchMG.IsToggled == true)
                {
                    SwitchMCG.IsToggled = false;
                    unitOfMeasure = "mg";
                    BagUOM.Text = "mg/ml";
                    MGPHLabel.Text = "MG Per Hour:";
                    MGPDLabel.Text = "MG Per Day:";
                    MGP7DLabel.Text = "MG Per 7 Days:";
                }
                else
                {
                    SwitchMCG.IsToggled = true;
                    unitOfMeasure = "mcg";
                    BagUOM.Text = "mcg/ml";
                    MGPHLabel.Text = "MCG Per Hour:";
                    MGPDLabel.Text = "MCG Per Day:";
                    MGP7DLabel.Text = "MCG Per 7 Days:";
                }
            }
            else
            {
                if(SwitchMCG.IsToggled == true)
                {
                    SwitchMG.IsToggled = false;
                    unitOfMeasure = "mcg";
                    BagUOM.Text = "mcg/ml";
                    MGPHLabel.Text = "MCG Per Hour:";
                    MGPDLabel.Text = "MCG Per Day:";
                    MGP7DLabel.Text = "MCG Per 7 Days:";
                }
                else
                {
                    SwitchMG.IsToggled = true;
                    unitOfMeasure = "mg";
                    BagUOM.Text = "mg/ml";
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
                    mlperhour = double.Parse(AmtUsedEntry.Text) / double.Parse(IntervalEntry.Text);
                    MLPH.Text = mlperhour.ToString();
                    MLPD.Text = (mlperhour * 24).ToString();
                    MLP7D.Text = (mlperhour * 24 * 7).ToString();

                    unitsperhour = (double.Parse(AmtUsedEntry.Text) * double.Parse(BagConcEntry.Text)) / double.Parse(IntervalEntry.Text);
                    MGPH.Text = unitsperhour.ToString();
                    MGPD.Text = (unitsperhour * 24).ToString();
                    MGP7D.Text = (unitsperhour * 24 * 7).ToString();

                    HoursRemaining.Text = (double.Parse(RemainingEntry.Text) / mlperhour).ToString();
                    DaysRemaining.Text = (double.Parse(RemainingEntry.Text) / (mlperhour * 24)).ToString();
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