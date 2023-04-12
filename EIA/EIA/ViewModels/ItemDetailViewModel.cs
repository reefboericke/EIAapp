using EIA.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using SearchBarDemos.Services;

namespace EIA.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

        public Command AddToComparison { get; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public ItemDetailViewModel(string itemID)
        {
            ItemId = itemID;

            AddToComparison = new Command(OnAddToComparison);
        }
        public void LoadItemId(string itemId)
        {
            try
            {
                var item = DataService.GetItem(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public void OnAddToComparison()
        {
            DataService.AddToComparison(itemId);
        }
    }
}
