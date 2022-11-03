using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using EIA.Views;

namespace EIA.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        public ICommand GoToItems { get; }
        public AboutViewModel()
        {
            Title = "Compare";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            GoToItems = new Command(OnGoToSearch);
        }

        async void OnGoToSearch()
        {
            await Shell.Current.GoToAsync("//ItemsPage");
        }
    }
}