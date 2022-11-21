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
using System.Collections.ObjectModel;

namespace EIA.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        public ICommand GoToItems { get; }

        ObservableCollection<String> currentComparison = new ObservableCollection<string>();
        public ObservableCollection<String> CurrentComparison {  get { return currentComparison; } }

        public AboutViewModel()
        {
            Title = "Compare";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            GoToItems = new Command(OnGoToSearch);
            currentComparison.Add("Test");
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async void OnGoToSearch()
        {
            await Shell.Current.GoToAsync("//ItemsPage");
        }
    }
}