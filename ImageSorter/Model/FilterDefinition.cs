using System;

namespace ImageSorter.Model
{
    public class FilterDefinition
    {
        public string Name { get; set; } = "FilterName";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
