using System.Collections.Generic;
using System.Linq;
using ImageSorter.Contracts;
using ImageSorter.Events;
using ImageSorter.Model;
using ImageSorter.Tests.TestUtilities;
using ImageSorter.ViewModel;
using Microsoft.Practices.Unity;
using NSubstitute;
using NUnit.Framework;
using Universial.Core.Extensions;

namespace ImageSorter.Tests.ViewModels
{
    public class StrucktureControlViewModelTest : ViewModelTestBase<StrucktureControlViewModel>
    {
        protected override void SetUp()
        {
            base.SetUp();
            Container.Resolve<IImageSearcher>().GetImagesFrom("").ReturnsForAnyArgs(new List<Image>
            {
                new Image("Foto1.jpg"),
                new Image("Foto2.jpg"),
                new Image("Foto3.jpg")
            });
        }

        [Test]
        public void Test_if_recieving_a_NewSourcePath_event_it_will_add_the_images_found_under_the_path_to_the_ExplorerItems_list()
        {
            //Arrange 
            Assert.That(() => SystemUnderTest.ExplorerItems.Any(x => x.Name.Equals(StrucktureControlViewModel.UnsortedFolderName)), Is.True,"Precondition");

            //Act
            EventAggregator.GetEvent<NewSourcePathEvent>().Publish("");

            //Assert
            Assert.That(()=>SystemUnderTest.ExplorerItems.FirstOrDefault(x=>x.Name.Equals(StrucktureControlViewModel.UnsortedFolderName)).CastToType<Folder>().ExplorerItems.Count,Is.EqualTo(3));
        }
    }
}