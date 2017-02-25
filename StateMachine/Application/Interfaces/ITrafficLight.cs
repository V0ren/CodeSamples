using System.Collections.Generic;
using StateMachine.States;

namespace StateMachine.Application
{
	public interface ITrafficLight
	{
		IState CurrentState { get; }

		IList<ITrafficLight> TrafficLights { get; }

		ITrafficLight AddOtherLights(ITrafficLight otherLight);

		void GoToGreen();

		void GoToYellow();

		void GoToRed();
	}
}
