namespace CalcDriver
{
	public interface ICalculatorOperator
	{
		string ButtonName { get; }
	}

	public class AddOperator : ICalculatorOperator
	{
		public string ButtonName => "Add";
	}
}