using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StateMachine.Application;

namespace StateMachine
{
	public class Program
	{
		private static readonly ServiceCollection ServiceCollection = new ServiceCollection();

		public static void Main(string[] args)
		{
			ConfigureDependencyInjection();

			var task = ExecuteTestScenario();
			Task.WaitAll(task);

			Console.ReadLine();
		}

		private static async Task ExecuteTestScenario()
		{
			var junctionControl = ServiceCollection.BuildServiceProvider().GetRequiredService<IJunctionControl>();
			await junctionControl.NorthToGreen();
			await junctionControl.NorthToRed();
			await junctionControl.EastToGreen();
			await junctionControl.EastToRed();
			await junctionControl.SouthToGreen();
			await junctionControl.WestToGreen();
		}

		private static void ConfigureDependencyInjection()
		{
			ServiceCollection.AddSingleton<IJunctionControl, JunctionControl>();
			ServiceCollection.AddSingleton<ITrafficLightFactory, TrafficLightFactory>();
		}
	}
}
