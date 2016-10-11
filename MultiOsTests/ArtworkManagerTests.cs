using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiOsLibrary;

namespace MultiOsTests
{
    [TestClass]
    public class ArtworkManagerTests
    {
        [TestMethod]
        public void Constructor_Default_Only_Containing_Sky_Images()
        {
            // arrange
            var manager = new ArtworkManager();

            // assert
            Assert.IsTrue(ValidArtworksContainedTest(manager, "Sky"));
        }

        [TestMethod]
        public void Constructor_For_Sky_Only_Contains_Sky_Images()
        {
            // arrange
            var manager = new ArtworkManager("Sky");

            // assert
            Assert.IsTrue(ValidArtworksContainedTest(manager, "Sky"));
        }

        [TestMethod]
        public void Constructor_For_Landscape_Only_Contains_Landscape_Images()
        {
            // arrange
            var manager = new ArtworkManager("Landscape");

            // assert
            Assert.IsTrue(ValidArtworksContainedTest(manager, "Landscape"));
        }

        [TestMethod]
        public void Constructor_For_Water_Only_Contains_Water_Images()
        {
            // arrange
            var manager = new ArtworkManager("Water");

            // assert
            Assert.IsTrue(ValidArtworksContainedTest(manager, "Water"));
        }

        [TestMethod]
        public void Length_Property_Matches_Entries()
        {
            var manager = new ArtworkManager();
            manager.MoveFirst();
            var length = manager.Length;

            for (int i = 0; i < length; i++)
            {
                //last run cant move foreward
                if (i == length - 1)
                {
                    Assert.IsFalse(manager.CanMoveNext);
                }

                manager.MoveNext();
            }
            //Assert.Fail();
        }

        [TestMethod]
        public void Managers_Current_Is_First_Of_Collection()
        {
            var manager = new ArtworkManager();
            var currentStart = manager.CurrentArtwork;
            manager.MoveFirst();
            var fist = manager.CurrentArtwork;

            Assert.AreEqual(currentStart, fist);
        }

        [TestMethod]
        public void Manager_WhenJumpToIndexToBig_ShouldThrowOutOfIndexOutOfRange()
        {
            var manager = new ArtworkManager();
            var afterLast = manager.Length;

            try
            {
                manager.MoveTo(afterLast);
                Assert.Fail("Should not be able to move to Index greater than last");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, ArtworkManager.OUT_OF_RANGE_INDEX);
            }
        }

        





        private static bool ValidArtworksContainedTest(ArtworkManager manager, string testStr)
        {
            manager.MoveFirst();
            var artwork = manager.CurrentArtwork;
            var length = manager.Length;
            for (int i = 0; i < length; i++)
            {
                if (artwork.Description.ToLower().Contains(testStr.ToLower()) == false)
                {
                    return false;
                }
                
                if (manager.CanMoveNext)
                {
                    manager.MoveNext();
                    artwork = manager.CurrentArtwork;
                }
            }

            return true;
        }
        
    }
}
