using ImageSorter.Events.Args;
using Prism.Events;

namespace ImageSorter.Events
{
    public class NewFilterDefinitionEvent : PubSubEvent<FilterDefinitionEventArgs>
    {
    }
}
