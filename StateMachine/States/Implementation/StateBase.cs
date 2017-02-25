using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Application;

namespace StateMachine.States
{
	public abstract class StateBase : IState
	{
		protected StateBase(ConsoleColor color)
		{
			Color = color;
		}

		public ConsoleColor Color { get; }

		public abstract IState TransitionTo(ConsoleColor goToState, IList<ITrafficLight> trafficLights);

		public InvalidOperationException InvalidStateTransition(ConsoleColor goToType)
		{
			return new InvalidOperationException($"Cannot transition to state {goToType}, the traffic light does not support it!");
		}

		public Exception NotAnActualStateException(ConsoleColor goToType)
		{
			return new Exception($"State \"{goToType}\" is not a valid state.");
		}

		public override string ToString()
		{
			return Color.ToString();
		}

		internal void ValidateLights(IList<ITrafficLight> monitoredLights)
		{
			if (monitoredLights.Any(lights => lights.CurrentState.Color == ConsoleColor.Green))
			{
				throw new InvalidOperationException($"Cannot transition from the state {ToString()} because one the monitored lights is Green!");
			}
		}
	}
}
