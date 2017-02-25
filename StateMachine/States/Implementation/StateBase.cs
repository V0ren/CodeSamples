using System;
using System.Collections.Generic;
using System.Linq;
using StateMachine.Application;

namespace StateMachine.States
{
	public abstract class StateBase : IState
	{
		protected StateBase(EnumStates type)
		{
			Type = type;
		}

		public EnumStates Type { get; set; }

		public abstract IState TransitionTo(EnumStates goToState, IList<ITrafficLight> trafficLights);

		public InvalidOperationException InvalidStateTransition(EnumStates goToType)
		{
			return new InvalidOperationException($"Cannot transition to state {goToType} from state {Type}!");
		}

		public override string ToString()
		{
			return Type.ToString();
		}

		internal void ValidateLights(IList<ITrafficLight> monitoredLights)
		{
			if (monitoredLights.Any(lights => lights.CurrentState.Type == EnumStates.Green))
			{
				throw new InvalidOperationException($"Cannot transition from the state {Type} because one the monitored lights is Green");
			}
		}
	}
}
