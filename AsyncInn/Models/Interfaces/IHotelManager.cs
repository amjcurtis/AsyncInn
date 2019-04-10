using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
	public interface IHotelManager
	{

		// Create new hotel instance
		Task CreateHotel(Hotel hotel);

		// Modify a hotel
		void UpdateHotel(int id, Hotel hotel);

		// Delete a hotel
		bool DeleteHotel(int id);

		// Get a single hotel
		Task<Hotel> GetHotel(int id);

		// Get all the hotels
		Task<List<Hotel>> GetHotels();

		// Get a single room
		Task<Room> GetRoom(int id);

		// Get all the rooms
		Task<List<Room>> GetAllRooms();

		// Check whether hotel exists
		bool HotelExists(int id);
	}
}
