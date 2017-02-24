using StateMachine.Application;
using System.Collections.Generic;
namespace StateMachine.States
{
    public interface IState
    {
		EnumStates Type { get; }
		
		IState TransitionTo(EnumStates goToState, IList<ITrafficLight> trafficLights);
	}
}
