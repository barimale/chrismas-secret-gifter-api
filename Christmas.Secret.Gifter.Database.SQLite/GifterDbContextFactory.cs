﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Christmas.Secret.Gifter.Infrastructure
{
    /* For migrations generation only */

    public class GifterDbContextFactory : IDesignTimeDbContextFactory<GifterDbContext>
    {
        public GifterDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GifterDbContext>();
            optionsBuilder.UseSqlite("Data Source=e:/gifter.db");

            return new GifterDbContext(optionsBuilder.Options);
        }
    }
}