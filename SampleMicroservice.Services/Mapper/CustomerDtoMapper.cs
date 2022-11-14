using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Services.Model;

namespace SampleMicroservice.Services.Mapper
{
    public class CustomerDtoMapper : Profile
    {
        public CustomerDtoMapper()
        {
            //Mapper of Request
            CreateMap<JsonPatchDocument<CustomerDto>, JsonPatchDocument<Customer>>();
            CreateMap<Operation<CustomerDto>, Operation<Customer>>();
            CreateMap<CustomerDto, Customer>().ConstructUsingServiceLocator();

            //Mapper of Response
            CreateMap<Customer, FullCustomerDto>().ForMember(dst => dst.Address, opt => opt.MapFrom((src, add, _, ctx) => 
            {
                var shouldMapAddress = ctx.Items["Map Address"]?.ToString();

                if (shouldMapAddress != null && bool.TryParse(shouldMapAddress, out bool shouldMap) && shouldMap)
                {
                    return src.Address;
                }

                return null;
            }));
        }
    }
}
