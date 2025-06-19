using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCFestival.DAL.Models;
using MVCFestival.Helpers;

namespace MVCFestival.UnitTest
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
         public void Calculate_Sum_capacity()
        {
            ICollection<FestivalStage> list = new List<FestivalStage>();

            FestivalStage stage_1 = new FestivalStage();
            stage_1.Capacity = 10000;

            FestivalStage stage_2 = new FestivalStage();
            stage_2.Capacity = 30000;

            list.Add(stage_1);
            list.Add(stage_2);

            // Act
            int totalCapacity = FestivalHelper.CalculateTotalCapacity(list);

            Assert.AreEqual(40000, totalCapacity); // Replace 40000 with the expected total capacity

            // Assert or do something with the totalCapacity value
        }
    }
}
