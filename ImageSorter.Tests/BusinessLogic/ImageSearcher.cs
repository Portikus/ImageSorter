using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageSorter.BusinessLogic;
using NUnit.Framework;
using Universial.Test;
using Universial.Test.UnityTestHelper;

namespace ImageSorter.Tests.BusinessLogic
{
    public class ImageSearcherTest : UnityTestBase<ImageSearcher>
    {
        [Test]
        [NeedsTestDir]
        public void Test_if_ImageSearcher_finds_one_image()
        {
            //Arrange
            CreateFileInTestDirectory("Foto1.jpg");

            //Act
            var images = SystemUnderTest.GetImagesFrom(TestDirectory).ToList();

            //Assert
            Assert.That(() => images.Count, Is.EqualTo(1));
        }

        [Test]
        [NeedsTestDir]
        public void Test_if_ImageSearcher_finds_more_then_one_image()
        {
            //Arrange
            const int expected = 10;
            for (var i = 0; i < expected; i++)
            {
                CreateFileInTestDirectory($"Foto{i}.jpg");
            }

            //Act
            var images = SystemUnderTest.GetImagesFrom(TestDirectory).ToList();

            //Assert
            Assert.That(() => images.Count, Is.EqualTo(expected));
        }

        [Test]
        [NeedsTestDir]
        public void Test_if_ImageSearcher_ignores_non_images()
        {
            //Arrange
            CreateFileInTestDirectory("Foto1.jpg");
            CreateFileInTestDirectory("NoImage.xml");

            //Act
            var images = SystemUnderTest.GetImagesFrom(TestDirectory).ToList();

            //Assert
            Assert.That(() => images.Count, Is.EqualTo(1));
        }
        [Test]
        [NeedsTestDir]
        public void Test_if_ImageSearcher_finds_diffrent_image_types()
        {
            //Arrange
            var imageTypes = new List<string>
            {
                "*.jpg",
                "*.png",
                "*.bmp"
            };
            Assert.That(()=> imageTypes,Is.EquivalentTo(SystemUnderTest.SearchPatterns),"Update image endings in tests. They are not the same as in ImageSearcher");

            foreach (var imageType in imageTypes)
            {
                CreateFileInTestDirectory($"Foto{imageType.Remove(0,1)}");
            }

            //Act
            var images = SystemUnderTest.GetImagesFrom(TestDirectory).ToList();

            //Assert
            Assert.That(() => images.Count, Is.EqualTo(imageTypes.Count));
        }


        [Test]
        [NeedsTestDir]
        public void Test_if_ImageSearcher_finds_images_in_subdirectory()
        {
            //Arrange
            const string subfolder = "SubFolder";
            const int expected = 10;
            for (var i = 0; i < expected; i++)
            {
                CreateFileInTestDirectory(subfolder,$"Foto{i}.jpg");
            }
            CreateFileInTestDirectory(subfolder,"NoImage.xml");

            //Act
            var images = SystemUnderTest.GetImagesFrom(TestDirectory).ToList();

            //Assert
            Assert.That(() => images.Count, Is.EqualTo(expected));
        }
    }
}