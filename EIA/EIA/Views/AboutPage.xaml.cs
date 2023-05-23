using EIA.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SearchBarDemos.Services;
using System.Linq;

namespace EIA.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _viewModel;
        public AboutPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AboutViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            //DataService.AddToComparison(DataService.GetIDByName("Electric Car"));
            itemComparison.ItemsSource = DataService.CurrentComparison;
            itemDetails.ItemsSource = DataService.CurrentComparison;
        }

        private void itemComparison_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            itemComparison.SelectedItem = null;
        }
    }
}