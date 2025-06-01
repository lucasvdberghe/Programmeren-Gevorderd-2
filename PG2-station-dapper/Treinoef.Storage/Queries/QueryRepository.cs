using System;
using Treinoef.Storage.Interfaces;

namespace Treinoef.Storage.Queries;

public class QueryRepository
{
    private string? _getAllCustomers;
    private string? _getCustomerById;
    private string? _createCustomer;
    private string? _getAllStations;
    private string? _getStationById;
    private string? _createStation;
    private string? _updateStation;
    private string? _getAllSubscriptions;

    private const string QueryRoot = "Queries/SQL/";

    public string GetAllCustomers =>
        _getAllCustomers ??=
            GetQuery(nameof(GetAllCustomers));

    public string GetCustomerById =>
        _getCustomerById ??= GetQuery(nameof(GetCustomerById));

    public string CreateCustomer =>
        _createCustomer ??= GetQuery(nameof(CreateCustomer));

    public string GetAllStations =>
        _getAllStations ??= GetQuery(nameof(GetAllStations));

    public string GetStationById =>
        _getStationById ??= GetQuery(nameof(GetStationById));

    public string CreateStation =>
            _createStation ??= GetQuery(nameof(CreateStation));

    public string UpdateStation =>
            _updateStation ??= GetQuery(nameof(UpdateStation));
    
    public string GetAllSubscriptions =>
            _getAllSubscriptions ??= GetQuery(nameof(GetAllSubscriptions));

    private static string GetQuery(string queryName) =>
        File.ReadAllText(QueryRoot + queryName + ".sql");
}
