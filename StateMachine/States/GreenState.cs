using StateMachine.Application;
using System;
using System.Collections.Generic;

namespace StateMachine.States
{
	public class GreenState : StateBase
	{
		public static IState Instance = new GreenState();

		private GreenState() : base(EnumStates.Green)
		{
		}

		public override IState TransitionTo(EnumStates goToState, IList<ITrafficLight> trafficLights)
		{
			switch (goToState)
			{
				case EnumStates.Green:
					return this;
				case EnumStates.Orange:
					return OrangeState.Instance;
				case EnumStates.Red:
					throw InvalidStateTransition(goToState);
				default:
					throw new Exception();
			}
		}
	}
}
