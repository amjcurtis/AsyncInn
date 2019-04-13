using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
	public interface IAmenitiesManager
	{

		// Create a new Amenities instance
		Task CreateAmenity(Amenities amenity);

		// Edit an amenity
		void UpdateAmenity(int id, Amenities amenity);

		// Delete an amenity
		bool DeleteAmenity(int id);

		// Get a single amenity
		Task<Amenities> GetAmenity(int id);

		// Get all amenities as list
		Task<List<Amenities>> GetAllAmenities();

		//TODO Add method to get single instance of [Room? RoomAmenities?]


		//TODO Add method to get all instances of [Room? RoomAmenities?]

		// Check whether a given amenity exists
		bool AmenityExists(int id);
	}
}
