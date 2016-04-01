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
				var equalsButton = FindButton("Equals");
				equalsButton.Click();
				return decimal.Parse(FindResult().Text);
			}
		}

		public void EnterDigit(int digit)
		{
			var digitButton = FindButton(digit.ToString());
			digitButton.Click();
		}

		private Button FindButton(string buttonText)
		{
			return _window.Get<Button>(SearchCriteria.ByText(buttonText));
		}

		private Label FindResult()
		{
			const string resultControlAutomationId = "150";
			return _window.Get<Label>(SearchCriteria.ByAutomationId(resultControlAutomationId));
		}

		public void Clear()
		{
			var clearButton = FindButton("Clear entry");
			clearButton.Click();
		}

		public void EnterOperator(ICalculatorOperator @operator)
		{
			var operatorButton = FindButton(@operator.ButtonName);
			operatorButton.Click();
		}

		public void Dispose()
		{
			_app.Dispose();
		}
	}
}