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

			// Seeding DB //////////////////////////
			// Seed hotels
			modelBuilder.Entity<Hotel>().HasData(
				new Hotel
				{
					ID = 1,
					Name = "The Windsor Hotel",
					StreetAddress = "21B Baker St.",
					City = "London",
					State = "Londonshire",
					Phone = 1234567890
				},
				new Hotel
				{
					ID = 2,
					Name = "The Empress Hotel",
					StreetAddress = "1400 Commercial Ave.",
					City = "Victoria",
					State = "British Columbia",
					Phone = 1234567890
				},
				new Hotel
				{
					ID = 3,
					Name = "Best Western",
					StreetAddress = "12 Division St.",
					City = "Mt. Vernon",
					State = "WA",
					Phone = 1234567890
				},
				new Hotel
				{
					ID = 4,
					Name = "4 Point Sheraton",
					StreetAddress = "1240 Lakeway Dr.",
					City = "Bellingham",
					State = "WA",
					Phone = 1234567890
				},
				new Hotel
				{
					ID = 5,
					Name = "Super 8",
					StreetAddress = "15 Olive Way",
					City = "Seattle",
					State = "WA",
					Phone = 1234567890
				}
			);

			// Seed rooms
			modelBuilder.Entity<Room>().HasData(
				new Room
				{
					ID = 1,
					Name = "Bachelor Pad",
					Layout = Layout.Studio
				},
				new Room
				{
					ID = 2,
					Name = "Penthouse",
					Layout = Layout.Studio
				},
				new Room
				{
					ID = 3,
					Name = "Lone Ranger",
					Layout = Layout.OneBedroom
				},
				new Room
				{
					ID = 4,
					Name = "Honeymoon Suite",
					Layout = Layout.OneBedroom
				},
				new Room
				{
					ID = 5,
					Name = "Presidential Suite",
					Layout = Layout.TwoBedroom
				},
				new Room
				{
					ID = 6,
					Name = "Cardinal's Suite",
					Layout = Layout.TwoBedroom
				}
			);

			// Seed amenities
			modelBuilder.Entity<Amenities>().HasData(
				new Amenities
				{
					ID = 1,
					Name = "A/C"
				},
				new Amenities
				{
					ID = 2,
					Name = "Toaster"
				},
				new Amenities
				{
					ID = 3,
					Name = "Coffee maker"
				},
				new Amenities
				{
					ID = 4,
					Name = "Ocean view"
				},
				new Amenities
				{
					ID = 5,
					Name = "Hot tub"
				}
			);
		}
		
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }
		public DbSet<Amenities> Amenities{ get; set; }
		public DbSet<RoomAmenities> RoomAmenities{ get; set; }
	}
}
