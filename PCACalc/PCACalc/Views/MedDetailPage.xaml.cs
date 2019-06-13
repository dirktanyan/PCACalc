using System;
using PCACalc.ViewModels;
using PCACalc.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            bool result = false;

            if (PCASize.Text == null)
                return;
            if (PCAPrice.Text == null)
                return;

            if (updatePCAMode == false)
            {
                result = await viewModel.AddPCA(viewModel.ID, Int32.Parse(PCASize.Text), Decimal.Parse(PCAPrice.Text));
            }
            else
            {
                selectedPCA.PCAPrice = Decimal.Parse(PCAPrice.Text);
                selectedPCA.PCASize = int.Parse(PCASize.Text);
                result = await viewModel.AddPCA(selectedPCA.FK_MedsID, selectedPCA.PCASize, selectedPCA.PCAPrice, selectedPCA.ID);
            }

            if (result == true)
            {
                updatePCAMode = false;
                AddPCA.Text = "Add";
                LabelAddPCA.Text = "Add PCA";
                viewModel.LoadAssocPCAs.Execute(null);
                PCASize.Text = "";
                PCAPrice.Text = "";
            }
        }

        private void CancelPCA_Clicked(object sender, EventArgs e)
        {
            PCASize.Text = "";
            PCAPrice.Text = "";
            AddPCA.Text = "Add";
            LabelAddPCA.Text = "Add PCA";
            updatePCAMode = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PCAs.Count == 0)
                viewModel.LoadAssocPCAs.Execute(null);       
        }

        private async void ConcentrationUpdated(object sender, EventArgs e)
        {
            Entry thisEntry = sender as Entry;
            selectedMed.VialConcentration = float.Parse(thisEntry.Text);
            await viewModel.UpdateMedication(selectedMed);
        }

        private async void VialSizeUpdated(object sender, EventArgs e)
        {
            Entry thisEntry = sender as Entry;
            selectedMed.VialSize = float.Parse(thisEntry.Text);
            await viewModel.UpdateMedication(selectedMed);
        }

        private async void VialPriceUpdated(object sender, EventArgs e)
        {
            Entry thisEntry = sender as Entry;
            selectedMed.VialPrice = decimal.Parse(thisEntry.Text);
            await viewModel.UpdateMedication(selectedMed);
        }

        private void EditPCA_Clicked(object sender, EventArgs e)
        {
            updatePCAMode = true;
            AddPCA.Text = "Update";
            LabelAddPCA.Text = "Update PCA";
            
            PCASize.Text = selectedPCA.PCASize.ToString();
            PCAPrice.Text = selectedPCA.PCAPrice.ToString();
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
    }
}