using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWarsAPI.Models;

namespace StarWarsAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                
                if (!context.Users.Any())
                {
                    
                    var users = new[]
                    {
                        new ApplicationUser { UserName = "user1@example.com", Email = "user1@example.com" },
                        new ApplicationUser { UserName = "user2@example.com", Email = "user2@example.com" }
                    };

                    foreach (var user in users)
                    {
                        var result = userManager.CreateAsync(user, "password").Result;
                        if (!result.Succeeded)
                            throw new Exception($"Ошибка при создании пользователя: {result.Errors.FirstOrDefault()?.Description}");
                    }
                }

                
                if (!context.Characters.Any())
                {
                    var user = context.Users.First();
                    var characters = new[]
                    {
                        new Character
                        {
                            Id=1,
                            Name = "Luke Skywalker",
                            BirthDate = new DateTime(2000, 1, 1),
                            Planet = "Tatooine",
                            Gender = "Male",
                            Race = "Human",
                            Height = 175,
                            HairColor = "Blond",
                            EyeColor = "Blue",
                            Description = "The hero of the Star Wars saga.",
                            Movies = new[] { "A New Hope", "The Empire Strikes Back", "Return of the Jedi" }.ToList(),
                            CreatedById = user.Id
                        },
                        new Character
                        {
                            Id=2,
                            Name = "Darth Vader",
                            BirthDate = new DateTime(1977, 5, 25),
                            Planet = "Tatooine",
                            Gender = "Male",
                            Race = "Human",
                            Height = 203,
                            HairColor = "None",
                            EyeColor = "Yellow",
                            Description = "The Sith Lord and father of Luke Skywalker.",
                            Movies = new[] { "A New Hope", "The Empire Strikes Back", "Return of the Jedi" }.ToList(),
                            CreatedById = user.Id
                        },
                        new Character
                        {
                            Id=3,
                            Name = "Princess Leia Organa",
                            BirthDate = new DateTime(2000, 1, 1),
                            Planet = "Alderaan",
                            Gender = "Female",
                            Race = "Human",
                            Height = 150,
                            HairColor = "Brown",
                            EyeColor = "Brown",
                            Description = "A leader in the Rebel Alliance.",
                            Movies = new[] { "A New Hope", "The Empire Strikes Back", "Return of the Jedi" }.ToList(),
                            CreatedById = user.Id
                        }
                    };

                    context.Characters.AddRange(characters);
                    context.SaveChanges();
                }
            }
        }
    }
}