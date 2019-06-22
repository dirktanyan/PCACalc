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
    public partial class TRVolumePage : ContentPage
    {
        public Helpers.TRVolumeHelper calchelper { get; set; }
        public TRVolumePage()
        {
            InitializeComponent();

            calchelper = new Helpers.TRVolumeHelper();
            BindingContext = this;
        }      

        private void selectUOM(object sender, ToggledEventArgs e)
        {
            if (sender.Equals(SwitchMG))
            {
                if (SwitchMG.IsToggled == true)
                {
                    SwitchMCG.IsToggled = false;
                    BagConcEntry.FormatString = "mg/ml";
                    MGPHLabel.Text = "MG Per Hour:";
                    MGPDLabel.Text = "MG Per Day:";
                    MGP7DLabel.Text = "MG Per 7 Days:";
                }
                else
                {
                    SwitchMCG.IsToggled = true;
                    BagConcEntry.FormatString = "mcg/ml";
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
                    BagConcEntry.FormatString = "mcg/ml";
                    MGPHLabel.Text = "MCG Per Hour:";
                    MGPDLabel.Text = "MCG Per Day:";
                    MGP7DLabel.Text = "MCG Per 7 Days:";
                }
                else
                {
                    SwitchMG.IsToggled = true;
                    BagConcEntry.FormatString = "mg/ml";
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

            mlperhour = calchelper.MLPerHour();
            MLPH.Text = mlperhour.ToString("F2");
            MLPD.Text = (mlperhour * 24).ToString("F2");
            MLP7D.Text = (mlperhour * 24 * 7).ToString("F2");

            unitsperhour = calchelper.UnitsPerHour();
            MGPH.Text = unitsperhour.ToString("F2");
            MGPD.Text = (unitsperhour * 24).ToString("F2");
            MGP7D.Text = (unitsperhour * 24 * 7).ToString("F2");

            if(calchelper.VolumeRemaining != 0)
                HoursRemaining.Text = (calchelper.VolumeRemaining / mlperhour).ToString("F2");

            if(calchelper.VolumeRemaining != 0)
                DaysRemaining.Text = (calchelper.VolumeRemaining/ (mlperhour * 24)).ToString("F2");
        }

        private void Entry_FocusChanged(object sender, Syncfusion.SfNumericTextBox.XForms.FocusEventArgs e)
        {
            CalcRemainingTime(sender, e);
        }

    }
}