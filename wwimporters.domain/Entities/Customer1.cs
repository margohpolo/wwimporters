using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace wwimporters.domain.Entities
{
    public partial class Customer1
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerCategoryName { get; set; }
        public string? PrimaryContact { get; set; }
        public string? AlternateContact { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string FaxNumber { get; set; } = null!;
        public string? BuyingGroupName { get; set; }
        public string WebsiteUrl { get; set; } = null!;
        public string? DeliveryMethod { get; set; }
        public string? CityName { get; set; }
        public Geometry? DeliveryLocation { get; set; }
        public string? DeliveryRun { get; set; }
        public string? RunPosition { get; set; }
    }
}
