using System;
using System.Collections.Generic;
using System.Data.Entity;
using BaLogisticsSystem.Models;

namespace BaLogisticsSystem.DAL
{
    public class DbInitializer: DropCreateDatabaseAlways<BaLogisticsSystemContext>
    {
        protected override void Seed(BaLogisticsSystemContext context)
        {
            // -- FIll users
            var defaultUsers = new List<UserProfileEntity>
            {
                new UserProfileEntity { UserId = 1, UserName = "admin"}
            };

            foreach (var user in defaultUsers)
            {
                context.UserProfiles.Add(user);
            }
            // -- Fill persons
            var defaultPersons = new List<PersonEntity>
            {
                new PersonEntity { 
                    Id = 1, 
                    IdPerson = Guid.NewGuid(),
                    UserName = "admin", 
                    Email = "aurimas.sadauskas@gmail.com", 
                    Name = "Aurimas", 
                    Surname = "Sadauskas",
                    Birthday = new DateTime(1992,01,22),
                    Address = "Vilnius",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            };

            foreach (var person in defaultPersons)
            {
                context.Persons.Add(person);
            }


            base.Seed(context);
        }
    }
}
