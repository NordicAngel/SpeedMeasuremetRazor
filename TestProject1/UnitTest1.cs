//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SpeedMeasuremetRazor.Models;
//using SpeedMeasuremetRazor.Services;


//namespace TestProject1
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void AddLocation()
//        {
//            //arrange
//            var locs = new LocationRepo();

//            //act
//            locs.AddLocation(new Location(1, "street", 50, Zone.By));
//            locs.AddLocation(new Location(2, "road", 50, Zone.By));

//            //assert
//            Assert.AreEqual(2, locs.GetAllLocations().Count);

//        }
//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void AddTwoLocationsWithSameId()
//        {
//            //arrange
//            var locs = new LocationRepo();

//            //act
//            locs.AddLocation(new Location(1, "street", 50, Zone.By));
//            locs.AddLocation(new Location(1, "road", 50, Zone.By));

//            //assert

//            //    try
//            //{
//            //    Assert.Fail();
//            //}
//            //catch (ArgumentException e)
//            //{
//            //}
//        }

//        [TestMethod]
//        public void GetLocationIdIsSame()
//        {
//            //arrange
//            var locs = new LocationRepo();

//            //act
//            locs.AddLocation(new Location(1, "street", 50, Zone.By));
//            locs.AddLocation(new Location(2, "street", 50, Zone.By));
//            locs.AddLocation(new Location(3, "street", 50, Zone.By));
//            locs.AddLocation(new Location(4, "street", 50, Zone.By));
//            locs.AddLocation(new Location(5, "street", 50, Zone.By));
//            int i = locs.GetLocation(3).Id;

//            //assert
//            Assert.AreEqual(3, i);
//        }
//    }
//}
