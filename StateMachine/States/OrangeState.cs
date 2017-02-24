using StateMachine.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.States
{
	public class OrangeState : StateBase
	{
		public static IState Instance = new OrangeState();

		private OrangeState() : base(EnumStates.Orange)
		{
		}

		public override IState TransitionTo(EnumStates goToState, IList<ITrafficLight> trafficLights)
		{
			switch (goToState)
			{
				case EnumStates.Green:
					ValidateLights(trafficLights);
					return GreenState.Instance;
				case EnumStates.Orange:
					return this;
				case EnumStates.Red:
					return RedState.Instance;
				default:
					throw new Exception();
			}
		}
	}
}
