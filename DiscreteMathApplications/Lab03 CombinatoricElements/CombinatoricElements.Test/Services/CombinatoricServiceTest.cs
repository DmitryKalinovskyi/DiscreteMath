using Microsoft.VisualStudio.TestTools.UnitTesting;
using CombinatoricElements.Services;

namespace CombinatoricElements.Test.Services
{
    [TestClass]
    public class CombinatoricServiceTest
    {
        private ICombinatoricsService _service;

        public CombinatoricServiceTest() 
        {
            _service = new CombinatoricsService();
        }

        public CombinatoricServiceTest(ICombinatoricsService service)
        {
            _service = service;
        }

        [TestMethod]
        public void Permutations()
        {

            Assert.AreEqual(_service.Permutations(1), 1);
            Assert.AreEqual(_service.Permutations(2), 2);
            Assert.AreEqual(_service.Permutations(3), 6);
            Assert.AreEqual(_service.Permutations(4), 24);
            Assert.AreEqual(_service.Permutations(5), 120);

            Assert.AreEqual(_service.Permutations(10), 3628800);
        }

        [TestMethod]
        public void FactorialRuntime()
        {
            Console.WriteLine(_service.Permutations(100_000_0000));
        }

        [TestMethod]
        public void Permutations_nm()
        {
            Assert.AreEqual(_service.Permutations_nm(1, 1), 1);
            Assert.AreEqual(_service.Permutations_nm(2, 1), 2);
            Assert.AreEqual(_service.Permutations_nm(2, 2), 2);
            Assert.AreEqual(_service.Permutations_nm(3, 1), 3);
            Assert.AreEqual(_service.Permutations_nm(3, 2), 6);
        }

        [TestMethod]
        public void Permutations_nm_Repeats()
        {
            Assert.AreEqual(_service.Permutations_nm_Repeats(1, 1), 1);
            Assert.AreEqual(_service.Permutations_nm_Repeats(2, 1), 2);
            Assert.AreEqual(_service.Permutations_nm_Repeats(3, 2), 9);
            Assert.AreEqual(_service.Permutations_nm_Repeats(3, 1), 3);

            // Time Limit test
            Assert.AreEqual(_service.Permutations_nm_Repeats(2, 1024), 78733280);
        }

        [TestMethod]
        public void Combinations_nm()
        {
            Assert.AreEqual(_service.Combinations_nm(1, 1), 1);
            Assert.AreEqual(_service.Combinations_nm(2, 1), 2);
            Assert.AreEqual(_service.Combinations_nm(3, 2), 3);
            Assert.AreEqual(_service.Combinations_nm(4, 2), 6);
            Assert.AreEqual(_service.Combinations_nm(5, 3), 10);


            Assert.AreEqual(_service.Combinations_nm(6, 3), 20);
            Assert.AreEqual(_service.Combinations_nm(11, 6), 462);
        }

        [TestMethod]
        public void Combinations_nm_Repeats()
        {
            Assert.AreEqual(_service.Combinations_nm_Repeats(1, 1), 1);
            Assert.AreEqual(_service.Combinations_nm_Repeats(2, 1), 2);
            Assert.AreEqual(_service.Combinations_nm_Repeats(3, 2), 6);
            Assert.AreEqual(_service.Combinations_nm_Repeats(4, 2), 10);
        }

        [TestMethod]
        public void Permutations_pieces()
        {


            Assert.AreEqual(_service.Permutations(12, 2, 2), 39916800L * 3 % CombinatoricsService.MODULO);
        }
    }
}
