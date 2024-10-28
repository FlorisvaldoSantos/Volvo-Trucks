using Domain.Entities;

namespace VolvoTrucks.Api.Services
{
    public interface ITruckService
    {
        Task<Truck> Create(Truck truck);
        Task<Truck> Get(int Id);
        Task<List<Truck>> GetAllTrucks();
        Task<Truck> Update(Truck truck);
        Task<bool> Delete(int Id);
    }
}
