using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        bool updatePCAMode = false;

        public MedDetailPage(MedDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
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
                viewModel.LoadAssocPCAs.Execute(null);
                PCASize.Text = "";
                PCAPrice.Text = "";
            }
        }

        private void CancelPCA_Clicked(object sender, EventArgs e)
        {
            PCASize.Text = "";
            PCAPrice.Text = "";
            updatePCAMode = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PCAs.Count == 0)
                viewModel.LoadAssocPCAs.Execute(null);

            
        }

        private void Entry_Complete(object sender, EventArgs e)
        {
            
            
        }

        private void EditPCA_Clicked(object sender, EventArgs e)
        {
            updatePCAMode = true;
            AddPCA.Text = "Update";
            
            PCASize.Text = selectedPCA.PCASize.ToString();
            PCAPrice.Text = selectedPCA.PCAPrice.ToString();

        }

        private async void DeletePCA_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Delete PCA?", string.Format("Are you sure you want to permanently delete {0}ml PCA?", selectedPCA.PCASize), "Yes", "No");
            
            if (result == true)
            {
                await viewModel.DeletePCA(selectedPCA);
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
    }
}