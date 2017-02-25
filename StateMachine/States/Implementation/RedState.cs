using System;
using System.Collections.Generic;
using StateMachine.Application;

namespace StateMachine.States
{
	public class RedState : StateBase
	{
		public static IState Instance = new RedState();

		private RedState() : base(ConsoleColor.Red)
		{
		}

		public override IState TransitionTo(ConsoleColor goToState, IList<ITrafficLight> trafficLights)
		{
			switch (goToState)
			{
				case ConsoleColor.Green:
					throw InvalidStateTransition(goToState);
				case ConsoleColor.Yellow:
					ValidateLights(trafficLights);
					return YellowState.Instance;
				case ConsoleColor.Red:
					return this;
				default:
					throw NotAnActualStateException(goToState);
			}
		}
	}
}
