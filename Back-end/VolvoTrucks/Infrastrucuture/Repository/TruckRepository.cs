using AutoMapper;
using Domain.Entities;
using Infrastrucuture.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucuture.Repository
{
    public class TruckRepository : ITruckRepository
    {
        private readonly VolvoTruckContext _context;
        private readonly IMapper _mapper;
        public TruckRepository(VolvoTruckContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Truck> Create(Truck truck)
        {
            try
            {
                _context.Trucks.Add(truck);
                await _context.SaveChangesAsync();
                return truck;
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
                return await _context.Trucks.FirstOrDefaultAsync(element => element.Id == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Truck> GetByChassiCode(string Chassi_Code)
        {
            try
            {
                return await _context.Trucks.FirstOrDefaultAsync(element => element.Chassi_Code == Chassi_Code);
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
                return await _context.Trucks.OrderBy(element => element.Id).ToListAsync();
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
                var obj = await _context.Trucks.FirstOrDefaultAsync(element => element.Id == truck.Id);

                if (obj == null)
                    throw new ArgumentNullException();

                var objectUpdate = _mapper.Map<Truck>(truck);

                _context.Entry(obj).CurrentValues.SetValues(objectUpdate);

                await _context.SaveChangesAsync();
                return truck;
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
                var obj = await _context.Trucks.FirstOrDefaultAsync(element => element.Id == Id);

                //fazer o merge 
                _context.Trucks.Remove(obj);

                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
