using System.Collections.Generic;
using ImageSorter.Events;
using ImageSorter.Tests.TestUtilities;
using ImageSorter.ViewModel;
using NUnit.Framework;

namespace ImageSorter.Tests.ViewModels
{
    public class PathControlViewModelTest : ViewModelTestBase<PathControlViewModel>
    {
        [Test]
        public void Test_if_adding_a_new_source_path_raises_event()
        {
            //Arrange 
            var path = @"C:\Test\Bilder";
            var sourcePath = "";
            EventAggregator.GetEvent<NewSourcePathEvent>().Subscribe(e =>
            {
                sourcePath = e;
            });
            
            //Act
            SystemUnderTest.SourcePath = path;

            //Assert
            Assert.That(()=>sourcePath,Is.EqualTo(path));

        }

        [Test]
        public void Test_if_adding_many_new_source_paths_raises_events()
        {
            //Arrange 
            const string path = @"C:\Test\Bilder; D:\Test2\Backup;E:\Test3\Backup ;   F:\Test3\Backup\abc ";
            var expected = new List<string>
            {
                @"C:\Test\Bilder",
                @"D:\Test2\Backup",
                @"E:\Test3\Backup",
                @"F:\Test3\Backup\abc"
            };

            var sourcePath = new List<string>();
            EventAggregator.GetEvent<NewSourcePathEvent>().Subscribe(e =>
            {
                sourcePath.Add(e);
            });

            //Act
            SystemUnderTest.SourcePath = path;

            //Assert
            Assert.That(() => sourcePath, Is.EquivalentTo(expected));
        }
    }
}