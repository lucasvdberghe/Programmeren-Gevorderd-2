using System;
using Dapper;
using MySqlConnector;
using Treinoef.Services.Models;
using Treinoef.Storage.Interfaces;
using Treinoef.Storage.Queries;

namespace Treinoef.Storage;

public class StationRepository : IStationRepository
{

    private const string _connectionString = "server=127.0.0.1;port=3307;database=treinoef;user=root;password=WachtW00rd";
    private QueryRepository _queryRepository = new QueryRepository();

    public IEnumerable<Station> GetAll()
    {
        using var connection = new MySqlConnection(_connectionString);
        var results = connection.Query<Station>(_queryRepository.GetAllStations);
        return results.ToList();
    }

    public Station? GetById(int id)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingle<Station>(_queryRepository.GetStationById, new { Id = id });
        return result;
    }

    public Station Create(Station station)
    {
        using var connection = new MySqlConnection(_connectionString);
        var result = connection.QuerySingle<int>(_queryRepository.CreateStation, station);
        return GetById(result);
    }

    public void Update(Station station)
    {
        using var connection = new MySqlConnection(_connectionString);
        connection.Execute(_queryRepository.UpdateStation, station);
    }
}
