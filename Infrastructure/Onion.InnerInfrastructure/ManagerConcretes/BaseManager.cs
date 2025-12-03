using AutoMapper;
using Onion.Application.DtoInterfaces;
using Onion.Application.ManagerInterfaces;
using Onion.Contract.RepositoryInterfaces;
using Onion.Domain.Enums;
using Onion.Domain.Interfaces;

namespace Onion.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        protected BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            U domainEntity = _mapper.Map<U>(entity);
            domainEntity.CreatedDate = DateTime.Now;
            domainEntity.Status = DataStatus.Inserted;

            await _repository.CreateAsync(domainEntity);
        }

        public List<T> GetActives()
        {
            List<U> values = _repository.Where(x => x.Status != DataStatus.Deleted).ToList();
            return _mapper.Map<List<T>>(values);
        }


        public async Task<List<T>> GetAllAsync()
        {
            List<U> values = await _repository.GetAllAsync();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            U value = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(value);
        }

        public List<T> GetPassives()
        {
            List<U> values = _repository.Where(x => x.Status == DataStatus.Deleted).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public List<T> GetUpdateds()
        {
            List<U> values = _repository.Where(x => x.Status == DataStatus.Updated).ToList();
            return _mapper.Map<List<T>>(values);
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            U originalValue = await _repository.GetByIdAsync(id);

            if (originalValue == null || originalValue.Status != DataStatus.Deleted)
                return "Sadece pasif ve bulunabilen veriler silinebilir";

            await _repository.DeleteAsync(originalValue);

            return $"{id} id'li veri silinmistir";
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            U originalValue = await _repository.GetByIdAsync(id);

            if (originalValue == null || originalValue.Status == DataStatus.Deleted)
                return "Veri pasif veya  bulunumadı";

            originalValue.Status = DataStatus.Deleted;
            originalValue.DeletedDate = DateTime.Now;
            await _repository.SaveChangesAsync();

            return $"{id} id'li veri pasife cekiilmistir";
        }

        public async Task UpdateAsync(T entity)
        {
            U originalValue = await _repository.GetByIdAsync(entity.Id);

            U newValue = _mapper.Map<U>(entity);
            newValue.UpdatedDate = DateTime.Now;
            newValue.Status = DataStatus.Updated;

            await _repository.UpdateAsync(originalValue, newValue);
        }
    }
}
