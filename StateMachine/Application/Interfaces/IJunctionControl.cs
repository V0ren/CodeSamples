using System.Threading.Tasks;

namespace StateMachine.Application
{
	public interface IJunctionControl
	{
		Task NorthToGreen();

		Task EastToGreen();

		Task SouthToGreen();

		Task WestToGreen();

		Task NorthToRed();

		Task EastToRed();

		Task SouthToRed();

		Task WestToRed();
	}
}
