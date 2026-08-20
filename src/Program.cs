using Microsoft.EntityFrameworkCore;
using Phonebook.Data;

using var context = new AppDbContext();

// Code-First: EF creates the database + schema (and seed data) on first run
context.Database.EnsureCreated();

var contacts = await context.Contacts.AsNoTracking().OrderBy(c => c.Name).ToListAsync();

Console.WriteLine($"{contacts.Count} contact(s) in the database:");
foreach (var c in contacts)
    Console.WriteLine($"  {c.Id}. {c.Name} ({c.Category}) — {c.Email} — {c.PhoneNumber}");
