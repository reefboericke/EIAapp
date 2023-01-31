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
        // Unused command template for opening a website
        public ICommand OpenWebCommand { get; }

        // Used to navigate to the search page
        public ICommand GoToItems { get; }

        public Command Refresh { get; }

        public AboutViewModel()
        {
            Title = "Compare";

            // Define commands used on the about page
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            GoToItems = new Command(OnGoToSearch);
            Refresh = new Command(OnRefresh);
        }

        // Defines behaviour for when the view is opened
        public void OnAppearing()
        {
            IsBusy = true;

            // iterate through data service current cmoparison and add titles from it to currentcomparison
        }

        // Navigates to search page
        async void OnGoToSearch()
        {
            await Shell.Current.GoToAsync("//ItemsPage");
        }

        public void OnRefresh()
        {
            //itemComparison.ItemsSource = DataService.CurrentComparison;
        }
    }
}