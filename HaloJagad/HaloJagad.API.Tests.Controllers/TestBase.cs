using System.IO;

using HaloJagad.API.Common.Settings;
using HaloJagad.IoC.Configuration.DI;
using HaloJagad.Tools.Configurations;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaloJagad.API.Tests.Controllers
{
	[TestClass]
	public class TestBase
	{
		internal IConfigurationRoot _configurationRoot;
		internal ServiceCollection _services;
		internal ServiceProvider _serviceProvider;

		public TestBase()
		{
			_configurationRoot = ConfigurationHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
			var appSettings = _configurationRoot.GetSection(nameof(AppSettings));

			_services = new ServiceCollection();

			//We load EXACTLY the same settings (DI and others) than API real solution, what is much better for tests.
			_services.ConfigureBusinessServices((IConfiguration)_configurationRoot);

			_services.ConfigureMappings();
			_services.AddLogging();
			_services.Configure<AppSettings>(appSettings);

			_serviceProvider = _services.BuildServiceProvider();
		}

		~TestBase()
		{
			_serviceProvider?.Dispose();
		}
	}
}
