using System;
using AutoMapper;
using Customers.Application.Common.Mappings;
using Customers.Domain;

namespace Customers.Application.Customers.Queries.GetCustomerInfo
{
    public class CustomerInfoVm : IMapWith<Customer>
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerInfoVm>()
                .ForMember(customerVm => customerVm.Id,
                    opt => opt.MapFrom(customer => customer.Id))
                .ForMember(customerVm => customerVm.Firstname,
                    opt => opt.MapFrom(customer => customer.Firstname))
                .ForMember(customerVm => customerVm.Lastname,
                    opt => opt.MapFrom(customer => customer.Lastname));
        }
    }
}
