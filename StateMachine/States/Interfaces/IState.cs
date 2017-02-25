using System.Collections.Generic;
using StateMachine.Application;

namespace StateMachine.States
{
	public interface IState
	{
		EnumStates Type { get; }

		IState TransitionTo(EnumStates goToState, IList<ITrafficLight> trafficLights);
	}
}
