using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCACalc.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCACalc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class dbTableViewerPage : ContentPage
    {
        dbTableViewerViewModel viewModel;
        public dbTableViewerPage()
        {
            InitializeComponent();
            viewModel = new dbTableViewerViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.BagList.Count == 0)
                viewModel.LoadBagsCommand.Execute(null);
        }
    }
}