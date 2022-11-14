using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Services.Model;

namespace SampleMicroservice.Services.Mapper
{
    public class AddressDtoMapper : Profile
    {
        public AddressDtoMapper()
        {
            //Mapper of Request
            CreateMap<AddressDto, Address>();

            //Mapper of Response
            CreateMap<Address, AddressDto>();
        }
    }
}
