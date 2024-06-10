using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.DAL;

namespace Kolokwium.Test.UnitTests
{
    public abstract class BaseUnitTests
    {
        protected readonly ApplicationDbContext DbContext;

        public BaseUnitTests(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
