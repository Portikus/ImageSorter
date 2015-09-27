using ImageSorter.Model;
using Prism.Events;

namespace ImageSorter.Events
{
    public class NewFilterDefinitionEvent : PubSubEvent<FilterDefinition>
    {
    }
}
