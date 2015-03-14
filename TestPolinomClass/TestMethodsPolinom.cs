using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolinomClass;

namespace TestPolinomClass
{
    [TestClass]
    public class TestMethodsPolinom
    {
        [TestMethod]
        public void TestAddPolinom()
        {
            Polinom polinom1 = new Polinom(new double[] { 1.1, 2.2 });
            Polinom polinom2 = new Polinom(new double[] { 1, 2, 3,4 });
            Polinom result = polinom1 + polinom2;
            Polinom expected = new Polinom(new double[] { 2.1, 4.2, 3, 4 });
            Assert.ReferenceEquals(result,expected );
        }

        [TestMethod]
        public void TestSubPolinom()
        {
            Polinom polinom1 = new Polinom(new double[] { 0, 5.2, 7.1, 8.3, 4.9 });
            Polinom polinom2 = new Polinom(new double[] { 1, 2, 3, 4 });
            Polinom result = polinom1-polinom2;
            Polinom expected = new Polinom(new double[] { 1, 3.2, 4.1, 4.3, 4.9 });
            Assert.ReferenceEquals(result, expected);
        }

        [TestMethod]
        public void TestMulPolinom()
        {
            Polinom polinom1 = new Polinom(new double[] { 0, 5, 7, 8, 4 });
            Polinom polinom2 = new Polinom(new double[] { 1, 2, 3, 4 });
            Polinom result = polinom1 * polinom2;
            Polinom expected = new Polinom(new double[] { 0, 5, 17, 37, 61, 60, 44, 16 });
            Assert.ReferenceEquals(result, expected);
        }

        [TestMethod]
        
        public void TestDivPolinom()
        {
            Polinom polinom1 = new Polinom(new double[] { 1.2, 4.3, 4, 2.1 });
            Polinom polinom2 = new Polinom(new double[] { 1.5, 1.9, 1.3 });
            Polinom result = polinom1 / polinom2;
            Polinom expected = new Polinom(new double[] { 0.7159764, 1.61538458 });
            Polinom modulo = new Polinom(new double[] { 0.126035422, 0.5165681, 0.0000000162590226, 0.0000000293438234 });
            Assert.ReferenceEquals(result, expected);
            Assert.ReferenceEquals(polinom1, modulo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestDivPolinomException()
        {
            Polinom polinom1 = new Polinom(new double[] { 1, 4, 4, 0 });
            Polinom polinom2 = new Polinom(new double[] { 1, 1, 1 });
            Polinom result = polinom1 / polinom2;            
            Assert.ReferenceEquals(result, new ArithmeticException() );
        }
        
        [TestMethod]
        public void TestEqualsPolinom()
        {
            Polinom polinom1 = new Polinom(new double[] { 1, 1,1});
            Polinom polinom2 = new Polinom(new double[] { 1, 1, 1 });
            Assert.AreEqual(polinom1.Equals(polinom2), true);
        }
        [TestMethod]
        public void TestStringPolinom()
        {
            Polinom polinom1 = new Polinom(new double[] { 1, 4, 4, 2 });
            Assert.AreEqual<string>(polinom1.ToString(), "2*x^3+4*x^2+4*x^1+1*x^0");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivPolinomException2()
        {
            Polinom polinom1 = new Polinom(new double[] { 1, 1, 1 });
            Polinom polinom2 = new Polinom(new double[] { 1, 0, 1 });
            Polinom result = polinom1 / polinom2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSumPolinomException()
        {
            Polinom polinom1 = new Polinom(new double[] { 1, 1, 1 });
            Polinom polinom2 = null;
            Polinom result = polinom1 + polinom2;
        }
    }
}
