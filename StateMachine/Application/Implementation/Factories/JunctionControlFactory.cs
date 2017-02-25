using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine.Application.Factories
{
	public class JunctionControlFactory : IJunctionControlFactory
	{
		private readonly ITrafficLightFactory _trafficLightFactory;

		public JunctionControlFactory(ITrafficLightFactory trafficLightFactory)
		{
			if (trafficLightFactory == null)
			{
				throw new ArgumentNullException(nameof(trafficLightFactory));
			}

			_trafficLightFactory = trafficLightFactory;
		}

		public IJunctionControl Create()
		{
			var north = _trafficLightFactory.Create("North");
			var east = _trafficLightFactory.Create("East");
			var south = _trafficLightFactory.Create("South");
			var west = _trafficLightFactory.Create("West");

			WireUp(north, new List<ITrafficLight>{ east, south, west});
			WireUp(east, new List<ITrafficLight>{ north, south, west});
			WireUp(south, new List<ITrafficLight>{ north, east, west});
			WireUp(west, new List<ITrafficLight>{ north, east, south});

			return new JunctionControl(north, east, south, west);
		}

		private void WireUp(ITrafficLight light, List<ITrafficLight> otherLights)
		{
			if (light == null)
			{
				throw new ArgumentNullException(nameof(light));
			}
			if (otherLights == null)
			{
				throw new ArgumentNullException(nameof(otherLights));
			}
			
			foreach (var trafficLight in otherLights)
			{
				light.AddOtherLights(trafficLight);
			}
		}		
	}
}
