using System;
using System.Threading.Tasks;

using AutoMapper;

using HaloJagad.API.Controllers.V1;
using HaloJagad.API.DataContracts;
using HaloJagad.API.DataContracts.Requests;
using HaloJagad.Services.Contracts;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaloJagad.API.Tests.Controllers.ControllerTests.V1
{
	[TestClass]
	public class UserControllerTests : TestBase
	{
		//NOTE: should be replaced by an interface
		UserController _controller;

		public UserControllerTests() : base()
		{
			var businessService = _serviceProvider.GetRequiredService<IUserService>();
			var mapper = _serviceProvider.GetRequiredService<IMapper>();
			var loggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
			var logger = loggerFactory.CreateLogger<UserController>();

			_controller = new UserController(businessService, mapper, logger);
		}

		[TestMethod]
		public async Task CreateUser_Nominal_OK()
		{
			//Simple test
			var user = await _controller.CreateUser(new UserCreationRequest
			{
				User = new User { Id = "U1", Firstname = "Firstname 1", Lastname = "Lastname 1" },
				Date = DateTime.Now
			}).ConfigureAwait(false);

			Assert.IsNotNull(user);
		}


	}
}
