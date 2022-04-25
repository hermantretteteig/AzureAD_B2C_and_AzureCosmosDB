using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using MODELS.ApiModels;
using MODELS.DataModels;

namespace Data
{
	public class ClubDataAccess : ICosmosDbService
	{
		private Container _container;

		public ClubDataAccess(
			CosmosClient dbClient,
			string databaseName,
			string containerName)
		{
			this._container = dbClient.GetContainer(databaseName, containerName);
		}

		public async Task<Club> AddClub(ApiClub new_club)
		{
			string id = Guid.NewGuid().ToString("N");

			Club _club = new()
            {
				Id = id,
				ClubName = new_club.ClubName,
				Lat = 59,
				Lon = 10,
				City = new_club.City,
				PostalCode = new_club.PostalCode,
				Street = new_club.Street
			};

			await this._container.CreateItemAsync<Club>(_club, new PartitionKey(id));

			//Find and return the saved club
			try
			{
				ItemResponse<Club> response = await this._container.ReadItemAsync<Club>(id, new PartitionKey(id));
				return response.Resource;
			}
			catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}

		}
	}

	
}

