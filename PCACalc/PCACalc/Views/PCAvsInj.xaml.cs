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
    public partial class PCAvsInj : ContentPage
    {
        public PCAvsInj()
        {
            InitializeComponent();
        }

        private int VialsPerDose(double mgPerDose, double mgPerVial)
        {
           
            return (int)Math.Ceiling(mgPerVial / mgPerDose);
                        
        }
    }
}