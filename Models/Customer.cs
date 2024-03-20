using System;
using System.Collections.Generic;

namespace WebApplicationDemo.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? GovernmentId { get; set; }

    public int? Age { get; set; }

    public char? Sex { get; set; }

    public string? Tel { get; set; }

    public string? Email { get; set; }

    public Customer(int id, string? name, string? lastName, string? governmentId, int? age, char? sex, string? tel, string? email)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        GovernmentId = governmentId;
        Age = age;
        Sex = sex;
        Tel = tel;
        Email = email;
    }
}
