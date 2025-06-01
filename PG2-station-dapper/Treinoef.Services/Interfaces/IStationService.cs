using System;
using Treinoef.Api.Contracts.Stations;

namespace Treinoef.Services.Interfaces;

public interface IStationService
{
    IEnumerable<StationResponseContract> GetAll();
    StationResponseContract? Get(int id);
    StationResponseContract Create(StationRequestContract stationRequestContract);
    void Update(int id, StationRequestContract stationRequestContract);
}
