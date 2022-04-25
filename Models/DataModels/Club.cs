using System;
using Newtonsoft.Json;

namespace MODELS.DataModels
{
	public class Club
	{
		public Club()
		{
			
		}

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }
		public string ClubName { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
	}
}

