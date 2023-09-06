using System;

namespace netboilerplate.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Character> Characters => Set<Character>();
        public DbSet<Backpack> Backpacks => Set<Backpack>();

    }
}

