using AutoMapper;
using Core.IServices_Bll;
using Core.Model;
using Core.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private IAddressService _addressService;
        private IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<int> AddAddress(AddressResource address)
        {
            return await _addressService.AddAddress(address);
        }


        [HttpGet]
        public async Task<List<AddressResource>> GetPlaces()
        {
            var x = await _addressService.GetPlaces();
            return _mapper.Map<List<AddressResource>>(x);
        }

        [HttpGet("{location1}/{location2}")] 
        public async Task<List<AddressResource>> GetTenPlaces(double location1, double location2)
        {
            Location l = new Location() { point1= location1, point2= location2 };
            var x = await _addressService.GetTenPlaces(l);
            return _mapper.Map<List<AddressResource>>(x);
        }




    }
}
