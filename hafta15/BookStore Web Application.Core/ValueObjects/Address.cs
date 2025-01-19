﻿using System.Collections.Generic;

namespace BookStore_Web_Application.Core.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        private Address()
        {
            Street = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Country = string.Empty;
            ZipCode = string.Empty;
        }

        public Address(string street, string city, string state, string country, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }

    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        // Other utility methods for value objects can be added here
    }
}
