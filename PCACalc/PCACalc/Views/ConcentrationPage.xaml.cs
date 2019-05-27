using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCACalc;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConcentrationPage : ContentPage
    {
        public ConcentrationPage()
        {
            InitializeComponent();
        }

        private void CalcConcentration(object sender, EventArgs e)
        {
            double totalPerHour;
            double totalPerDay;
            double totalPer5Day;
            double bagVolume;
            double suggestedConcentration;

            totalPerHour = Calculations.CalcTPH(double.Parse(BasalEntry.Text), double.Parse(BolusEntry.Text), double.Parse(BolusMinEntry.Text));
            TPHEntry.Text = totalPerHour.ToString();

            totalPerDay = totalPerHour * 24;
            TPDEntry.Text = totalPerDay.ToString();

            totalPer5Day = totalPerDay * 5;
            TP5DEntry.Text = totalPer5Day.ToString();

            bagVolume = double.Parse(BagVolumeEntry.Text);
            suggestedConcentration = totalPer5Day / bagVolume;

            SugConcEntry.Text = suggestedConcentration.ToString();
        }
    }
}