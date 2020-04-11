using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashJoinInterface;
using System.IO;

namespace UnitTestHashJoinAlg
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //Description: a1-b1
        public void TestMethod1()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST1.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-1.csv", "R2-INSTANCE-1.csv", "a1", "b1");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a1-b2
        public void TestMethod2()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST2.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-1.csv", "R2-INSTANCE-1.csv", "a1", "b2");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a1-b3
        public void TestMethod3()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST3.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-1.csv", "R2-INSTANCE-1.csv", "a1", "b3");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a1-b4
        public void TestMethod4()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST4.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-1.csv", "R2-INSTANCE-1.csv", "a1", "b4");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a2-b1
        public void TestMethod5()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST5.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-2.csv", "R2-INSTANCE-2.csv", "a2", "b1");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a2-b2
        public void TestMethod6()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST6.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-2.csv", "R2-INSTANCE-2.csv", "a2", "b2");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a2-b3
        public void TestMethod7()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST7.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-2.csv", "R2-INSTANCE-2.csv", "a2", "b3");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a2-b4
        public void TestMethod8()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST8.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-2.csv", "R2-INSTANCE-2.csv", "a2", "b4");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a3-b1
        public void TestMethod9()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST9.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-3.csv", "R2-INSTANCE-3.csv", "a3", "b1");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a3-b2
        public void TestMethod10()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST10.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-3.csv", "R2-INSTANCE-3.csv", "a3", "b2");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a3-a3
        public void TestMethod11()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST11.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-3.csv", "R2-INSTANCE-3.csv", "a3", "b3");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        //Description: a3-b4
        public void TestMethod12()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST12.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-3.csv", "R2-INSTANCE-3.csv", "a3", "b4");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }

        [TestMethod]
        public void TestMethod13()
        {
            //Arrange
            TableManager tableManager = new TableManager("../../../R1-INSTANCES", "../../../R2-INSTANCES");
            string expectedResult = File.ReadAllText("../../../UNIT-TESTS-FILES/EXPECTED-RESULT-TEST13.csv");
            string joinResult;

            //Act
            joinResult = tableManager.Join("R1-INSTANCE-4.csv", "R2-INSTANCE-4.csv", "a1", "b1");

            //Assert
            Assert.AreEqual(expectedResult, joinResult);
        }
    }
}
