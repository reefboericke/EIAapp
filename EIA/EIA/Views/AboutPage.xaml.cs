using EIA.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SearchBarDemos.Services;

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
            itemComparison.ItemsSource = DataService.CurrentComparison;
        }
    }
}