using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucuture.Repository
{
    public interface ITruckRepository
    {
        Task<Truck> Create(Truck truck);
        Task<Truck> Get(int Id);
        Task<Truck> GetByChassiCode(string Chassi_Code);
        Task<List<Truck>> GetAllTrucks();
        Task<Truck> Update(Truck truck);
        Task<bool> Delete(int Id);
    }
}
