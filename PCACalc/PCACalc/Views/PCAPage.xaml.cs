using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCACalc.Services;
using PCACalc.Models;
using PCACalc.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCAPage : ContentPage
    {
        PCAViewModel viewModel;
        private PCADataAccess dataAccess;
        public PCAPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PCAViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PCAs.Count == 0)
                viewModel.LoadPCAsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var selectedPCA = args.SelectedItem as PCA;
            if (selectedPCA == null) return;

            try
            { // Having trouble with app crashed if a medication is updated, the detail page closed then reopened
                await Navigation.PushAsync(new PCADetailPage(new PCADetailViewModel(selectedPCA)));
            }
            catch
            {
                return;
            }
            PCAsListView.SelectedItem = null;
        }

        private async void OnAddClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PCADetailPage(new PCADetailViewModel()));
            //{
            //    BarBackgroundColor = Color.FromHex("#00BBD3"),
            //    BarTextColor = Color.White
            //});
        }
    }
}