using System.Linq;
using AutoMapper;
using JimHalpert.Application.AutoMapper;
using JimHalpert.Application.Interface;
using JimHalpert.DomainValidator;
using JimHalpert.Repository.Interfaces;

namespace JimHalpert.Application.Services
{
    public class BaseServiceApp : IBaseServiceApp
    {
        private readonly IUnitOfWork uow;
        protected readonly IMapper Mapper;
        protected ValidationResult ValidationResults;

        public BaseServiceApp(IUnitOfWork uow)
        {
            this.uow = uow;
            AutoMapperConfig.RegisterMappings();
            Mapper = AutoMapperConfig.Config.CreateMapper();
            ValidationResults = new ValidationResult();
        }

        public void BeginTransaction()
        {
            uow.BeginTransaction();
        }

        public void Commit()
        {
            var retorno = uow.SaveChanges();
            if (!retorno.IsValid)
            {
                retorno.Erros.ToList().ForEach(e => ValidationResults.Add(e.Messagem));
            }
        }
    }
}
