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
        public static List<Item> Items { get; } = new List<Item>
        {
            new Item { Id = Guid.NewGuid().ToString(), Text = "Internal Combustion Engine Car", Description="Car powered by ICE using fossil fuel." },
            new Item { Id = Guid.NewGuid().ToString(), Text = "Electric Car", Description="Car powered by electric motor using various electricity sources." },
            new Item { Id = "test id", Text = "Item Tapped Test", Description = "Test #1000000" }
        };

        // Maintains current items being compared
        public static List<Item> CurrentComparison { get; } = new List<Item>
        {
            new Item { Id = Guid.NewGuid().ToString(), Text = "Test", Description="Test desc"}
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
                    CurrentComparison.Add(new Item { Id = item.Id, Text = item.Text, Description = item.Description });
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
    }
}
