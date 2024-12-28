using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebTp7.Data;
using WebTp7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTp7.Seeder
{
    public static class DatabaseSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Create roles
            var roles = new[] { "admin", "customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create admin user
            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var adminPassword = "Admin2003*";
            var existingAdmin = await userManager.FindByEmailAsync(adminUser.Email);
            if (existingAdmin == null)
            {
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    // Assign both "admin" and "customer" roles to the admin user
                    await userManager.AddToRolesAsync(adminUser, new[] { "admin", "customer" });
                }
            }
            else
            {
                // Ensure existing admin has both roles
                var adminRoles = await userManager.GetRolesAsync(existingAdmin);
                if (!adminRoles.Contains("admin"))
                {
                    await userManager.AddToRoleAsync(existingAdmin, "admin");
                }
                if (!adminRoles.Contains("customer"))
                {
                    await userManager.AddToRoleAsync(existingAdmin, "customer");
                }
            }

            // Seed genres and movies
            if (!dbContext.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Drama" },
                    new Genre { Name = "Horror" }, 
                    new Genre { Name = "Sci-Fi" } 
                };

                dbContext.Genres.AddRange(genres);
                await dbContext.SaveChangesAsync();

                var movies = new List<Movie>
                {
                    // Action Movies
                    new Movie { Name = "Action Movie 1", Description = "An exciting action movie.", Price = 9.99m, GenreId = genres[0].Id, Rating = 0 },
                    new Movie { Name = "Action Movie 2", Description = "A thrilling adventure.", Price = 11.99m, GenreId = genres[0].Id, Rating = 0 },
                    new Movie { Name = "Action Movie 3", Description = "High-octane action.", Price = 8.99m, GenreId = genres[0].Id, Rating = 0 },

                    // Comedy Movies
                    new Movie { Name = "Comedy Movie 1", Description = "A hilarious comedy movie.", Price = 7.99m, GenreId = genres[1].Id, Rating = 0 },
                    new Movie { Name = "Comedy Movie 2", Description = "Laugh-out-loud moments.", Price = 6.99m, GenreId = genres[1].Id, Rating = 0 },
                    new Movie { Name = "Comedy Movie 3", Description = "A comedy to remember.", Price = 8.49m, GenreId = genres[1].Id, Rating = 0 },

                    // Drama Movies
                    new Movie { Name = "Drama Movie 1", Description = "A touching drama movie.", Price = 8.99m, GenreId = genres[2].Id, Rating = 0 },
                    new Movie { Name = "Drama Movie 2", Description = "Heartfelt and emotional.", Price = 9.49m, GenreId = genres[2].Id, Rating = 0 },
                    new Movie { Name = "Drama Movie 3", Description = "An inspiring tale.", Price = 7.99m, GenreId = genres[2].Id, Rating = 0 },

                    // Horror Movies
                    new Movie { Name = "Horror Movie 1", Description = "A spine-chilling horror film.", Price = 10.99m, GenreId = genres[3].Id, Rating = 0 },
                    new Movie { Name = "Horror Movie 2", Description = "Terrifying and suspenseful.", Price = 11.49m, GenreId = genres[3].Id, Rating = 0 },
                    new Movie { Name = "Horror Movie 3", Description = "Nightmares come to life.", Price = 9.99m, GenreId = genres[3].Id, Rating = 0 },

                    // Sci-Fi Movies
                    new Movie { Name = "Sci-Fi Movie 1", Description = "A futuristic sci-fi adventure.", Price = 12.99m, GenreId = genres[4].Id, Rating = 0 },
                    new Movie { Name = "Sci-Fi Movie 2", Description = "Exploring the unknown.", Price = 13.49m, GenreId = genres[4].Id, Rating = 0 },
                    new Movie { Name = "Sci-Fi Movie 3", Description = "Innovative and thought-provoking.", Price = 11.99m, GenreId = genres[4].Id, Rating = 0 }
                };

                dbContext.Movies.AddRange(movies);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
