using Dsa.Domain.Core.Models;
using System;

namespace Dsa.Domain.Models
{
    public class Address : ValueObject<Address>
    {
        public Address(string province, string city, string district, string street)
        {
            Province = province;
            City = city;
            District = district;
            Street = street;
        }

        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
