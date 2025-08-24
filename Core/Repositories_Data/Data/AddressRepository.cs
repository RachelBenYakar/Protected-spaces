using Core.IRepositories_Data;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_Data.Data
{
    public class AddressRepository : IAddressRepository
    {
        private WarContext warContext;

        public AddressRepository(WarContext warContext) 
        { 
            this.warContext = warContext;
        }

        //הוספת נקודה חדשה
        public async Task<int> AddAddress(Address address)
        {
            warContext.Addresses.Add(address);
            return await warContext.SaveChangesAsync();
        }


        //10 המקומות הקרובים אליי, לפי מיקום
        /*public async Task<List<Address>> GetTenPlaces(string location)
        {
            
        }*/


        public async Task<List<Address>> GetAllAddresses()
        {
            return await warContext.Addresses.Include(a => a.TypeBuilding).Include(a=>a.Location).ToListAsync();
        }

  


        /*
        public async Task<Address> GetById(int code)
        {
            return await warContext.Addresses.Where(x=> x.Code==code).Include(a=> a.TypeBuilding).FirstOrDefaultAsync();
        }


        public async Task<int> Update(Address address)
        {
            var x = await warContext.Addresses.Where(x=> x.Code==address.Code).FirstAsync();
            warContext.Entry(x).CurrentValues.SetValues(address);
            //warContext.Addresses.Update(address);
            return await warContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int code)
        {
            var x = warContext.Addresses.Where(x=> x.Code==code).FirstOrDefault();
            warContext.Addresses.Remove(x);
            return await warContext.SaveChangesAsync();
        }*/
    }


}
