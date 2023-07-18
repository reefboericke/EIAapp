using System;
using System.Collections.Generic;

namespace EIA.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public string Notes { get; set; }

        public string Category { get; set; }
        public List<float> Scores { get; set; }
        public List<string> Colors { get; set; }
        public float LifetimeEmissionsScore { get; set; }
        public float WaterScore { get; set; }
        public float EcologyScore { get; set; }
        public float AirQualityScore { get; set; }
        public float EmbeddedEmissionsScore { get; set; }
        public float CorporateSocialScore { get; set; }
    }
}