using Arguments.Argument.Base.ApiResponse;
using Arguments.Argument.Base.Crud;
using Arguments.Argument.Interface;
using Domain.DTO.Base;
using Domain.Interface.Base;
using Domain.Interface.Service.Base;
using System.Reflection;
namespace Domain.Service.Base
{
    public class BaseService<TDTO, TRepository, TInputIdentityView, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TValidateDTO, TOutput> : BaseValidate<TValidateDTO>, IBaseService<TDTO, TOutput, TInputIdentityView, TInputCreate, TInputIdentityUpdate, TInputIdentityDelete>
        where TDTO : BaseDTO
        where TRepository : IBaseRepository<TDTO, TInputIdentityView>
        where TInputIdentityView : BaseInputIdentityView<TInputIdentityView>, IBaseIdentityView
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputIdentityUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TValidateDTO : BaseValidateDTO
        where TOutput : BaseOutput<TOutput>, new()
    {
        private readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<List<TDTO>> GetListByListId(List<TInputIdentityView> listInputIdentityView)
        {
            return await _repository.GetListByListId(listInputIdentityView.Select(i => i.Id).ToList());
        }

        public async Task<TDTO?> GetById(TInputIdentityView inputIdentityView)
        {
            return await _repository.GetById(inputIdentityView);
        }

        public virtual async Task<BaseResult<List<TOutput>>> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<BaseResult<List<TOutput>>> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<BaseResult<bool>> DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            throw new NotImplementedException();
        }

        public static bool UpdateDTO<TDestination, TSource>(TDestination destination, TSource source)
            where TDestination : BaseDTO
            where TSource : BaseInputUpdate<TSource>
        {
            (from i in source.GetType().GetProperties()
             let property = destination.GetType().GetProperty(i.Name)
             where property != null
             let value = i.GetValue(source)
             select setValue(property, destination, value)).ToList();

            return true;
        }
        public static bool setValue<TDestination>(PropertyInfo property, TDestination destination, object? value)
        {
            property.SetValue(destination, value);
            return true;
        }
    }
}