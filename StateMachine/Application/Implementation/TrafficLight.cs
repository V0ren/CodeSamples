using System;
using System.Collections.Generic;
using StateMachine.States;

namespace StateMachine.Application
{
	public class TrafficLight : ITrafficLight
	{
		private string Name { get; }

		public TrafficLight(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}
			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			Name = name;
			TrafficLights = new List<ITrafficLight>();
			CurrentState = RedState.Instance;
			DisplayCurrentStateOfLight();
		}

		public IState CurrentState { get; private set; }

		public IList<ITrafficLight> TrafficLights { get; }

		public void GoToGreen()
		{
			TransitionTo(ConsoleColor.Green);
			DisplayCurrentStateOfLight();
		}

		public void GoToYellow()
		{
			TransitionTo(ConsoleColor.Yellow);
			DisplayCurrentStateOfLight();
		}

		public void GoToRed()
		{
			TransitionTo(ConsoleColor.Red);
			DisplayCurrentStateOfLight();
		}

		public ITrafficLight AddOtherLights(ITrafficLight otherLight)
		{
			TrafficLights.Add(otherLight);
			return this;
		}

		private void TransitionTo(ConsoleColor type)
		{
			Console.WriteLine($"The Trafic Light \"{Name}\" is transitioning from {CurrentState} to {type}!");
			try
			{
				CurrentState = CurrentState.TransitionTo(type, TrafficLights);
			}
			catch (InvalidOperationException exception)
			{
				DisplayError(exception.Message);
			}
		}

		private static void DisplayError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		private void DisplayCurrentStateOfLight()
		{
			Console.Write($"The Trafic Light \"{Name}\" is currently: ");
			Console.ForegroundColor = CurrentState.Color;
			Console.Write(CurrentState);
			Console.ResetColor();
			Console.WriteLine(".");
		}
	}
}
