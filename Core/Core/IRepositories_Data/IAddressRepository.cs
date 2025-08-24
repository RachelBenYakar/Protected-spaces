using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories_Data
{
    public interface IAddressRepository
    {
        Task<int> AddAddress(Address address);
        Task<List<Address>> GetAllAddresses();
    }
}
