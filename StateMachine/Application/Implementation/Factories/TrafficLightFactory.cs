namespace StateMachine.Application.Factories
{
	public class TrafficLightFactory : ITrafficLightFactory
	{
		public ITrafficLight Create(string name)
		{
			return new TrafficLight(name);
		}
	}
}
