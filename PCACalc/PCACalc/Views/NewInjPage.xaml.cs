using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCACalc.Models;
using PCACalc.Services;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewInjPage : ContentPage
    {
        public Med Medication { get; set; }
        private InjDataAccess dataaccess;
        public NewInjPage()
        {
            InitializeComponent();

            Medication = new Med();
            //{
            //    Name = null,
            //    VialSize = 0,
            //    VialConcentration = 2,
            //    VialPrice = 1.00M
            //};

            dataaccess = new InjDataAccess();

            BindingContext = this;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //Medication.Name = MedicationName.Text;
            //Medication.VialConcentration = float.Parse(VialConcentration.Value.ToString());
            //Medication.VialSize = float.Parse(VialSize.Value.ToString());
            //Medication.VialPrice = decimal.Parse(VialPrice.Value.ToString());

            MessagingCenter.Send(this, "AddItem", Medication);
            await Navigation.PopModalAsync();
        }

    }
}