using Xunit;

namespace CalcDriver.Tests
{
    public class SummingNumbers
    {
		[Fact]
		public void SumTwoIntegers()
		{
			using (var calculator = new Calculator())
			{
				calculator.Clear();
				Assert.Equal(0, calculator.Total);

				calculator.EnterDigit(1);
				calculator.EnterOperator(new AddOperator());
				calculator.EnterDigit(4);
				calculator.EnterDigit(3);

				Assert.Equal(1 + 43, calculator.Total);
			}
		}
	}
}
