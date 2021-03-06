﻿using System.Data.Entity;
using AutoDealer.Data.Vehicle;
using AutoDealer.Services.DTO.User;
using AutoDealer.Services.DTO.WebLog;

namespace AutoDealer.Repository.ApplicationContext
{
    public class AutoDealerContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Car_Gallery> CarGalleries { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<SubModel> SubModels { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Option_Category> Optotion_Categories { get; set; }
        public DbSet<Car_Selected_Option> Car_Selected_Options { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
