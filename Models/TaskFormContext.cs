using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group14.Models
{
    public class TaskFormContext : DbContext
    {
        // constructor
        public TaskFormContext(DbContextOptions<TaskFormContext> options) : base(options)
        {
            // leave blank for now
        }
        public DbSet<TaskForm> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seed Data
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
                );


            mb.Entity<TaskForm>().HasData(
                new TaskForm
                {
                    TaskId = 1,
                    Task = "Do laundry",
                    DueDate = DateTime.Parse("2022-02-25 00:00:00"),
                    Quadrant = 2,
                    CategoryId = 1,
                    Completed = true
                },
                new TaskForm
                {
                    TaskId = 2,
                    Task = "Finish Homewokr",
                    DueDate = DateTime.Parse("2022-02-27 00:00:00"),
                    Quadrant = 1,
                    CategoryId = 2,
                    Completed = true
                },
                new TaskForm
                {
                    TaskId = 3,
                    Task = "Prepare Talk",
                    DueDate = DateTime.Parse("2022-03-04 00:00:00"),
                    Quadrant = 2,
                    CategoryId = 4,
                    Completed = false
                }

            );
        }
    }
}
