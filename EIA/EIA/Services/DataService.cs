using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EIA.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SearchBarDemos.Services
{
    public static class DataService
    {
        // Defines list of objects that can be searched for. In the future change this to source from external database/internet source
        // Change this to real numbers, and generate the relative values in the comparison code
        public static List<Item> Items { get; } = new List<Item>
        {
            new Item { Id = Guid.NewGuid().ToString(), 
                Text = "Ford Fiesta", 
                Description="A small car, powered by an internal combustion engine, produced by Ford Motors",
                AirQualityScore=4,
                CorporateSocialScore=5,
                EcologyScore=3,
                EmbeddedEmissionsScore=5,
                LifetimeEmissionsScore=2,
                WaterScore=8},
            new Item { Id = Guid.NewGuid().ToString(),
                Text = "Tesla Roadster",
                Description="High end electric car, produced by Tesla.",
                AirQualityScore=10,
                CorporateSocialScore=7,
                EcologyScore=2,
                EmbeddedEmissionsScore=4,
                LifetimeEmissionsScore=9,
                WaterScore=3},
            new Item { Id = Guid.NewGuid().ToString(),
                Text = "Microsoft Surface Studio",
                Description="Premium 2-in-1 Laptop.",
                AirQualityScore=10,
                CorporateSocialScore=7,
                EcologyScore=6,
                EmbeddedEmissionsScore=2,
                LifetimeEmissionsScore=8,
                WaterScore=2}
        };

        // Maintains current items being compared
        public static List<Item> CurrentComparison { get; } = new List<Item>
        {
            //Empty to begin with
        };

        // Searches the database and returns the matching items (currently just returns the name, to be fixed later)
        public static List<Item> GetSearchResults(string queryString)
        {
            List<string> ItemNames = new List<string>();
            foreach (Item item in Items)
            {
                ItemNames.Add(item.Text);
            }
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Items.Where(f => f.Text.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }

        // Finds the assigned ID of an item based on its name (currently used because the search bar only returns the name)
        public static string GetIDByName(string ItemName)
        {
            foreach (Item item in Items)
            {
                if (item.Text == ItemName)
                {
                    return item.Id;
                }
            }
            return null;
        }

        // Adds the item (by ID) to the current comparison list
        public static void AddToComparison(string ItemID)
        {
            foreach (Item item in Items)
            {
                if (item.Id == ItemID)
                {
                    CurrentComparison.Add(item);
                }
            }
        }

        public static Item GetItem(string ItemID)
        {
            foreach (Item item in Items)
            {
                if (item.Id == ItemID)
                {
                    return item;
                }
            }
            return null;
        }

        public static void ClearComparison()
        {
            CurrentComparison.Clear();
        }
    }
}
