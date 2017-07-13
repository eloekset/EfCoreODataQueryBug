using System;

namespace EfCoreODataQueryBug.Web.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CustomerSince { get; set; }
        public bool IsActive { get; set; }
    }
}