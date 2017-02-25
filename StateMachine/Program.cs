using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StateMachine.Application.Factories;

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
			var junctionControlFactory = ServiceCollection
				.BuildServiceProvider()
				.GetRequiredService<IJunctionControlFactory>();
			var junctionControl = junctionControlFactory.Create();

			await junctionControl.NorthToGreen();
			await junctionControl.NorthToRed();
			await junctionControl.EastToGreen();
			await junctionControl.EastToRed();
			await junctionControl.SouthToGreen();
			await junctionControl.WestToGreen();
		}

		private static void ConfigureDependencyInjection()
		{
			ServiceCollection.AddSingleton<IJunctionControlFactory, JunctionControlFactory>();
			ServiceCollection.AddSingleton<ITrafficLightFactory, TrafficLightFactory>();
		}
	}
}
