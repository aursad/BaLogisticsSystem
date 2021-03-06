﻿using System;
using System.Collections.Generic;
using BaLogisticsSystem.Models;
using BaLogisticsSystem.Repository.Common;
using BaLogisticsSystem.Repository.Person;
using BaLogisticsSystem.Service.Common;

namespace BaLogisticsSystem.Service.Persons
{
    public class PersonsService : EntityService<PersonEntity>, IPersonsService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IPersonsRepository _personsRepository;

        public PersonsService(IUnitOfWork unitOfWork, IPersonsRepository personsRepository)
            : base(unitOfWork, personsRepository)
        {
            _unitOfWork = unitOfWork;
            _personsRepository = personsRepository;
        }

        public PersonEntity GetSingle(Guid userId)
        {
            return _personsRepository.GetSingle(userId);
        }

        public PersonEntity GetSingle(string email)
        {
            return _personsRepository.GetSingle(email);
        }

        public IEnumerable<PersonEntity> GetList()
        {
            return _personsRepository.GetAll();
        }

        public void CreatePerson(PersonEntity personEntity)
        {
            personEntity.IdPerson = Guid.NewGuid();
            personEntity.CreatedDate = DateTime.Now;
            personEntity.UpdatedDate = DateTime.Now;
            personEntity.IdOrganization = Guid.NewGuid();
            personEntity.UserName = personEntity.Email;

            _personsRepository.Add(personEntity);
        }

        public bool BlockUser(Guid idPerson)
        {
            var entity = _personsRepository.GetSingle(idPerson);
            if (entity != null)
            {
                entity.IsBlocked = !entity.IsBlocked;
            }
            else
            {
                throw new Exception(string.Format("Person with id: {0} not exist!", idPerson));
            }

            _personsRepository.Update(entity);
            return entity.IsBlocked;
        }


        public IEnumerable<PersonEntity> PersonsInOrganization(Guid idOrganization)
        {
            return _personsRepository.PersonsInOrganization(idOrganization);
        }
    }
}
