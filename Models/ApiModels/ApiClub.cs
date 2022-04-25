using System;
namespace MODELS.ApiModels
{
	public class ApiClub
	{
		public ApiClub()
		{
		}

		public string ClubName { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
	}
}

