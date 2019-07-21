using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCACalc.Models;
using PCACalc.Services;
using PCACalc.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCADetailPage : ContentPage
    {
        PCADetailViewModel viewModel;
        public PCA selectedPCA = new PCA();
        public PCABags selectedPCABag = new PCABags();
        ObservableCollection<PCABags> PCABagList { get; set; } = new ObservableCollection<PCABags>();

        public PCADetailPage(PCADetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
            selectedPCA = viewModel.thisPCA;
            PCABagList = viewModel.thisPCABagList;

            //if (selectedPCA.ID == 0)
            //    ToolbarItems.RemoveAt(1);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (selectedPCA.ID != 0)
            {
                if (PCABagList.Count == 0)
                    viewModel.LoadAssocPCABags.Execute(null);
            }
        }

        //private void FieldUpdated(object sender, EventArgs e)
        //{

        //    MessagingCenter.Send(this, "UpdateItem", selectedPCA);

        //    //await viewModel.UpdateMedication(selectedMed);
        //}
        async void OnDeleteClick(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Delete PCA", string.Format("Are you sure you want to delete {0}?", selectedPCA.PCAFullName), "Yes", "No");
            if (result == false) return;

            viewModel.DeletePCA.Execute(null);

            await Navigation.PopAsync();
        }

        //async void OnSaveClick(object sender, EventArgs e)
        //{
        //    MessagingCenter.Send(this, "AddItem", selectedPCA);
        //    // await Navigation.PushAsync(new PCAPage(), true);
        //    await Navigation.PopAsync();
        //}

        private void PCABagsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (PCABagsListView.SelectedItem != null)
            {
                selectedPCABag = PCABagsListView.SelectedItem as PCABags;
            }

            editBag.IsEnabled = true;
            deleteBag.IsEnabled = true;
        }

        private void AddBag_Clicked(object sender, EventArgs e)
        {
            // Have to save the PCA before adding any bags to it
            if(selectedPCA.ID == 0)
                MessagingCenter.Send(this, "AddItem", selectedPCA);

            AddEditBag.IsVisible = true;
            selectedPCABag = new PCABags();
        }

        private void EditBag_Clicked(object sender, EventArgs e)
        {
            AddEditBag.IsVisible = true;
            BagSizeEntry.Value = selectedPCABag.PCASize;
            BagPriceEntry.Value = selectedPCABag.PCAPrice;
        }

        private async void DeleteBag_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Delete Bag?", string.Format("Are you sure you want to permanently delete {0}ml PCA?", selectedPCABag.PCASize), "Yes", "No");

            if (result == true)
            {
                await viewModel.DeletePCABag(selectedPCABag);
                viewModel.LoadAssocPCABags.Execute(null);
            }
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            selectedPCABag.PCASize = int.Parse(BagSizeEntry.Value.ToString());
            selectedPCABag.PCAPrice = decimal.Parse( BagPriceEntry.Value.ToString());
            selectedPCABag.FK_PCAID = selectedPCA.ID;

            await viewModel.AddUpdatePCABag(selectedPCABag);

            BagSizeEntry.Value = null;
            BagPriceEntry.Value = null;
            AddEditBag.IsVisible = false;

            editBag.IsEnabled = false;
            deleteBag.IsEnabled = false;
            PCABagsListView.SelectedItem = null;
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            BagSizeEntry.Value = null;
            BagPriceEntry.Value = null;
            AddEditBag.IsVisible = false;

            editBag.IsEnabled = false;
            deleteBag.IsEnabled = false;
            PCABagsListView.SelectedItem = null;

        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            viewModel.SavePCA();
        }
    }
}