// See https://aka.ms/new-console-template for more information

using EFWithDDD.Data.Context;
using EFWithDDD.Entity;
using EFWithDDD.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

ApplicationDbContext context = new ApplicationDbContext();

var company = new Company(0, "JN Moura Informática");
var address = new Address(0, company, "Rua Hilda Zamboni Queiros", 70, null, 0);
var name = new Name("Thiago", "Poderoso");

var customer = new Customer(0,
    company,
    name, 
    null, 
    address);

customer.AddJobFunction(new JobFunction(0, company, "Polentador"));
customer.AddJobFunction(new JobFunction(0, company, "Programador"));
customer.AddJobFunction(new JobFunction(0, company, "Analista"));
customer.AddJobFunction(new JobFunction(0, company, "Crente"));



context.Customers.Add(customer);
await context.SaveChangesAsync();

var result = context.Customers.FirstOrDefault();
Console.WriteLine(result?.ToString());