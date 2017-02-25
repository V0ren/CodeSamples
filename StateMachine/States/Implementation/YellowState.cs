using System;
using System.Collections.Generic;
using StateMachine.Application;

namespace StateMachine.States
{
	public class YellowState : StateBase
	{
		public static IState Instance = new YellowState();

		private YellowState() : base(ConsoleColor.Yellow)
		{
		}

		public override IState TransitionTo(ConsoleColor goToState, IList<ITrafficLight> trafficLights)
		{
			switch (goToState)
			{
				case ConsoleColor.Green:
					ValidateLights(trafficLights);
					return GreenState.Instance;
				case ConsoleColor.Yellow:
					return this;
				case ConsoleColor.Red:
					return RedState.Instance;
				default:
					throw NotAnActualStateException(goToState);
			}
		}
	}
}
