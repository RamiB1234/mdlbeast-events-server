﻿using mdlbeast_events_server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace mdlbeast_events_server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        // Seeding initial data:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasData(
            new Event {
                Id = 1,
                Description = "Another One In The Bag! For our 4th Soundstorm - we went bigger and wilder with 3 thrilling nights, 8 stages, and 200 artists to form your memorable experience. If you missed this year’s Storm, here’s a recap of the loudest music event in the region! This is Soundstorm.",
                Name = "Soundstorm",
                Date = "14/12/2023",
                Location = "Riyadh",
                ImageURL= "images/soundstorm.PNG"
            },
            new Event
            {
                Id = 2,
                Description = "It's time to get Social. Join our intimate gathering of Jeddah's music heads on Bait Zainal's rooftop in the heart of historic Al-Balad.With iconic views, carefully curated tunes by the finest homegrown and international DJ's and crave-worthy bites... we could go on and on, but the dancefloor is calling.",
                Name = "Balad Social",
                Date = "25/04/2024",
                Location = "Jeddah",
                ImageURL = "images/balad.PNG"
            },
            new Event
            {
                Id = 3,
                Description = "Introducing Kokub, AlUla’s supernova of music. This is planet sound - get ready to dance amongst the stars. Every other Friday, take off to Kokub - AlUla",
                Name = "KOKOUB",
                Date = "01/03/2024",
                Location = "Al Ula",
                ImageURL = "images/kokub.PNG"
            });

            modelBuilder.Entity<User>()
                .HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "password"
            });
        }
    }
}
