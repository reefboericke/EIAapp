using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        // 5 step color scale: Green: 33FF33 (10-9), CCFFCC (8-7), FFFF33 (6-5), FF9933 (4-3), FF3333 (2-1): Red
        // Scores : {Air Pollution, Corporate ESG, Ecological Impact, Embedded Emissions, Lifetime Emissions, Water Pollution}
        public static List<Item> Items { get; } = new List<Item>
        {
            new Item { Id = Guid.NewGuid().ToString(),
                Text = "Ford Fiesta",
                Description="A small car, powered by an internal combustion engine, produced by Ford Motors",
                Scores = new List<float>{5,2},
                Colors = new List<string>{"#FFFF33", "#FF3333"},
                EmbeddedEmissionsScore=5,
                LifetimeEmissionsScore=2,
                Notes="1. CO2 per km is xxx and average total usage is yyy",
                Category="Car"},
            new Item { Id = Guid.NewGuid().ToString(),
                Text = "Tesla Roadster",
                Description="High end electric car, produced by Tesla.",
                Scores = new List<float>{4,9},
                Colors = new List<string>{"#FF9933", "#33FF33"},
                EmbeddedEmissionsScore=4,
                LifetimeEmissionsScore=9,
                Notes="1. CO2 per km depends on how the electricity was generated; we have assumed US generation proportions \n 2. The rare earth metals that are" +
                " required for the batteries have serious impacts on water supplies and local ecosystems \n 3. The CEO Elon Musk is a controversial figure" +
                " politically and appears to support groups who are against fighting climate change",
                Category="Car"},
            new Item { Id = Guid.NewGuid().ToString(),
                Text = "Microsoft Surface Studio",
                Description="Premium 2-in-1 Laptop.",
                Scores = new List<float>{2,8},
                Colors = new List<string>{"#FF3333", "#CCFFCC" },
                EmbeddedEmissionsScore=2,
                LifetimeEmissionsScore=8,
                Notes="1. Ongoing emissions depend on how the electricty was generated, we have assumed US generation proportions \n 2. Materials required for" +
                " batteries and chips in this device impact water supplies and local ecosystems",
                Category="Electronics"},
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
