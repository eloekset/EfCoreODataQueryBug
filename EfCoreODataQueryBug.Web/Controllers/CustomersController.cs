using EfCoreODataQueryBug.Web.Models;
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
            new Customer { CustomerId = 1, Name = "Customer 1" },
            new Customer { CustomerId = 2, Name = "Customer 2" },
            new Customer { CustomerId = 3, Name = "Customer 3" },
            new Customer { CustomerId = 4, Name = "Customer 4" },
            new Customer { CustomerId = 5, Name = "Customer 5" },
            new Customer { CustomerId = 6, Name = "Customer 6" },
            new Customer { CustomerId = 7, Name = "Customer 7" },
            new Customer { CustomerId = 8, Name = "Customer 8" },
            new Customer { CustomerId = 9, Name = "Customer 9" },
            new Customer { CustomerId = 10, Name = "Customer 10" },
            new Customer { CustomerId = 11, Name = "Customer 11" },
            new Customer { CustomerId = 12, Name = "Customer 12" },
            new Customer { CustomerId = 13, Name = "Customer 13" },
            new Customer { CustomerId = 14, Name = "Customer 14" },
            new Customer { CustomerId = 15, Name = "Customer 15" },
            new Customer { CustomerId = 16, Name = "Customer 16" },
            new Customer { CustomerId = 17, Name = "Customer 17" },
            new Customer { CustomerId = 18, Name = "Customer 18" },
            new Customer { CustomerId = 19, Name = "Customer 19" },
            new Customer { CustomerId = 20, Name = "Customer 20" },
            new Customer { CustomerId = 21, Name = "Customer 21" },
            new Customer { CustomerId = 22, Name = "Customer 22" },
            new Customer { CustomerId = 23, Name = "Customer 23" },
            new Customer { CustomerId = 24, Name = "Customer 24" },
            new Customer { CustomerId = 25, Name = "Customer 25" },
            new Customer { CustomerId = 26, Name = "Customer 26" },
            new Customer { CustomerId = 27, Name = "Customer 27" },
            new Customer { CustomerId = 28, Name = "Customer 28" },
            new Customer { CustomerId = 29, Name = "Customer 29" }
        };

        [EnableQuery(PageSize = 5, AllowedQueryOptions = System.Web.OData.Query.AllowedQueryOptions.All)]
        // Query filter doesn't work with EFCore even though the bug should have been fixed in an earlier version:
        // https://github.com/aspnet/EntityFramework/issues/5877
        [ODataRoute]
        public IQueryable<Customer> Get()
        {
            return _customers.AsQueryable();
        }
    }
}