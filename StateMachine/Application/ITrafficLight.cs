using StateMachine.States;
using System.Collections.Generic;

namespace StateMachine.Application
{
    public interface ITrafficLight
    {
		IState CurrentState { get;  }
		IList<ITrafficLight> TrafficLights { get; }

		ITrafficLight AddOtherLights(ITrafficLight otherLight);
		void GoToGreen();
		void GoToOrange();
		void GoToRed();
    }
}
