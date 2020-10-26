using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SplitwiseApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitwiseApp.Repository.Test.DatabaseTest
{
    public class FakeUserManager:UserManager<ApplicationUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<ApplicationUser>>().Object,
                  new Mock<IOptions<IdentityOptions>>().Object,
                  new Mock<IPasswordHasher<ApplicationUser>>().Object,
                  new[] { new Mock<IUserValidator<ApplicationUser>>().Object
                        },
                    new[] { new Mock<IPasswordValidator<ApplicationUser>>().Object
                          },
                  new Mock<ILookupNormalizer>().Object,
                  new Mock<IdentityErrorDescriber>().Object,
                  new Mock<IServiceProvider>().Object,
                  new Mock<ILogger<UserManager<ApplicationUser>>>().Object)
        { }
    }
}
