using System.Threading.Tasks;

namespace StateMachine.Application
{
    public interface IJunctionControl
    {
		ITrafficLight North { get; set; }
		ITrafficLight East { get; set; }
		ITrafficLight South { get; set; }
		ITrafficLight West { get; set; }

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
