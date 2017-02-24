using Microsoft.Extensions.DependencyInjection;
using System;
using StateMachine.Application;
using System.Threading.Tasks;

namespace StateMachine
{
    public class Program
    {
		private static readonly ServiceCollection ServiceCollection = new ServiceCollection();

		public static void Main(string[] args)
        {
			ConfigureDependencyInjection();
		
			var junctionControl = ServiceCollection.BuildServiceProvider().GetRequiredService<IJunctionControl>();
			var task = junctionControl.NorthToGreen();
			Task.WaitAll(task);
			task = junctionControl.NorthToRed();
			Task.WaitAll(task);
			task = junctionControl.EastToGreen();
			Task.WaitAll(task);
			task = junctionControl.EastToRed();
			Task.WaitAll(task);
			task = junctionControl.SouthToGreen();
			Task.WaitAll(task);
			task = junctionControl.WestToGreen();
			Task.WaitAll(task);
			
			Console.ReadLine();

		}

		
		private static void ConfigureDependencyInjection()
		{
			ServiceCollection.AddSingleton<IJunctionControl, JunctionControl>();
			ServiceCollection.AddSingleton<ITrafficLightFactory, TrafficLightFactory>();
		}
	}
}
