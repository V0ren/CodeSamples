using StateMachine.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.States
{
    public class RedState : StateBase
	{
		public static IState Instance = new RedState();

		private RedState() : base(EnumStates.Red)
		{
		}

		public override IState TransitionTo(EnumStates goToState, IList<ITrafficLight> trafficLights)
		{
			switch (goToState)
			{
				case EnumStates.Green:
					throw InvalidStateTransition(goToState);
				case EnumStates.Orange:
					ValidateLights(trafficLights);
					return OrangeState.Instance;
				case EnumStates.Red:
					return this;
				default:
					throw new Exception();
			}
		}
	}
}
