using System;

namespace HaloJagad.API.DataContracts.Requests
{
	public class UserCreationRequest
	{
		public DateTime Date { get; set; }

		public User User { get; set; }
	}
}
