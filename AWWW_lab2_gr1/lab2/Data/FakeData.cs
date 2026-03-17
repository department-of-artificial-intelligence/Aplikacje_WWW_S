using System;

using lab2.Models;

namespace lab2.Data;

public static class FakeData
{
    public static List<Category> Categories { get; } = new()
    {
        new Category { Id = 1, Name = "Elektronika" },
        new Category { Id = 2, Name = "Książki" }
    };

    public static List<Tag> Tags { get; } = new()
    {
        new Tag { Id = 1, Name = "Nowość" },
        new Tag { Id = 2, Name = "Promocja" }
    };

    public static List<Address> Addresses { get; } = new()
    {
        new Address
        {
            Id = 1,
            City = "Czestochowa",
            Street = "Dabrowskiego 73",
            PostalCode = "00-001",
            CustomerId = 1
        }
    };
}
