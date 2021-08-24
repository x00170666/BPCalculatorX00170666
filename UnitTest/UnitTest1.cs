using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BPCalculatorTest_BPCategoryHigh()
        {
            BloodPressure bpcalculator = new BloodPressure();
            int S = 140;
            int D = 90;
            BPCategory expectedResult = BPCategory.High;

            bpcalculator.Systolic = S;
            bpcalculator.Diastolic = D;
            BPCategory actualResult = bpcalculator.Category;

            Assert.AreEqual(expectedResult, actualResult);



        }
        [TestMethod]
        public void BPCalculatorTest_BPCategoryIdeal()
        {
            BloodPressure bpcalculator = new BloodPressure();
            int S = 90;
            int D = 60;
            BPCategory expectedResult1 = BPCategory.Ideal;

            bpcalculator.Systolic = S;
            bpcalculator.Diastolic = D;
            BPCategory actualResult1 = bpcalculator.Category;

            Assert.AreEqual(expectedResult1, actualResult1);

        }
        [TestMethod]
        public void BPCalculatorTest_BPCategoryPrehigh()
        {
            BloodPressure bpcalculator = new BloodPressure();
            int S = 120;
            int D = 80;
            BPCategory expectedResult2 = BPCategory.PreHigh;

            bpcalculator.Systolic = S;
            bpcalculator.Diastolic = D;
            BPCategory actualResult2 = bpcalculator.Category;

            Assert.AreEqual(expectedResult2, actualResult2);

        }

        [TestMethod]
        public void BPCalculatorTest_range()
        {
            BloodPressure bpcalculator = new BloodPressure();
            int S = 10;
            int D = 10;
            BPCategory expectedResult2 = BPCategory.Low;

            bpcalculator.Systolic = S;
            bpcalculator.Diastolic = D;
            BPCategory actualResult2 = bpcalculator.Category;

            Assert.AreEqual(expectedResult2, actualResult2);

        }
    }
}
