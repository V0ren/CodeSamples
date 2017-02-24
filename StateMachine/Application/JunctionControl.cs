using System;
using System.Threading.Tasks;

namespace StateMachine.Application
{
    public class JunctionControl : IJunctionControl
    {
		public ITrafficLight North { get; set; }
		public ITrafficLight East { get; set; }
		public ITrafficLight South { get; set; }
		public ITrafficLight West { get; set; }

		public JunctionControl(ITrafficLightFactory factory)
		{
			North = factory.Create(nameof(North));
			East = factory.Create(nameof(East));
			South = factory.Create(nameof(South));
			West = factory.Create(nameof(West));

			North.AddOtherLights(East);
			North.AddOtherLights(South);
			North.AddOtherLights(West);

			East.AddOtherLights(North);
			East.AddOtherLights(South);
			East.AddOtherLights(West);

			South.AddOtherLights(North);
			South.AddOtherLights(East);
			South.AddOtherLights(West);

			West.AddOtherLights(North);
			West.AddOtherLights(East);
			West.AddOtherLights(South);
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
