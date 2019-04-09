using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
	public interface IHotelManager
	{
		Task CreateHotel(Hotel hotel);

		// Modify a Hotel
		void ModifyHotel(int id);

		// Delete a hotel
		bool DeleteHotel(int id);

		// Get a single hotel
		Task<Hotel> GetHotel(int id);

		// Get all the hotels
		Task<List<Hotel>> GetHotels();

		Room GetRoom(int id);

		List<Room> GetAllRooms();
	}
}
