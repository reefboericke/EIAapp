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

        // Contains the objects currently being compared - change to contain Item objects, and be accessible from items page
        ObservableCollection<String> currentComparison = new ObservableCollection<string>();
        public ObservableCollection<String> CurrentComparison {  get { return currentComparison; } }

        public AboutViewModel()
        {
            Title = "Compare";

            // Define commands used on the about page
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            GoToItems = new Command(OnGoToSearch);

            // For testing comparison display
            currentComparison.Add("Test");
        }

        // Defines behaviour for when the view is opened
        public void OnAppearing()
        {
            IsBusy = true;
        }

        // Navigates to search page
        async void OnGoToSearch()
        {
            await Shell.Current.GoToAsync("//ItemsPage");
        }
    }
}