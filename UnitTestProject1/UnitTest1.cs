using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}

        [TestMethod]
        public void ConstructorInit()
        {

            var device = new Devices { model = "testmodel", repair_history = "testrepairhistory", serial_number = "testserialnumber" };
            Form1.context.Devices.Add(device);
            Form1.context.SaveChanges();

        }
        [TestMethod]
        public void ConstructorInit1()
        {

            var request = new Requests { deviceId = 4, problem = "testproblem" };
            Form1.context.Requests.Add(request);
            Form1.context.SaveChanges();

        }
        [TestMethod]
        public void ConstructorInit2()
        {

            var master = new Masters { Name = "testmaster" };
            Form1.context.Masters.Add(master);
            Form1.context.SaveChanges();
        }
        [TestMethod]
        public void ConstructorInit3()
        {
            var order = new Orders { steps = "teststeps", masterId = 5 };
            Form1.context.Orders.Add(order);
            Form1.context.SaveChanges();
        }
        [TestMethod]
        public void ConstructorInit4()
        {

            var materials_and_parts = new Parts_and_Materials { costs = 45, lefted = 55 };
            Form1.context.Parts_and_Materials.Add(materials_and_parts);
            Form1.context.SaveChanges();
        }
        [TestMethod]
        public void ConstructorInit5()
        {
            var results = new Results { Result = "testresult" };
            Form1.context.Results.Add(results);
            Form1.context.SaveChanges();

        }
    }
}
