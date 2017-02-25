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
			North.GoToOrange();
			await Task.Delay(1000);
			North.GoToGreen();
		}

		public async Task EastToGreen()
		{
			East.GoToOrange();
			await Task.Delay(1000);
			East.GoToGreen();
		}

		public async Task SouthToGreen()
		{
			South.GoToOrange();
			await Task.Delay(1000);
			South.GoToGreen();
		}

		public async Task WestToGreen()
		{
			West.GoToOrange();
			await Task.Delay(1000);
			West.GoToGreen();
		}

		public async Task NorthToRed()
		{
			North.GoToOrange();
			await Task.Delay(1000);
			North.GoToRed();
		}

		public async Task EastToRed()
		{
			East.GoToOrange();
			await Task.Delay(1000);
			East.GoToRed();
		}

		public async Task SouthToRed()
		{
			South.GoToOrange();
			await Task.Delay(1000);
			South.GoToRed();
		}

		public async Task WestToRed()
		{
			West.GoToOrange();
			await Task.Delay(1000);
			West.GoToRed();
		}
	}
}
