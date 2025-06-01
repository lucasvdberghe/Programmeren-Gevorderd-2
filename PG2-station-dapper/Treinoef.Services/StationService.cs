using System;
using Treinoef.Api.Contracts.Stations;
using Treinoef.Services.Exceptions;
using Treinoef.Services.Interfaces;
using Treinoef.Services.Mapping;
using Treinoef.Storage;
using Treinoef.Storage.Interfaces;

namespace Treinoef.Services;

public class StationService(IStationRepository stationRepository) : IStationService
{
    public IEnumerable<StationResponseContract> GetAll()
    {
        return stationRepository.GetAll().Select(s => s.AsContract()).ToList();
    }

    public StationResponseContract? Get(int id)
    {
        var station = stationRepository.GetById(id);

        return station?.AsContract();
    }

    public StationResponseContract Create(StationRequestContract stationRequestContract)
    {
        var station = stationRequestContract.AsModel();

        var createdStation = stationRepository.Create(station);

        return createdStation.AsContract();  
    }

    public void Update(int id, StationRequestContract stationRequestContract)
    {
        var station = stationRepository.GetById(id);

        if (station is null) throw new NotFoundException();

        station.HeatedWaitingArea = stationRequestContract.HeatedWaitingArea;

        stationRepository.Update(station);
    }
}