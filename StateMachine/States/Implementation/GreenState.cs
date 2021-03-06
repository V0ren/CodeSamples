﻿using System;
using System.Collections.Generic;
using StateMachine.Application;

namespace StateMachine.States
{
	public class GreenState : StateBase
	{
		public static IState Instance = new GreenState();

		private GreenState() : base(ConsoleColor.Green)
		{
		}

		public override IState TransitionTo(ConsoleColor goToState, IList<ITrafficLight> trafficLights)
		{
			switch (goToState)
			{
				case ConsoleColor.Green:
					return this;
				case ConsoleColor.Yellow:
					return YellowState.Instance;
				case ConsoleColor.Red:
					throw InvalidStateTransition(goToState);
				default:
					throw NotAnActualStateException(goToState);
			}
		}
	}
}
