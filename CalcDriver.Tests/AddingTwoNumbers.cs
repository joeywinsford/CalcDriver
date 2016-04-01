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

		[Fact]
		public void SumAnIntegerAndADecimal()
		{
			_calculator.EnterDigit(2);
			_calculator.EnterOperator(new AddOperator());
			_calculator.EnterDigit(0);
			_calculator.EnterDecimalPoint();
			_calculator.EnterDigit(9);

			Assert.Equal(2 + 0.9m, _calculator.Total);
		}

		[Fact]
		public void SumThreeNumbers()
		{
			_calculator.EnterDigit(3);
			_calculator.EnterDecimalPoint();
			_calculator.EnterDigit(7);

			_calculator.EnterOperator(new AddOperator());

			_calculator.EnterDigit(8);

			_calculator.EnterOperator(new AddOperator());

			_calculator.EnterDigit(5);
			_calculator.EnterDecimalPoint();
			_calculator.EnterDigit(0);
			_calculator.EnterDigit(1);

			Assert.Equal(3.7m + 8 + 5.01m, _calculator.Total);
		}

		public void Dispose()
		{
			_calculator.Dispose();
		}
	}
}
