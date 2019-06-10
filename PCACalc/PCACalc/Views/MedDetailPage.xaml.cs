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
            bool result = await viewModel.AddPCA(viewModel.ID, Int32.Parse(PCASize.Text), Decimal.Parse(PCAPrice.Text));
            if (result == true)
            {
                PCASize.Text = "";
                PCAPrice.Text = "";
            }
        }

        private void CancelPCA_Clicked(object sender, EventArgs e)
        {
            PCASize.Text  = "";
            PCAPrice.Text  = "";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PCAs.Count == 0)
                viewModel.LoadAssocPCAs.Execute(null);

            
        }
    }
}