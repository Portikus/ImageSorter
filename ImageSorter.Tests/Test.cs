using NUnit.Framework;
using Universial.Test;

namespace ImageSorter.Tests
{
    public class Test : TestBase
    {
        [Test]
        public void Tests()
        {
            Assert.That(()=>true,Is.True);
        }
    }
}
