using EIA.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EIA.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}