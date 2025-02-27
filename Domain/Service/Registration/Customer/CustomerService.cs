using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Enum;
using Arguments.Argument.Registration.Customer;
using Arguments.Conversor;
using Domain.DTO.Entity.Customer;
using Domain.Interface.Repository;
using Domain.Interface.Service.Customer;
using Domain.Service.Base;
using System.Reflection;

namespace Domain.Service.Registration.CustomerService
{
    public class CustomerService : BaseService<CustomerDTO, ICustomerRepository, InputIdentityViewCustomer, InputCreateCustomer, InputUpdateCustomer, InputIdentityUpdateCustomer, InputIdentityDeleteCustomer, CustomerValidateDTO, OutputCustomer>, ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerValidateService _validate;
        public CustomerService(ICustomerRepository repository, ICustomerValidateService validate) : base(repository)
        {
            _repository = repository;
            _validate = validate;
        }

        public override async Task<BaseResult<List<OutputCustomer>>> CreateMultiple(List<InputCreateCustomer> listInputCreateCustomer)
        {
            var listOriginalCustomer = await _repository.GetAll();
            var selectedListOriginalCustomer = listOriginalCustomer.Select(i => i.Code);

            var repeatedCode = (from i in listInputCreateCustomer
                                where listInputCreateCustomer.Count(j => j.Code == i.Code) > 1
                                select i).ToList();

            List<EnumValidateType> validateBirthDate = (from i in listInputCreateCustomer
                                                        let getInvalid = _validate.InvalidBirthDate(i.BirthDate, 8)
                                                        select getInvalid).ToList();

            var listNewInputCustomerToValidate = (from i in listInputCreateCustomer
                                                  select new
                                                  {
                                                      InputCreateCustomer = i,
                                                      ExistingCode = selectedListOriginalCustomer.FirstOrDefault(j => j == i.Code),
                                                      RepeatedCode = repeatedCode.FirstOrDefault(),
                                                      InvalidBirthDate = validateBirthDate.FirstOrDefault()
                                                  }).ToList();

            var listNewCustomerValidateDTO = listNewInputCustomerToValidate.Select(i => new CustomerValidateDTO().ValidateCreate(i.InputCreateCustomer, i.ExistingCode, i.RepeatedCode, i.InvalidBirthDate)).ToList();
            _validate.Create(listNewCustomerValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<List<OutputCustomer>>.Failure(error);

            var validlistCustomer = (from i in RemoveInvalid(listNewCustomerValidateDTO) where !i.Invalid select i).ToList();

            var newListCustomer = (from i in validlistCustomer
                                   let create = i.InputCreateCustomer
                                   select new CustomerDTO(create.FirstName, create.LastName, create.Code, create.Phone, create.BirthDate, create.Document)).ToList();

            await _repository.Create(newListCustomer);

            return BaseResult<List<OutputCustomer>>.Success(Conversor.GenericConvertList<OutputCustomer, CustomerValidateDTO>(listNewCustomerValidateDTO), [.. success, .. error]);
        }

        public override async Task<BaseResult<List<OutputCustomer>>> UpdateMultiple(List<InputIdentityUpdateCustomer> listInputIdentityUpdateCustomer)
        {
            var listOriginalCustomer = await _repository.GetListByListId(listInputIdentityUpdateCustomer.Select(i => i.Id).ToList());

            List<EnumValidateType> validateBirthDate = (from i in listInputIdentityUpdateCustomer
                                                        let getInvalid = _validate.InvalidBirthDate(i.InputUpdateCustomer.BirthDate, 8)
                                                        select getInvalid).ToList();

            var repeatedCode = (from i in listInputIdentityUpdateCustomer
                                where listInputIdentityUpdateCustomer.Count(j => j.InputUpdateCustomer.Code == i.InputUpdateCustomer.Code) > 1
                                select i).ToList();

            var newListInputCustomerToValidate = (from i in listInputIdentityUpdateCustomer
                                                  select new
                                                  {
                                                      InputUpdateCustomer = i,
                                                      ExistingCode = listOriginalCustomer.FirstOrDefault(j => j.Code == i.InputUpdateCustomer.Code && j.Id != i.Id).Code,
                                                      RepeatedCode = repeatedCode.FirstOrDefault(),
                                                      InvalidBirthDate = validateBirthDate.FirstOrDefault()
                                                  }).ToList();

            var listNewCustomerValidateDTO = newListInputCustomerToValidate.Select(i => new CustomerValidateDTO().ValidateUpdate(i.InputUpdateCustomer, i.ExistingCode, i.RepeatedCode, i.InvalidBirthDate)).ToList();
            _validate.Update(listNewCustomerValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<List<OutputCustomer>>.Failure(error);

            var validlistCustomer = (from i in RemoveInvalid(listNewCustomerValidateDTO) where !i.Invalid select i).ToList();

            var listCustomerToUpdate = (from i in validlistCustomer.GetType().GetProperties()
                                        from j in listOriginalCustomer
                                        let properties = j.GetType().GetProperty(i.Name)
                                        where properties != null
                                        let value = setValue(properties, j, i.GetValue(i.Name))
                                        select value).ToList();

            await _repository.Update(listOriginalCustomer);

            return BaseResult<List<OutputCustomer>>.Success(Conversor.GenericConvertList<OutputCustomer, CustomerValidateDTO>(listNewCustomerValidateDTO), [.. success, .. error]);
        }

        public override async Task<BaseResult<bool>> DeleteMultiple(List<InputIdentityDeleteCustomer> listInputIdentityDeleteCustomer)
        {
            var listOriginalCustomer = await _repository.GetListByListId(listInputIdentityDeleteCustomer.Select(i => i.Id).ToList());

            var newListCustomerToDelete = (from i in listInputIdentityDeleteCustomer
                                           select new
                                           {
                                               InputIdentityDeleteCustomer = i,
                                               OriginalCustomer = listOriginalCustomer.FirstOrDefault(j => j.Id == i.Id)
                                           }).ToList();

            var listNewCustomerValidateDTO = newListCustomerToDelete.Select(i => new CustomerValidateDTO().ValidateDelete(i.InputIdentityDeleteCustomer, i.OriginalCustomer)).ToList();
            _validate.Delete(listNewCustomerValidateDTO);

            var (success, error) = GetValidationResult();

            if (success.Count == 0 && error.Count > 0)
                return BaseResult<bool>.Failure(error);

            var validCustomerToDelete = (from i in RemoveInvalid(listNewCustomerValidateDTO) where !i.Invalid select i).ToList();

            await _repository.Delete(listOriginalCustomer);

            return BaseResult<bool>.Success(true, [.. success, .. error]);
        }
    }
}