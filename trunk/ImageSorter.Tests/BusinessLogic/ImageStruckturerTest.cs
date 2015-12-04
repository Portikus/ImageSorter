using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ImageSorter.BusinessLogic;
using ImageSorter.Model;
using NUnit.Framework;
using Universial.Test;
using Universial.Test.UnityTestHelper;

namespace ImageSorter.Tests.BusinessLogic
{
    public class ImageStruckturerTest : TestBase<IList<ExplorerItem>>
    {
        [TestCase(1, 1, 1, true)]
        [TestCase(1, 1, 2, false)]
        [TestCase(1, 30, 15, true)]
        [TestCase(1, 30, 31, false)]
        public void Test_if_moves_image_in_a_new_folder(int startDay, int endDay, int imageDay, bool expected)
        {
            //Arrange 
            var filterDefinition = new FilterDefinition { StartDate = new DateTime(2000, 10, startDay), EndDate = new DateTime(2000, 10, endDay) };
            var image = new Image("")
            {
                CreationDate = new DateTime(2000, 10, imageDay)
            };
            SystemUnderTest = new List<ExplorerItem>
            {
                image
            };

            //Act
            var result = SystemUnderTest.AccessFilterDefinition(filterDefinition);

            //Assert
            Assert.That(() => result.ExplorerItems.Contains(image), Is.EqualTo(expected));
        }
    }
}