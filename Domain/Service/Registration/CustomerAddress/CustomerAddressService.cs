﻿using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Arguments.Argument.Registration.CustomerAddress;
using Arguments.Conversor;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Repository;
using Domain.Interface.Service.CustomerAddress;
using Domain.Service.Base;
using Domain.Utils.Helper;
using System.Reflection;

namespace Domain.Service.Registration.CustomerAddress
{
    public class CustomerAddressService : BaseService<CustomerAddressDTO, ICustomerAddressRepository, InputIdentityViewCustomerAddress, InputCreateCustomerAddress, InputUpdateCustomerAddress, InputIdentityUpdateCustomerAddress, InputIdentityDeleteCustomerAddress, CustomerAddressValidateDTO, OutputCustomerAddress>, ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressValidateService _validate;
        public CustomerAddressService(ICustomerAddressRepository repository, ICustomerAddressValidateService validate, ICustomerRepository customerRepository) : base(repository)
        {
            _repository = repository;
            _validate = validate;
            _customerRepository = customerRepository;
        }

        public override async Task<BaseResult<List<OutputCustomerAddress>>> CreateMultiple(List<InputCreateCustomerAddress> listInputCreateCustomerAddress)
        {
            var listRelatedCustomerDTO = await _customerRepository.GetListByListId(listInputCreateCustomerAddress.Select(i => i.CustomerId).ToList());

            var newListCustomerAddressToValidate = (from i in listInputCreateCustomerAddress
                                                    select new
                                                    {
                                                        InputCreate = i,
                                                        RelatedCustomerDTO = listRelatedCustomerDTO.FirstOrDefault(j => j.Id == i.CustomerId)
                                                    }).ToList();

            var newListCustomerAddressValidateDTO = newListCustomerAddressToValidate.Select(i => new CustomerAddressValidateDTO().ValidateCreate(i.InputCreate, i.RelatedCustomerDTO)).ToList();
            _validate.Create(newListCustomerAddressValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputCustomerAddress>>.Failure(listNotification);

            var validlistCustomerAddress = (from i in RemoveInvalid(newListCustomerAddressValidateDTO) where !i.Invalid select i).ToList();

            var newListCustomerAddressToCreate = (from i in validlistCustomerAddress
                                                  let create = i.InputCreate
                                                  select new CustomerAddressDTO(create.CustomerId, create.Number, create.Complement, create.Reference, create.Neighborhood, create.PostalCode, create.Street)).ToList();

            await _repository.Create(newListCustomerAddressToCreate);

            return BaseResult<List<OutputCustomerAddress>>.Success(Conversor.GenericConvertList<OutputCustomerAddress, CustomerAddressValidateDTO>(validlistCustomerAddress), listNotification);
        }

        public override async Task<BaseResult<List<OutputCustomerAddress>>> UpdateMultiple(List<InputIdentityUpdateCustomerAddress> listInputIdentityUpdateCustomerAddress)
        {
            var listOriginalCustomerAddress = await _repository.GetListByListId(listInputIdentityUpdateCustomerAddress.Select(i => i.Id).ToList());

            var newListCustomerAddressToValidate = (from i in listInputIdentityUpdateCustomerAddress
                                                    select new
                                                    {
                                                        InputUpdate = i.InputUpdateCustomerAddress,
                                                        OriginalCustomerAddress = listOriginalCustomerAddress.FirstOrDefault(j => j.Id == i.Id)
                                                    }).ToList();

            var newListCustomerAddressValidateDTO = newListCustomerAddressToValidate.Select(i => new CustomerAddressValidateDTO().ValidateUpdate(i.InputUpdate, i.OriginalCustomerAddress)).ToList();
            _validate.Update(newListCustomerAddressValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<List<OutputCustomerAddress>>.Failure(listNotification);

            var validListCustomerAddress = (from i in RemoveInvalid(newListCustomerAddressValidateDTO) where !i.Invalid select i).ToList();

            (from i in validListCustomerAddress
             select UpdateDTO<CustomerAddressDTO, InputUpdateCustomerAddress>(i.OriginalCustomerAddress, i.InputUpdate)).ToList();

            var originalCustomerAddressListToUpdate = validListCustomerAddress.Select(i => i.OriginalCustomerAddress).ToList();

            await _repository.Update(originalCustomerAddressListToUpdate);
            return BaseResult<List<OutputCustomerAddress>>.Success(Conversor.GenericConvertList<OutputCustomerAddress, CustomerAddressDTO>(originalCustomerAddressListToUpdate), listNotification);
        }

        public override async Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCustomerAddress> listInputIdentityDeleteCustomerAddress)
        {
            var listOriginalCustomerAddress = await _repository.GetListByListId(listInputIdentityDeleteCustomerAddress.Select(i => i.Id).ToList());

            var newListCustomerAddressToValidate = (from i in listInputIdentityDeleteCustomerAddress
                                                    select new
                                                    {
                                                        InputDelete = i,
                                                        OriginalCustomerAddress = listOriginalCustomerAddress.FirstOrDefault(j => j.Id == i.Id)
                                                    }).ToList();

            var newListCustomerAddressValidateDTO = newListCustomerAddressToValidate.Select(i => new CustomerAddressValidateDTO().ValidateDelete(i.InputDelete, i.OriginalCustomerAddress)).ToList();
            _validate.Delete(newListCustomerAddressValidateDTO);

            var listNotification = NotificationBuilder.GetAll();

            if (listNotification.Where(i => i.Type == EnumNotificationType.Error).ToList().Count > 0 && listNotification.Where(i => i.Type == EnumNotificationType.Success).ToList().Count == 0)
                return BaseResult<bool>.Failure(listNotification);

            var validListCustomerAddress = (from i in RemoveInvalid(newListCustomerAddressValidateDTO) where !i.Invalid select i).ToList();
            await _repository.Delete(Conversor.GenericConvertList<CustomerAddressDTO, CustomerAddressValidateDTO>(validListCustomerAddress));

            return BaseResult<bool>.Success(true, listNotification);
        }

        public Task<List<CustomerAddressDTO>> GetListByListId(List<InputIdentityViewCustomerAddress> listInputIdentityView)
        {
            throw new NotImplementedException();
        }

        public static TOutput setValue<TOutput>(PropertyInfo property, TOutput output, object? value)
        {
            property.SetValue(output, value);
            return output;
        }
    }
}