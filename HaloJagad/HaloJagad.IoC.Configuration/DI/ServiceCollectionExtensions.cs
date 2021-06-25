using System.Reflection;

using HaloJagad.Services;
using HaloJagad.Services.Contracts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HaloJagad.IoC.Configuration.DI
{
	public static class ServiceCollectionExtensions
	{
		public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
		{
			services?.AddTransient<IUserService, UserService>();
		}

		public static void ConfigureMappings(this IServiceCollection services)
		{
			//Automap settings
			services?.AddAutoMapper(Assembly.GetExecutingAssembly());
		}
	}
}
