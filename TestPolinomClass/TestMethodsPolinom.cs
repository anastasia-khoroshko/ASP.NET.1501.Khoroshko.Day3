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
            Polinom polinom1 = new Polinom(new float[] { 1.1F, 2.2F });
            Polinom polinom2 = new Polinom(new float[] { 1, 2, 3,4 });
            Polinom result = polinom1 + polinom2;
            Polinom expected = new Polinom(new float[4] { 2.1F, 4.2F, 3, 4 });
            Assert.ReferenceEquals(result,expected );
        }

        [TestMethod]
        public void TestSubPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 0, 5.2F,7.1F,8.3F,4.9F });
            Polinom polinom2 = new Polinom(new float[] { 1, 2, 3, 4 });
            Polinom result = polinom1-polinom2;
            Polinom expected = new Polinom(new float[5] { 1, 3.2F, 4.1F, 4.3F,4.9F });
            Assert.ReferenceEquals(result, expected);
        }

        [TestMethod]
        public void TestMulPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 0, 5, 7, 8, 4 });
            Polinom polinom2 = new Polinom(new float[] { 1, 2, 3, 4 });
            Polinom result = polinom1 * polinom2;
            Polinom expected = new Polinom(new float[] { 0, 5, 17, 37, 61,60,44,16 });
            Assert.ReferenceEquals(result, expected);
        }

        [TestMethod]
        
        public void TestDivPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 1.2F, 4.3F, 4,2.1F});
            Polinom polinom2 = new Polinom(new float[] {1.5F,1.9F,1.3F});
            Polinom result = polinom1 / polinom2;
            Polinom expected = new Polinom(new float[] { 0.7159764F, 1.61538458F });
            Polinom modulo = new Polinom(new float[] { 0.126035422F, 0.5165681F, 0.0000000162590226F, 0.0000000293438234F });
            Assert.ReferenceEquals(result, expected);
            Assert.ReferenceEquals(polinom1, modulo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestDivPolinomException()
        {
            Polinom polinom1 = new Polinom(new float[] { 1, 4, 4, 0 });
            Polinom polinom2 = new Polinom(new float[] { 1, 1, 1 });
            Polinom result = polinom1 / polinom2;            
            Assert.ReferenceEquals(result, new ArithmeticException() );
        }
        
        [TestMethod]
        public void TestEqualsPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 1, 4, 4, 0 });
            Polinom polinom2 = new Polinom(new float[] { 1, 1, 1 });
            Assert.AreEqual(polinom1.Equals(polinom2), false);
        }
        [TestMethod]
        public void TestStringPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 1, 4, 4, 0 });
                polinom1[3] = 2;
                Assert.AreEqual<string>(polinom1.ToString(), "2*x^3+4*x^2+4*x^1+1*x^0");
        }

    }
}
