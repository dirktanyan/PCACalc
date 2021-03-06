﻿using System;
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
    public partial class InjectionsPage : ContentPage
    {
        InjViewModel viewModel;

        private InjDataAccess dataAccess;
        public InjectionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new InjViewModel();
        }


        // An event that is raised when the page is shown
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Medications.Count == 0)
                viewModel.LoadMedsCommand.Execute(null);

            // The instance of MedsDataAccess
            // is the data binding source
            //this.BindingContext = this.dataAccess;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Med;
            if (item == null) return;

            try { // Having trouble with app crashed if a medication is updated, the detail page closed then reopened
            await Navigation.PushAsync(new InjDetailPage(new ViewModels.InjDetailViewModel(item)));
            }
            catch
            {
                return;
            }
            MedsListView.SelectedItem = null;
        }

        async void OnAddClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewInjPage())
            //{
            //    BarBackgroundColor = Color.FromHex("#00BBD3"),
            //    BarTextColor = Color.White 
            //}) ;
            await Navigation.PushAsync(new InjDetailPage(new ViewModels.InjDetailViewModel()));
            
        }

        
    }
}