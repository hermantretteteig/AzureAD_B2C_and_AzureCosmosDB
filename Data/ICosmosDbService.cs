using System;
using MODELS;
using MODELS.ApiModels;
using MODELS.DataModels;

namespace Data
{


    public interface ICosmosDbService
    {
        Task<Club> AddClub(ApiClub new_club);
    }
}

