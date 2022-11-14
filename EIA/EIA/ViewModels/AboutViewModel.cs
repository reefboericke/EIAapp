using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using EIA.Views;
using SearchBarDemos.Services;
using System.Collections.Generic;
using EIA.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EIA.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        public ICommand GoToItems { get; }
        public Command Refresh { get; }

        public List<Item> currentComparison = new List<Item>();
        public AboutViewModel()
        {
            Title = "Compare";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            GoToItems = new Command(OnGoToSearch);
            Refresh = new Command(OnRefresh);
            currentComparison.Add(new Item { Id = Guid.NewGuid().ToString(), Text = "test", Description = "Test desc" });
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async void OnGoToSearch()
        {
            await Shell.Current.GoToAsync("//ItemsPage");
        }

        void OnRefresh()
        {
            foreach(Item item in DataService.CurrentComparison)
            {
                currentComparison.Add(item);
            }
        }
    }
}