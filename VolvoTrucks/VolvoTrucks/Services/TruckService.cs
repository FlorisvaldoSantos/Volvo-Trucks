using Domain.Entities;
using Infrastrucuture.Repository;
using System.Diagnostics;

namespace VolvoTrucks.Api.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _repository;

        public TruckService(ITruckRepository repository)
        {
            _repository = repository;
        }

        public async Task<Truck> Create(Truck truck)
        {
            try
            {
                return await _repository.Create(truck);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Truck> Get(int Id)
        {
            try
            {
                return await _repository.Get(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Truck>> GetAllTrucks()
        {
            try
            {
                return await _repository.GetAllTrucks();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Truck> Update(Truck truck)
        {
            try
            {
                return await _repository.Update(truck);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                return await _repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
