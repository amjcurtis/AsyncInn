using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models;

namespace AsyncInn.Data
{
	public class AsyncInnDbContext : DbContext
	{
		public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Establish composite keys
			modelBuilder.Entity<RoomAmenities>().HasKey(ra => new { ra.AmenitiesID, ra.RoomID });
			modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelID, hr.RoomNumber });
		}

		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }
		public DbSet<Amenities> Amenities{ get; set; }
		public DbSet<RoomAmenities> RoomAmenities{ get; set; }
	}
}
