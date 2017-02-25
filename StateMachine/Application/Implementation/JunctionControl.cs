using System.Threading.Tasks;

namespace StateMachine.Application
{
	public class JunctionControl : IJunctionControl
	{
		private ITrafficLight North { get; set; }

		private ITrafficLight East { get; set; }

		private ITrafficLight South { get; set; }

		private ITrafficLight West { get; set; }

		public JunctionControl(ITrafficLightFactory factory)
		{
			BootstrapJunction(factory);
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

		private void BootstrapJunction(ITrafficLightFactory factory)
		{
			InitializeTrafficLights(factory);
			WireUpNorth();
			WireUpEast();
			WireUpSouth();
			WireUpWest();
		}

		private void WireUpWest()
		{
			West.AddOtherLights(North)
				.AddOtherLights(East)
				.AddOtherLights(South);
		}

		private void WireUpEast()
		{
			East.AddOtherLights(North)
				.AddOtherLights(South)
				.AddOtherLights(West);
		}

		private void WireUpSouth()
		{
			South.AddOtherLights(North)
				.AddOtherLights(East)
				.AddOtherLights(West);
		}

		private void WireUpNorth()
		{
			North.AddOtherLights(East)
				.AddOtherLights(South)
				.AddOtherLights(West);
		}

		private void InitializeTrafficLights(ITrafficLightFactory factory)
		{
			North = factory.Create(nameof(North));
			East = factory.Create(nameof(East));
			South = factory.Create(nameof(South));
			West = factory.Create(nameof(West));
		}
	}
}
