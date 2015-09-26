using System.IO;
using ImageSorter.BusinessLogic;
using NUnit.Framework;
using Universial.Test;
using Universial.Test.UnityTestHelper;

namespace ImageSorter.Tests.BusinessLogic
{
    public class ImageSearcherTest : UnityTestBase<ImageSearcher>
    {
        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();
            //const string subfolder = "SubFolder";

            //CreateFileInTestDirectory("Foto1.jpg");
            //CreateFileInTestDirectory("Foto2.jpg");
            //CreateFileInTestDirectory("Foto3.jpg");
            //CreateFileInTestDirectory("KeinFoto.xml");
            //CreateFileInTestDirectory(subfolder,"Foto1.jpg");
            //CreateFileInTestDirectory(subfolder,"Foto2.jpg");
            //CreateFileInTestDirectory(subfolder,"Foto3.jpg");
            //CreateFileInTestDirectory(subfolder, "KeinFoto.xml");
        }

        [Test]
        [NeedsTestDir]
        public void Test_TestCase()
        {
            //Arrange
            CreateFileInTestDirectory("Foto1.jpg");

            //Act


            //Assert
        }
    }
}