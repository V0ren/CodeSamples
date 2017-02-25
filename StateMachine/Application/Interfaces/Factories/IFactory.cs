namespace StateMachine.Application.Factories
{
	public interface IFactory<out TOut>
	{
		TOut Create();
	}

	public interface IFactory<out TOut, in TIn>
	{
		TOut Create(TIn item);
	}


}