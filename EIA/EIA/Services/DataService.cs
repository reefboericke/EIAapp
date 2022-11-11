using System.Collections.Generic;
using System.Linq;

namespace SearchBarDemos.Services
{
    public static class DataService
    {
        public static List<string> Items { get; } = new List<string>
        {
            "Internal Combustion Engine Car",
            "Electric Car"
        };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return Items.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }
    }
}
