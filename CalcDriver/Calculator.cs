using System;
using System.Diagnostics;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace CalcDriver
{
	public class Calculator : IDisposable
	{
		private readonly Window _window;
		private readonly Application _app;

		public Calculator()
		{
			_app = Application.AttachOrLaunch(new ProcessStartInfo(@"c:\windows\System32\calc.exe"));
			_window = _app.GetWindow("Calculator");
		}

		public decimal Total
		{
			get
			{
				ClickButton("Equals");
				return decimal.Parse(FindResult().Text);
			}
		}

		public void EnterDigit(int digit)
		{
			var digitButton = _window.Get<Button>(SearchCriteria.ByText(digit.ToString()));
			digitButton.Click();
		}

		public void EnterOperator(ICalculatorOperator @operator)
		{
			var operatorButton = _window.Get<Button>(SearchCriteria.ByText(@operator.ButtonName));
			operatorButton.Click();
		}

		public void EnterDecimalPoint()
		{
			ClickButton("Decimal separator");
		}

		public void Clear()
		{
			ClickButton("Clear entry");
		}

		public void Dispose()
		{
			_app.Dispose();
		}

		private Label FindResult()
		{
			const string resultControlAutomationId = "150";
			return _window.Get<Label>(SearchCriteria.ByAutomationId(resultControlAutomationId));
		}

		private void ClickButton(string buttonName)
		{
			var button = _window.Get<Button>(SearchCriteria.ByText(buttonName));
			button.Click();
		}
	}
}