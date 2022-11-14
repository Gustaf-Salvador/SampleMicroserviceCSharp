using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Repository.Model;

namespace SampleMicroservice.Repository.Mapper
{
    public class CustomerDsoMapper : Profile
    {
        public CustomerDsoMapper()
        {
            const string CustomerClassName = "SampleMicroservice.Domain.Model.Customer";
            const string AddressIdFieldName = "AddressId";

            //This line is used in order to set the value of a private property
            ShouldMapField = fieldInfo => CustomerClassName.Equals(fieldInfo?.ReflectedType?.FullName) && AddressIdFieldName.Equals(fieldInfo.Name);


            CreateMap<Customer, CustomerDso>();


            CreateMap<CustomerDso, Customer>()
                .ConstructUsingServiceLocator()
                //.ForMember(dst => dst.Address, opt => opt.Ignore())
                ;
        }
    }
}
