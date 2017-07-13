using EfCoreODataQueryBug.Web.Data;
using EfCoreODataQueryBug.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using System.Web.OData.Routing;

namespace EfCoreODataQueryBug.Web.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly Customer[] _customers = {
            new Customer { CustomerId = 1, Name = "Customer 1", CustomerSince = DateTimeOffset.Parse("1997-05-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 2, Name = "Customer 2", CustomerSince = DateTimeOffset.Parse("2003-04-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 3, Name = "Customer 3", CustomerSince = DateTimeOffset.Parse("2002-03-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 4, Name = "Customer 4", CustomerSince = DateTimeOffset.Parse("2010-02-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 5, Name = "Customer 5", CustomerSince = DateTimeOffset.Parse("2015-05-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 6, Name = "Customer 6", CustomerSince = DateTimeOffset.Parse("1999-06-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 7, Name = "Customer 7", CustomerSince = DateTimeOffset.Parse("2014-08-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 8, Name = "Customer 8", CustomerSince = DateTimeOffset.Parse("2013-01-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 9, Name = "Customer 9", CustomerSince = DateTimeOffset.Parse("2012-02-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 10, Name = "Customer 10", CustomerSince = DateTimeOffset.Parse("2011-06-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 11, Name = "Customer 11", CustomerSince = DateTimeOffset.Parse("2010-07-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 12, Name = "Customer 12", CustomerSince = DateTimeOffset.Parse("2005-10-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 13, Name = "Customer 13", CustomerSince = DateTimeOffset.Parse("2000-11-05T00:00:00Z"), IsActive = false },
            new Customer { CustomerId = 14, Name = "Customer 14", CustomerSince = DateTimeOffset.Parse("2001-10-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 15, Name = "Customer 15", CustomerSince = DateTimeOffset.Parse("2002-04-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 16, Name = "Customer 16", CustomerSince = DateTimeOffset.Parse("2004-03-05T00:00:00Z"), IsActive = false },
            new Customer { CustomerId = 17, Name = "Customer 17", CustomerSince = DateTimeOffset.Parse("2014-06-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 18, Name = "Customer 18", CustomerSince = DateTimeOffset.Parse("2016-05-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 19, Name = "Customer 19", CustomerSince = DateTimeOffset.Parse("2016-09-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 20, Name = "Customer 20", CustomerSince = DateTimeOffset.Parse("2015-08-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 21, Name = "Customer 21", CustomerSince = DateTimeOffset.Parse("2015-07-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 22, Name = "Customer 22", CustomerSince = DateTimeOffset.Parse("2014-06-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 23, Name = "Customer 23", CustomerSince = DateTimeOffset.Parse("2013-05-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 24, Name = "Customer 24", CustomerSince = DateTimeOffset.Parse("2012-03-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 25, Name = "Customer 25", CustomerSince = DateTimeOffset.Parse("2010-01-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 26, Name = "Customer 26", CustomerSince = DateTimeOffset.Parse("2011-12-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 27, Name = "Customer 27", CustomerSince = DateTimeOffset.Parse("2012-11-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 28, Name = "Customer 28", CustomerSince = DateTimeOffset.Parse("2014-10-05T00:00:00Z"), IsActive = true },
            new Customer { CustomerId = 29, Name = "Customer 29", CustomerSince = DateTimeOffset.Parse("2016-05-05T00:00:00Z"), IsActive = true }
        };
        private SampleDbContext _dbContext;

        public CustomersController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase("Customers");
            _dbContext = new SampleDbContext(optionsBuilder.Options);

            if (_dbContext.Customers.Count() == 0)
            {
                AddSampleCustomersToInMemDb();
            }
        }

        private void AddSampleCustomersToInMemDb()
        {
            _dbContext.Customers.AddRange(_customers);
            _dbContext.SaveChanges();
        }

        [EnableQuery(PageSize = 5, AllowedQueryOptions = System.Web.OData.Query.AllowedQueryOptions.All)]
        // Query filter doesn't work with EFCore even though the bug should have been fixed in an earlier version:
        // https://github.com/aspnet/EntityFramework/issues/5877
        [ODataRoute]
        public IQueryable<Customer> Get()
        {
            return _dbContext.Customers.AsQueryable();
        }
    }
}