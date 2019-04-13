using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
	public class AmenitiesService : IAmenitiesManager
	{

		// Store reference to DB under private variable
		private readonly AsyncInnDbContext _context;

		public AmenitiesService(AsyncInnDbContext context)
		{
			_context = context;
		}

		public async Task CreateAmenity(Amenities amenity)
		{
			_context.Add(amenity);
			await _context.SaveChangesAsync();
		}

		public void UpdateAmenity(int id, Amenities amenity)
		{
			if (amenity.ID == id)
			{
				_context.Amenities.Update(amenity);
				_context.SaveChanges();
			}
		}

		public bool DeleteAmenity(int id)
		{
			var amenity = _context.Amenities.FirstOrDefault(a => a.ID == id);
			if (amenity != null)
			{
				_context.Remove(amenity);
				_context.SaveChanges();
			}
			return true;
		}

		public async Task<Amenities> GetAmenity(int id)
		{
			var amenity = await _context.Amenities.FindAsync(id);
			if (amenity == null)
			{
				return null;
			}
			return amenity;
		}

		public async Task<List<Amenities>> GetAllAmenities()
		{
			return await _context.Amenities.ToListAsync();
		}

		//TODO Add method to get single instance of [Room? RoomAmenities?]


		//TODO Add method to get all instances of [Room? RoomAmenities?]


		public bool AmenityExists(int id)
		{
			return _context.Amenities.Any(a => a.ID == id);
		}
	}
}
