﻿using SOLIDplate.Domain.Command.Services.Interfaces;
using SOLIDplate.Infrastructure.Repository.Interfaces;

namespace SOLIDplate.Domain.Command.Services
{
    public abstract class DomainService<TEntity, TUnitOfWork, TEntityRepository> : IDomainService<TEntity>
        where TEntity : class, new()
        where TEntityRepository : IEntityRepository<TEntity>
    {
        protected TUnitOfWork UnitOfWork { get; private set; }
        protected TEntityRepository Repository { get; private set; }
        protected string EntityTypeName => typeof(TEntity).Name;

        protected DomainService(TUnitOfWork unitOfWork, TEntityRepository entityRepository)
        {
            UnitOfWork = unitOfWork;
            Repository = entityRepository;
        }

        public abstract void Add(TEntity entityToAdd);

        public abstract void Update(TEntity entityWithUpdates);

        public abstract void Delete(int id);

        protected abstract void PrimeEntityForPersistance(TEntity entityToPrime, bool primeForAdd);
        protected abstract void ValidateEntity(TEntity entity);
    }
}
