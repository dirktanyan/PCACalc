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
    public partial class ConcentrationPage : ContentPage
    {
        private string unitOfMeasure = "mg";
        public ConcentrationPage()
        {
            InitializeComponent();
        }

        private void CalcConcentration(object sender, EventArgs e)
        {
            double totalPerHour;
            double totalPerDay;
            double totalPerDS;
            double bagVolume;
            double suggestedConcentration;

            totalPerHour = Calculations.CalcTPH(double.Parse(BasalEntry.Text), double.Parse(BolusEntry.Text), double.Parse(BolusMinEntry.Text));
            TPHEntry.Text = totalPerHour.ToString() + unitOfMeasure;

            totalPerDay = totalPerHour * 24;
            TPDEntry.Text = totalPerDay.ToString() + unitOfMeasure;

            totalPerDS = totalPerDay * StepDays.Value;
            TP5DEntry.Text = totalPerDS.ToString() + unitOfMeasure;

            bagVolume = double.Parse(BagVolumeEntry.Text);
            suggestedConcentration = Math.Round(totalPerDS / bagVolume, 0);


            SugConcEntry.Text = suggestedConcentration.ToString() + unitOfMeasure;
        }

        private void selectUOM(object sender, ToggledEventArgs e)
        {
            if(SwitchMG.IsToggled == true)
            {
                SwitchMCG.IsToggled = false;
                unitOfMeasure = "mg";
                BasalMeasure.Text = "mg";
                BolusMeasure.Text = "mg";
            }
            else
            {
                SwitchMCG.IsToggled = true;
                unitOfMeasure = "mcg";
                BasalMeasure.Text = "mcg";
                BolusMeasure.Text = "mcg";
            }
        }
    }
}