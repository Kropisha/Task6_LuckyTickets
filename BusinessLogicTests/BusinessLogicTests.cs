using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6_LuckyTickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_LuckyTickets.Tests
{
    [TestClass()]
    public class BusinessLogicTests
    {
        [TestMethod()]
        public void InitializerTest()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();
            int left = 5;
            int right = 9;
            Ticket[] expected = new Ticket[4]{new Ticket(5), new Ticket(6),
                new Ticket(7), new Ticket(8)};

            //act
            var actual = bl.Initializer(left, right);

            //assert
            Assert.AreEqual(expected[0].Number, actual[0].Number);
            Assert.AreEqual(expected[1].Number, actual[1].Number);
            Assert.AreEqual(expected[2].Number, actual[2].Number);
            Assert.AreEqual(expected[3].Number, actual[3].Number);
        }

        [TestMethod()]
        public void SetMethodTest()
        {
            //arrange
            BusinessLogic bl = new BusinessLogic();
            var expected = Method.Moscow;
            string path = "D:/Projects/Task6_LuckyTickets/Task6_LuckyTickets/Files/Moscow.txt";
            //act
            var actual = bl.SetMethod(path);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}