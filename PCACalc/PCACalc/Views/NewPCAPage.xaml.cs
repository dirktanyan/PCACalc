using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PCACalc.Models;
using PCACalc.Services;


namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPCAPage : ContentPage
    {
        public PCA thisPCA { get; set; }
        public PCABags thisPCASizes { get; set; }
        public NewPCAPage()
        {
            InitializeComponent();

            thisPCA = new PCA();
            thisPCASizes = new PCABags();

            BindingContext = this;
        }

        public NewPCAPage(PCA editedPCA)
        {
            InitializeComponent();

            thisPCA = editedPCA as PCA;
            PCAConcn.Value = thisPCA.PCAConcn;

            PCAUnits.SelectedItem = thisPCA.PCAUnits;

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

        private void AddPCA_Clicked(object sender, EventArgs e)
        {

        }

        private void EditPCA_Clicked(object sender, EventArgs e)
        {

        }

        private void DeletePCA_Clicked(object sender, EventArgs e)
        {

        }

        private void PCASizesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}