using AutoMapper;
using Core.IRepositories_Data;
using Core.IServices_Bll;
using Core.Model;
using Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Bll
{
    public class AddressService :IAddressService
    {
        private IAddressRepository _addressRepository;
        private IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            this._addressRepository = addressRepository;
            this._mapper = mapper;
        }

    
        public async Task<int> AddAddress(AddressResource address)
        {
            address.AddDate = DateTime.Now;
            return await _addressRepository.AddAddress(_mapper.Map<Address>(address));
        }
 
      
        public async Task<List<AddressResource>> GetPlaces()
        {
            var addresses = await _addressRepository.GetAllAddresses();
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            var x = addresses.Where(a => a.AddDate >= lastMonth).ToList();
            return _mapper.Map<List<AddressResource>>(x);
        }

        
        public async Task<List<AddressResource>> GetTenPlaces(Location location)
        {
            double loc1 = location.point1;
            double loc2 = location.point2;
            List<AddressResource> addresses = _mapper.Map<List<AddressResource>>(await _addressRepository.GetAllAddresses());
            var b = addresses.Where(add => add.LocationName != null);
            b = b.Select(a => { a.Distance = CalculateAirDistance(loc1, loc2, Double.Parse(a.LocationName.Split(",")[0]), Double.Parse(a.LocationName.Split(",")[1])); return a; });
            b = b.OrderBy(x => x.Distance);
            b = b.Take(10);
            b=b.ToList();
            return (List<AddressResource>)b;
            //return addresses.Where(add => add.LocationName != null)
            //                .Select(a => { a.Distance = CalculateAirDistance(loc1, loc2, Double.Parse(a.LocationName.Split(",")[0]), Double.Parse(a.LocationName.Split(",")[1])); return a; })
            //                .OrderBy(x=> x.Distance)
            //                .Take(10)
            //                .ToList();

        }

        
        public double CalculateAirDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; 

            double latRad1 = DegreesToRadians(lat1);
            double latRad2 = DegreesToRadians(lat2);
            double deltaLat = DegreesToRadians(lat2 - lat1);
            double deltaLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(latRad1) * Math.Cos(latRad2) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }





        /*
        public async Task<AddressService> GetById(int code)
        {
            return _mapper.Map<AddressService>(await _addressRepository.GetById(code);
        }

        public async Task<List<AddressService>> GetAll()
        {
            return _mapper.Map<List<AddressService>>(await _addressRepository.GetAll());
        }


        //put
        public async Task<int> Update(AddressService address)
        {
            return await _addressRepository.Update(_mapper.Map<Address>(address));
        }
        public async Task<int> Delete(int code)
        {
            return await _addressRepository.Delete(code);
        }*/

    }
}
