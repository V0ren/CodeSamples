namespace StateMachine.Application
{
	public class TrafficLightFactory : ITrafficLightFactory
	{
		public ITrafficLight Create(string name)
		{
			return new TrafficLight(name);
		}
	}
}
