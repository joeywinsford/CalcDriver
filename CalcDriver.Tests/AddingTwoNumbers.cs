using System;
using Xunit;

namespace CalcDriver.Tests
{
	public class SummingNumbers : IDisposable
	{
		private readonly Calculator _calculator;

		public SummingNumbers()
		{
			_calculator = new Calculator();

			_calculator.Clear();
			Assert.Equal(0, _calculator.Total);
		}

		[Fact]
		public void SumTwoIntegers()
		{
			_calculator.EnterDigit(1);
			_calculator.EnterOperator(new AddOperator());
			_calculator.EnterDigit(4);
			_calculator.EnterDigit(3);

			Assert.Equal(1 + 43, _calculator.Total);
		}

		public void Dispose()
		{
			_calculator.Dispose();
		}
	}
}
