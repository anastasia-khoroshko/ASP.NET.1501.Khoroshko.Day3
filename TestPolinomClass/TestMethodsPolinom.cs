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
            Assert.ReferenceEquals(result.ArrayFactor,expected.ArrayFactor );
        }

        [TestMethod]
        public void TestSubPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 0, 5.2F,7.1F,8.3F,4.9F });
            Polinom polinom2 = new Polinom(new float[] { 1, 2, 3, 4 });
            Polinom result = polinom1-polinom2;
            Polinom expected = new Polinom(new float[5] { 1, 3.2F, 4.1F, 4.3F,4.9F });
            Assert.ReferenceEquals(result.ArrayFactor, expected.ArrayFactor);
        }

        [TestMethod]
        public void TestMulPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 0, 5, 7, 8, 4 });
            Polinom polinom2 = new Polinom(new float[] { 1, 2, 3, 4 });
            Polinom result = polinom1 * polinom2;
            Polinom expected = new Polinom(new float[] { 0, 5, 17, 37, 61,60,44,16 });
            Assert.ReferenceEquals(result.ArrayFactor, expected.ArrayFactor);
        }

        [TestMethod]
        
        public void TestDivPolinom()
        {
            Polinom polinom1 = new Polinom(new float[] { 1, 4, 4,2});
            Polinom polinom2 = new Polinom(new float[] {1,1,1});
            Polinom result = polinom1 / polinom2;
            Polinom expected = new Polinom(new float[] { 2,2});
            Polinom modulo = new Polinom(new float[] { -1, 0, 0, 0 });
            Assert.ReferenceEquals(result.ArrayFactor, expected.ArrayFactor);
            Assert.ReferenceEquals(polinom1.ArrayFactor, modulo.ArrayFactor);
        }
    }
}
