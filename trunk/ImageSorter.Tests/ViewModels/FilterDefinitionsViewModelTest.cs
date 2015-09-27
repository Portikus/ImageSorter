using System.Linq;
using ImageSorter.Events;
using ImageSorter.Model;
using ImageSorter.Tests.TestUtilities;
using ImageSorter.ViewModel;
using NUnit.Framework;

namespace ImageSorter.Tests.ViewModels
{
    public class FilterDefinitionsViewModelTest : ViewModelTestBase<FilterDefinitionsViewModel>
    {
        [Test]
        public void Test_if_AddFilterDefinitionCommand_adds_a_FilterDefinition()
        {
            //Arrange
            Assert.That(() => SystemUnderTest.FilterDefinitions.Count, Is.EqualTo(0),"Precondition");

            //Act
            SystemUnderTest.AddFilterDefinitionCommand.Execute(null);

            //Assert
            Assert.That(() => SystemUnderTest.FilterDefinitions.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_if_AddFilterDefinitionCommand_raises_the_NewFilterDefinitionEvent_is_raised()
        {
            //Arrange
            var raised = false;
            EventAggregator.GetEvent<NewFilterDefinitionEvent>().Subscribe(e =>
            {
                raised = true;
            });

            //Act
            SystemUnderTest.AddFilterDefinitionCommand.Execute(null);

            //Assert
            Assert.That(() => raised, Is.True);
        }

        [Test]
        public void Test_if_FilterDefinitionEventArgs_contains_the_new_FilterDefinition()
        {
            //Arrange
            FilterDefinition filterDefinition = null;
            EventAggregator.GetEvent<NewFilterDefinitionEvent>().Subscribe(e =>
            {
                filterDefinition = e;
            });

            //Act
            SystemUnderTest.AddFilterDefinitionCommand.Execute(null);

            //Assert
            Assert.That(() => SystemUnderTest.FilterDefinitions.First(), Is.SameAs(filterDefinition));
        }
    }
}