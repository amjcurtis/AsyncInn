using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
	public class RoomService : IRoomManager
	{

		// Store reference to DB under private variable
		private readonly AsyncInnDbContext _context;

		/// <summary>
		/// Constructor for RoomService (DI/middleware service)
		/// </summary>
		/// <param name="context">database context</param>
		public RoomService(AsyncInnDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Creates new room instance
		/// </summary>
		/// <param name="room">Room</param>
		/// <returns>async Task</returns>
		public async Task CreateRoom(Room room)
		{
			_context.Add(room);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates a specified room instance in DB
		/// </summary>
		/// <param name="id">ID of room instance</param>
		/// <param name="room">room instance</param>
		public void UpdateRoom(int id, Room room)
		{
			if (id == room.ID)
			{
				_context.Update(room);
				_context.SaveChanges();
			}
		}

		/// <summary>
		/// Deletes room instance from DB
		/// </summary>
		/// <param name="id">room ID</param>
		/// <returns>true if room not already null</returns>
		public bool DeleteRoom(int id)
		{
			var room = _context.Rooms.FirstOrDefault(r => r.ID == id);
			if (room != null)
			{
				_context.Remove(room);
				_context.SaveChanges();
			}
			return true;
		}

		/// <summary>
		/// Gets a room instance by ID from DB
		/// </summary>
		/// <param name="id">room ID</param>
		/// <returns>room object or null if room null</returns>
		public async Task<Room> GetRoom(int id)
		{
			var room = await _context.Rooms.FindAsync(id);
			if (room == null)
			{
				return null;
			}
			return room;
		}

		/// <summary>
		/// Returns all room instances in DB as a list
		/// </summary>
		/// <returns>list of Room objects</returns>
		public async Task<List<Room>> GetAllRooms()
		{
			return await _context.Rooms.ToListAsync();
		}

		/// <summary>
		/// Checks whether a room with specified ID exists
		/// </summary>
		/// <param name="id">room ID</param>
		/// <returns>boolean</returns>
		public bool RoomExists(int id)
		{
			return _context.Rooms.Any(r => r.ID == id);
		}
	}
}
