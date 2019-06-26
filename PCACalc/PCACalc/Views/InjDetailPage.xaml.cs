using System;
using PCACalc.ViewModels;
using PCACalc.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfNumericTextBox.XForms;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InjDetailPage : ContentPage
    {
        InjDetailViewModel viewModel;
        Med selectedMed = new Med();

        public InjDetailPage(InjDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            selectedMed = viewModel.Medication;
        }

        public InjDetailPage()
        {
            InitializeComponent();

            var med = new Med
            {
                Name = "Enter Medication Name"
            };

            BindingContext = viewModel = new InjDetailViewModel(med);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
  
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

        async void OnDeleteClick(object sender, EventArgs e)
        {
            
            bool result = await DisplayAlert("Delete Injectable", string.Format("Are you sure you want to delete {0}?", selectedMed.FullMedName), "Yes", "No");
            if (result == false) return;

            MessagingCenter.Send(this, "DeleteItem", selectedMed);
            await Navigation.PushAsync(new InjectionsPage(),true);

            //await viewModel.DeleteMedication(selectedMed);
        }

        private void SfNumericTextBox_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            SfNumericTextBox_Updated(sender, e);
        }
    }
}