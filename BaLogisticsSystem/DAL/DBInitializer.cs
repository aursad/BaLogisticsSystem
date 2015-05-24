using System;
using System.Collections.Generic;
using System.Data.Entity;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.DAL
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<BaLogisticsSystemContext>
    {
        #region private entities guids

        private readonly Guid _defaultOrganizationGuid = Guid.NewGuid();
        private readonly Guid _defaultPerson = Guid.NewGuid();
        private readonly Guid _defaultService = Guid.NewGuid();
        private readonly Guid _defaultShipment = Guid.NewGuid();

        #endregion

        protected override void Seed(BaLogisticsSystemContext context)
        {
            #region fill DB context
            foreach (var organization in DefaultOrganizations())
            {
                context.Organizations.Add(organization);
            }
            foreach (var person in DefaultPersons())
            {
                context.Persons.Add(person);
            }
            foreach (var service in DefaultServices())
            {
                context.Services.Add(service);
            }
            foreach (var shipment in DefaultShipments())
            {
                context.Shipments.Add(shipment);
            }
            foreach (var transaction in DefaultTransactions())
            {
                context.Transactions.Add(transaction);
            }
            #endregion

            base.Seed(context);
        }

        #region -- Fill test data

        private IEnumerable<OrganizationEntity> DefaultOrganizations()
        {
            var defaultOrganizations = new List<OrganizationEntity>
            {
                new OrganizationEntity
                {
                    IdOrganization = _defaultOrganizationGuid,
                    Name = "Default Test Organization",
                    Address = "Gedimino pr. 1, Vilnius",
                    OrganizationType = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new OrganizationEntity
                {
                    IdOrganization = Guid.NewGuid(),
                    Name = "AB „Lietuvos geležinkeliai“",
                    Address = "Mindaugo 12, 03603 Vilnius",
                    OrganizationType = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            };
            return defaultOrganizations;
        }
        private IEnumerable<PersonEntity> DefaultPersons()
        {
            var defaultPersons = new List<PersonEntity>
            {
                new PersonEntity { 
                    Id = 1, 
                    IdPerson = _defaultPerson,
                    UserName = "admin", 
                    Email = "aurimas.sadauskas@gmail.com", 
                    Name = "Aurimas", 
                    LastName = "Sadauskas",
                    Birthday = new DateTime(1992,01,22),
                    Address = "Vilnius",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IdOrganization = _defaultOrganizationGuid,
                    IsBlocked = false,
                    SecurityLevel = 5
                },
                new PersonEntity { 
                    Id = 2, 
                    IdPerson = Guid.NewGuid(),
                    UserName = "test.user", 
                    Email = "test.user@test.com", 
                    Name = "Test", 
                    LastName = "User",
                    Birthday = new DateTime(2015,05,22),
                    Address = "Vilnius",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IdOrganization = _defaultOrganizationGuid,
                    IsBlocked = false,
                    SecurityLevel = 1
                }
            };
            return defaultPersons;
        }
        private IEnumerable<ServiceEntity> DefaultServices()
        {
            var defaultServices = new List<ServiceEntity>
            {
                new ServiceEntity
                {
                    Id = 1,
                    IdService = _defaultService,
                    Title = "Testavimo gabenimas",
                    IdOrganization = _defaultOrganizationGuid,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ServiceEntity
                {
                    Id = 2,
                    IdService = Guid.NewGuid(),
                    Title = "Kaunas - Vilnius autobusas",
                    IdOrganization = _defaultOrganizationGuid,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ServiceEntity
                {
                    Id = 3,
                    IdService = Guid.NewGuid(),
                    Title = "Vilnius - Klaipėda traukinys",
                    IdOrganization = _defaultOrganizationGuid,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            };
            return defaultServices;
        }
        private IEnumerable<ShipmentEntity> DefaultShipments()
        {
            var defaultServices = new List<ShipmentEntity>
            {
                new ShipmentEntity
                {
                    Id = 1,
                    IdShipment = _defaultShipment,
                    IdService = _defaultService,
                    Title = "AK000001",
                    Longitude = 54.6991309,
                    Latitude = 25.285686,
                    IdPerson = _defaultPerson,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ShipmentEntity
                {
                    Id = 2,
                    IdShipment = Guid.NewGuid(),
                    IdService = _defaultService,
                    Title = "AK000002",
                    Longitude = 54.6891603,
                    Latitude = 25.2826819,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new ShipmentEntity
                {
                    Id = 3,
                    IdShipment = Guid.NewGuid(),
                    IdService = _defaultService,
                    Title = "AK000003",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
            };
            return defaultServices;
        }
        private IEnumerable<TransactionEntity> DefaultTransactions()
        {
            var defaultServices = new List<TransactionEntity>
            {
                new TransactionEntity
                {
                    Id = 1,
                    IdTransaction = Guid.NewGuid(),
                    IdShipment = _defaultShipment,
                    Longitude = 54.9991309,
                    Latitude = 25.685686,
                    IdPerson = _defaultPerson,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now.AddMinutes(3),
                },
                new TransactionEntity
                {
                    Id = 2,
                    IdTransaction = Guid.NewGuid(),
                    IdShipment = _defaultShipment,
                    Longitude = 54.6891603,
                    Latitude = 25.2826819,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now.AddMinutes(5),
                }
            };
            return defaultServices;
        }
        #endregion
    }
}
