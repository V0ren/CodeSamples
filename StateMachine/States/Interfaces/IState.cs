using System;
using System.Collections.Generic;
using StateMachine.Application;

namespace StateMachine.States
{
	public interface IState
	{
		ConsoleColor Color { get; }

		IState TransitionTo(ConsoleColor goToState, IList<ITrafficLight> trafficLights);
	}
}
