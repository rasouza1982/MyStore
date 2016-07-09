using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Specs;

namespace MyStore.Domain.Tests.Account.Specs
{
    [TestClass]
    
    public class UserSpecsTests
    {
        private List<User> _users;

        public UserSpecsTests()
        {
            _users = new List<User>();
            _users.Add(new User("souza.rafael@gmail.com", "rasouza1982", "123456"));
            _users.Add(new User("ironman@gmail.com", "ironman", "123456"));
            _users.Add(new User("batman@gmail.com", "batman", "123456"));
            _users.Add(new User("spiderman@gmail.com", "spiderman", "123456"));
        }


        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShouldReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("rasouza1982"))
                .FirstOrDefault();

            Assert.AreNotEqual(null, user);
         }


        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUsernameShouldNotReturnValue()
        {
            var user = _users
                .AsQueryable()
                .Where(UserSpecs.GetByUsername("rasouza198221384"))
                .FirstOrDefault();

            Assert.AreEqual(null, user);
        }

    }
}
