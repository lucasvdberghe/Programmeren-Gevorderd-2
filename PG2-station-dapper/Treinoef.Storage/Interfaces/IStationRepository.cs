using System;
using Treinoef.Services.Models;

namespace Treinoef.Storage.Interfaces;

public interface IStationRepository
{
    IEnumerable<Station> GetAll();
    Station? GetById(int id);
    Station Create(Station station);
    void Update(Station station);
}
