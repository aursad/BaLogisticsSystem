using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository;
using BaLogisticsSystem.Repository.Common;
using BaLogisticsSystem.Repository.Organization;
using BaLogisticsSystem.Service.Common;

namespace BaLogisticsSystem.Service.Organizations
{
    public class OrganizationService : EntityService<OrganizationEntity>, IOrganizationService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IUnitOfWork unitOfWork, IOrganizationRepository organizationRepository)
            : base(unitOfWork, organizationRepository)
        {
            _unitOfWork = unitOfWork;
            _organizationRepository = organizationRepository;
        }

        public OrganizationEntity GetSingle(Guid userId)
        {
            return _organizationRepository.GetSingle(userId);
        }

        public IEnumerable<OrganizationEntity> GetList()
        {
            return _organizationRepository.GetAll();
        }

        public void CreateOrganization(OrganizationEntity personEntity)
        {
            personEntity.IdOrganization = Guid.NewGuid();
            personEntity.CreatedDate = DateTime.Now;
            personEntity.UpdatedDate = DateTime.Now;

            _organizationRepository.Add(personEntity);
            _organizationRepository.Save();
        }
    }
}
