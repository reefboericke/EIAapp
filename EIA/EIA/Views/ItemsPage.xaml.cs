using EIA.Models;
using EIA.ViewModels;
using EIA.Views;
using SearchBarDemos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EIA.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void OnSearch(object sender, EventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(e.NewTextValue);
        }
    }
}