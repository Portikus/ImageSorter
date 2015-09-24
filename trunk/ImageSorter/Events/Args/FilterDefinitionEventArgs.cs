using System;
using ImageSorter.Model;

namespace ImageSorter.Events.Args
{
    public class FilterDefinitionEventArgs : EventArgs
    {
        public FilterDefinition NewFilterDefinition { get; }

        public FilterDefinitionEventArgs(FilterDefinition newFilterDefinition)
        {
            NewFilterDefinition = newFilterDefinition;
        }

    }
}
