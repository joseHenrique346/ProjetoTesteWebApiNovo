using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Registration.CustomerAddress;
using Arguments.Conversor;
using Domain.DTO.Entity.Brand;
using Domain.DTO.Entity.CustomerAddress;
using Domain.Interface.Repository;
using Domain.Interface.Service.CustomerAddress;
using Domain.Service.Base;
using System.Runtime.CompilerServices;

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
                                                        InputCreateCustomerAddress = i,
                                                        RelatedCustomerDTO = listRelatedCustomerDTO.FirstOrDefault(j => j.Id == i.CustomerId)
                                                    }).ToList();

            var newListCustomerAddressValidateDTO = newListCustomerAddressToValidate.Select(i => new CustomerAddressValidateDTO().ValidateCreate(i.InputCreateCustomerAddress, i.RelatedCustomerDTO)).ToList();
            _validate.Create(newListCustomerAddressValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<List<OutputCustomerAddress>>.Failure(error);

            var validlistCustomerAddress = (from i in RemoveInvalid(newListCustomerAddressValidateDTO) where !i.Invalid select i).ToList();

            var newListCustomerAddressToCreate = (from i in validlistCustomerAddress
                                                  let create = i.InputCreateCustomerAddress
                                                  select new CustomerAddressDTO(create.CustomerId, create.Number, create.Complement, create.Reference, create.Neighborhood, create.PostalCode, create.Street)).ToList();

            await _repository.Create(newListCustomerAddressToCreate);

            return BaseResult<List<OutputCustomerAddress>>.Success(Conversor.GenericConvertList<OutputCustomerAddress, CustomerAddressValidateDTO>(validlistCustomerAddress), [.. success, .. error]);
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

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<List<OutputCustomerAddress>>.Failure(error);

            var validListCustomerAddress = (from i in RemoveInvalid(newListCustomerAddressValidateDTO) where !i.Invalid select i).ToList();

            var newListCustomerAddressToUpdate = (from i in validListCustomerAddress.GetType().GetProperties()
                                                  from j in listOriginalCustomerAddress
                                                  let properties = j.GetType().GetProperty(i.Name)
                                                  where properties != null
                                                  select setValue(properties, j, i.GetValue(i.Name))).ToList();

            await _repository.Update(newListCustomerAddressToUpdate);
            return BaseResult<List<OutputCustomerAddress>>.Success(Conversor.GenericConvertList<OutputCustomerAddress, CustomerAddressDTO>(newListCustomerAddressToUpdate), [.. success, .. error]);
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

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<bool>.Failure(error);

            var validListCustomerAddress = (from i in RemoveInvalid(newListCustomerAddressValidateDTO) where !i.Invalid select i).ToList();
            await _repository.Delete(Conversor.GenericConvertList<CustomerAddressDTO, CustomerAddressValidateDTO>(validListCustomerAddress));

            return BaseResult<bool>.Success(true, [.. success, .. error]);
        }
    }
}