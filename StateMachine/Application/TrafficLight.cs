using System;
using System.Collections.Generic;
using StateMachine.States;

namespace StateMachine.Application
{
    public class TrafficLight : ITrafficLight
    {
		public IState CurrentState { get; private set; }
		private string Name { get; set; }

		public IList<ITrafficLight> TrafficLights
		{
			get; private set;
		}

		public TrafficLight(string name)
		{
			Name = name;
			TrafficLights = new List<ITrafficLight>();
			CurrentState = RedState.Instance;
			DisplayCurrentStateOfLight();
		}

		public void GoToGreen()
		{		
			TransitionTo(EnumStates.Green);
			DisplayCurrentStateOfLight();
		}

		public void GoToOrange()
		{
			TransitionTo(EnumStates.Orange);
			DisplayCurrentStateOfLight();
		}

		public void GoToRed()
		{
			TransitionTo(EnumStates.Red);
			DisplayCurrentStateOfLight();
		}

		private void TransitionTo(EnumStates type)
		{
			Console.WriteLine($"The Trafic Light \"{Name}\" is transitioning from {CurrentState.ToString()} to {type.ToString()}");
			try
			{
				CurrentState = CurrentState.TransitionTo(type, TrafficLights);
			} catch(InvalidOperationException exception)
			{
				DisplayError(exception.Message);
			}
		}

		private void DisplayError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		private void DisplayCurrentStateOfLight()
		{
			Console.WriteLine($"The Trafic Light \"{Name}\" is currently: {CurrentState.ToString()}");
		}

		public void AddOtherLights(ITrafficLight otherLight)
		{
			TrafficLights.Add(otherLight);
		}
	}
}
