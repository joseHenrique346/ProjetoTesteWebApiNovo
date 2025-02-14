﻿using Arguments.Argument.Registration.CustomerAddress;
using Domain.DTO.Entity;
using Domain.Interface.Base;

namespace Domain.Interface.Repository
{
    public interface ICustomerAddressRepository : IBaseRepository<CustomerAddressDTO, InputIdentityViewCustomerAddress> { }
}
