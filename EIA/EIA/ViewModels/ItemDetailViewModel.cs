﻿using EIA.Models;
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
        private float waterScore;
        private float airScore;
        private float corpSocialScore;
        private float ecologyScore;
        private float lifetimeEmissionsScore;
        private float embeddedEmissionsScore;
        private string notes;
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

        public float LifetimeEmissionsScore
        {
            get => lifetimeEmissionsScore;
            set => SetProperty(ref lifetimeEmissionsScore, value);
        }

        public float EmbeddedEmissionsScore
        {
            get => embeddedEmissionsScore;
            set => SetProperty(ref embeddedEmissionsScore, value);
        }
        public string Notes
        {
            get => notes;
            set => SetProperty(ref notes, value);
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
                LifetimeEmissionsScore = item.LifetimeEmissionsScore;
                EmbeddedEmissionsScore = item.EmbeddedEmissionsScore;
                Notes = item.Notes;
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
