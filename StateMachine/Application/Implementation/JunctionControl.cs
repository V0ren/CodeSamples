using System.Threading.Tasks;

namespace StateMachine.Application
{
	public class JunctionControl : IJunctionControl
	{
		private ITrafficLight North { get; }

		private ITrafficLight East { get; }

		private ITrafficLight South { get; }

		private ITrafficLight West { get; }

		public JunctionControl(
			ITrafficLight north, 
			ITrafficLight east, 
			ITrafficLight south, 
			ITrafficLight west)
		{
			North = north;
			East = east;
			South = south;
			West = west;
		}

		public async Task NorthToGreen()
		{
			North.GoToYellow();
			await Task.Delay(1000);
			North.GoToGreen();
		}

		public async Task EastToGreen()
		{
			East.GoToYellow();
			await Task.Delay(1000);
			East.GoToGreen();
		}

		public async Task SouthToGreen()
		{
			South.GoToYellow();
			await Task.Delay(1000);
			South.GoToGreen();
		}

		public async Task WestToGreen()
		{
			West.GoToYellow();
			await Task.Delay(1000);
			West.GoToGreen();
		}

		public async Task NorthToRed()
		{
			North.GoToYellow();
			await Task.Delay(1000);
			North.GoToRed();
		}

		public async Task EastToRed()
		{
			East.GoToYellow();
			await Task.Delay(1000);
			East.GoToRed();
		}

		public async Task SouthToRed()
		{
			South.GoToYellow();
			await Task.Delay(1000);
			South.GoToRed();
		}

		public async Task WestToRed()
		{
			West.GoToYellow();
			await Task.Delay(1000);
			West.GoToRed();
		}
	}
}
