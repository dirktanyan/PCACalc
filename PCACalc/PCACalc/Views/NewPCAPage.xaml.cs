using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PCACalc.Models;


namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPCAPage : ContentPage
    {
        public MedsPCA thisPCA { get; set; }
        public NewPCAPage(int medID)
        {
            InitializeComponent();

            thisPCA = new MedsPCA();
            thisPCA.FK_MedsID = medID;

            BindingContext = this;
        }

        public NewPCAPage(MedsPCA editedPCA)
        {
            InitializeComponent();

            thisPCA = editedPCA as MedsPCA;
            PCAPrice.Value = thisPCA.PCAPrice;
            PCAConcn.Value = thisPCA.PCAConcn;
            PCAUnits.SelectedItem = thisPCA.PCAUnits;
            PCASize.Value = thisPCA.PCASize;

            BindingContext = this;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            
            MessagingCenter.Send(this, "AddPCA", thisPCA);
            await Navigation.PopModalAsync();
        }

    }
}