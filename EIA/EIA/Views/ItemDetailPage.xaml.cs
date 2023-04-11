using EIA.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EIA.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(string itemID)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(itemID);
        }
    }
}