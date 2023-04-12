using EIA.Models;
using EIA.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using SearchBarDemos.Services;

namespace EIA.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        // Defines the list of items to display
        public ObservableCollection<Item> Items { get; }

        // Retrieves items from the data service based on the query
        public Command LoadItemsCommand { get; }

        // Empties the current comparison
        public Command ClearComparison { get; }

        // Defines behaviour if an item in the list is tapped (not currently used)
        public Command<Item> ItemTapped { get; }

        // Adds an item (by ID) to the comparison
        public Command<string> AddToComparison { get; }

        // Variable storing the search bar text
        public string query;

        public ItemsViewModel()
        {
            Title = "Search";

            Items = new ObservableCollection<Item>();

            //  Command definitions
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            ClearComparison = new Command(OnClearComparison);

            AddToComparison = new Command<string>(OnAddToComparison);
        }

        // Populates the list to display based on the current query
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if (item.Text.Contains(query)){
                        Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        // Clears the current comparison
        void OnClearComparison()
        {
            DataService.ClearComparison();
        }

        // Navigates to the item details page (not in use currently)
        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        // Updates the current query based on the search bar text (when enter/search is pressed) (not in use currently)
        void OnSearch(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            query = searchBar.Text;
        }

        // Adds an item to the current comparison in the data service
        void OnAddToComparison(string ItemID)
        {
            DataService.AddToComparison("test id");

            DataService.AddToComparison(ItemID);

            DataService.CurrentComparison.Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Car", Description = "Car." });
        }
    }
}