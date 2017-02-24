namespace StateMachine.Application
{
    public interface ITrafficLightFactory
    {
		ITrafficLight Create(string name);
    }
}
