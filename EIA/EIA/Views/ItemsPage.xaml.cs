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

        // Updates the search results when search pressed
        private void OnSearch(object sender, EventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
        }

        // Updates the search results when text updated
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchResults.ItemsSource = DataService.GetSearchResults(e.NewTextValue);
        }

        // Reacts to an item in the search results being tapped
        private void searchResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Item;
            //DataService.CurrentComparison.Add(item);
            Navigation.PushAsync(new ItemDetailPage(item.Id));
        }
    }
}