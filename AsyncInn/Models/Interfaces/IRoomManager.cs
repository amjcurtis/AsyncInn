using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
	public interface IRoomManager
	{

		// Create a new room instance
		Task CreateRoom(Room room);

		// Edit a room
		void UpdateRoom(int id, Room room);

		// Delete a room
		bool DeleteRoom(int id);

		// Get a single room
		Task<Room> GetRoom(int id);

		// Get all rooms
		Task<List<Room>> GetAllRooms();

		// Check whether a given room exists
		bool RoomExists(int id);
	}
}
