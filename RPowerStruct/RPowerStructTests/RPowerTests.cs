namespace RPowerTests
{
    [TestFixture]
    public class RPowerTests
    {
        [Test]
        public void ConstructorTest()
        {
            var rpower = new RPower(42, 18);
            Assert.That(rpower.Base, Is.EqualTo(42));
            Assert.That(rpower.Exponent, Is.EqualTo(18));
        }
        [TestCase(-30)]
        [TestCase(0)]
        public void BaseSet_NegativeOrZeroValue_ArgumentException(double val)
        {
            var rpower = new RPower();
            Assert.That(() => rpower.Base = val, Throws.ArgumentException);
        }
        [TestCase(3, 10, 59049)]
        [TestCase(1, 0, 1)]
        [TestCase(3, -5, 0.00411522633744855967078189300412)]
        public void ValueTest(double _base, double exponent, double result)
        {
            var rpower = new RPower(_base, exponent);
            Assert.That(rpower.Value, Is.EqualTo(result));
        }
        [TestCase(15, 42, "15E42\"")]
        [TestCase(1, 0, "1E0\"")]
        [TestCase(15, -42, "15E-42\"")]
        public void ToStringTest(double _base, double exponent, string result)
        {
            var rpower = new RPower(_base, exponent);
            Assert.That(rpower.ToString(), Is.EqualTo(result));
        }
        [TestCase(30, 15, 30, 15, true)]
        [TestCase(30, 15, 30, 30, false)]
        [TestCase(5, 2, 25, 1, true)]
        public void Equals_TwoRPowers_ExpectedResult(
        double _base1, double exponent1, double _base2, double exponent2, bool result)
        {
            var rpower1 = new RPower(_base1, exponent1);
            var rpower2 = new RPower(_base2, exponent2);
            Assert.That(rpower1.Equals(rpower2), Is.EqualTo(result));
        }
        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var angle = new RPower();
            var smth = new object();
            Assert.That(() => angle.Equals(smth), Throws.ArgumentException);
        }
        [Test]
        public static void GetHashCodeTest()
        {
            var x = new RPower(5, 4);
            var y = new RPower(25, 2);
            var z = new RPower(5, 8);
            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }
        [Test]
        public static void ComparisonTest()
        {
            var x = new RPower(45, 18);
            var y = new RPower(45, 18);
            var z = new RPower(7, 45);
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }
        [TestCase(5, 31, 6, 34)]
        public void Multiplication_BasedIsNotEquals_ArgumentException(
        double _base1, double exponent1, double _base2, double exponent2)
        {
            var rpower1 = new RPower(_base1, exponent1);
            var rpower2 = new RPower(_base2, exponent2);
            Assert.That(() => rpower1 * rpower2, Throws.ArgumentException);
        }
        [TestCase(5, 31, 5, 34, 5, 65)]
        [TestCase(2, 0.33, 2, 51, 2, 51.33)]
        public void MultiplicationTest(
        double _base1, double exponent1, double _base2, double exponent2,
        double resultBase, double resultExponent)
        {
            var rpower1 = new RPower(_base1, exponent1);
            var rpower2 = new RPower(_base2, exponent2);
            var result = new RPower(resultBase, resultExponent);
            Assert.That(rpower1 * rpower2, Is.EqualTo(result));
        }
        [TestCase(5, 34, 6, 31)]
        public void Division_BasedIsNotEquals_ArgumentException(
        double _base1, double exponent1, double _base2, double exponent2)
        {
            var rpower1 = new RPower(_base1, exponent1);
            var rpower2 = new RPower(_base2, exponent2);
            Assert.That(() => rpower1 / rpower2, Throws.ArgumentException);
        }
        [TestCase(5, 34, 5, 31, 5, 3)]
        [TestCase(2, 51, 2, 0.33, 2, 50.67)]
        public void DivisionTest(
        double _base1, double exponent1, double _base2, double exponent2,
        double resultBase, double resultExponent)
        {
            var rpower1 = new RPower(_base1, exponent1);
            var rpower2 = new RPower(_base2, exponent2);
            var result = new RPower(resultBase, resultExponent);
            Assert.That(rpower1 / rpower2, Is.EqualTo(result));
        }
    }
}