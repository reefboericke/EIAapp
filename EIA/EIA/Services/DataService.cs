using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EIA.Models;

namespace SearchBarDemos.Services
{
    public static class DataService
    {
        public static List<Item> Items { get; } = new List<Item>
        {
            new Item { Id = Guid.NewGuid().ToString(), Text = "Internal Combustion Engine Car", Description="Car powered by ICE using fossil fuel." },
            new Item { Id = Guid.NewGuid().ToString(), Text = "Electric Car", Description="Car powered by electric motor using various electricity sources." }
        };

        public static List<Item> CurrentComparison { get; } = new List<Item>
        {
            new Item { Id = Guid.NewGuid().ToString(), Text = "Test", Description="Test desc"}
        };

        public static List<string> GetSearchResults(string queryString)
        {
            List<string> ItemNames = new List<string>();
            foreach (Item item in Items)
            {
                ItemNames.Add(item.Text);
            }
            var normalizedQuery = queryString?.ToLower() ?? "";
            return ItemNames.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }

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
    }
}
