using System;
using PCACalc.ViewModels;
using PCACalc.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfNumericTextBox.XForms;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedDetailPage : ContentPage
    {
        MedDetailViewModel viewModel;
        MedsPCA selectedPCA = new MedsPCA();
        Med selectedMed = new Med();
        bool updatePCAMode = false;

        public MedDetailPage(MedDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            selectedMed = viewModel.Medication;
        }

        public MedDetailPage()
        {
            InitializeComponent();

            var med = new Med
            {
                Name = "Enter Medication Name"
            };

            BindingContext = viewModel = new MedDetailViewModel(med);
        }

        async void AddPCA_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPCAPage(selectedMed.ID))
            {
                BarBackgroundColor = Color.FromHex("#00BBD3"),
                BarTextColor = Color.White
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PCAs.Count == 0)
                viewModel.LoadAssocPCAs.Execute(null);       
        }

        private void NameUpdated(object sender, EventArgs e)
        {

            MessagingCenter.Send(this, "UpdateItem", selectedMed);

            //await viewModel.UpdateMedication(selectedMed);
        }

        private void SfNumericTextBox_Updated (object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "UpdateItem", selectedMed);
        }

        private async void EditPCA_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPCAPage(selectedPCA))
            {
                BarBackgroundColor = Color.FromHex("#00BBD3"),
                BarTextColor = Color.White
            });

        }

        private async void DeletePCA_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Delete PCA?", string.Format("Are you sure you want to permanently delete {0}ml PCA?", selectedPCA.PCASize), "Yes", "No");

            if (result == true)
            {
                await viewModel.DeletePCA(selectedPCA);
                viewModel.LoadAssocPCAs.Execute(null);
            }
        }

        private void PCAsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (PCAsListView.SelectedItem != null)
            {
                selectedPCA = PCAsListView.SelectedItem as MedsPCA;
            }

            editPCA.IsEnabled = true;
            deletePCA.IsEnabled = true;
        }

        async void OnDeleteClick(object sender, EventArgs e)
        {
            
            bool result = await DisplayAlert("Delete Medication", string.Format("Are you sure you want to delete {0}?", selectedMed.FullMedName), "Yes", "No");
            if (result == false) return;

            MessagingCenter.Send(this, "DeleteItem", selectedMed);
            await Navigation.PushAsync(new MedicationsPage(),true);

            //await viewModel.DeleteMedication(selectedMed);
        }

        private void SfNumericTextBox_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            SfNumericTextBox_Updated(sender, e);
        }
    }
}