using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
	public class HotelService : IHotelManager
	{

		// Store reference to DB under private variable
		private AsyncInnDbContext _context;

		/// <summary>
		/// Constructor for HotelService (DI/middleware service)
		/// </summary>
		/// <param name="context">database context</param>
		public HotelService(AsyncInnDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Creates new hotel instance
		/// </summary>
		/// <param name="hotel">Hotel</param>
		/// <returns>async Task</returns>
		public async Task CreateHotel(Hotel hotel)
		{
			_context.Add(hotel);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates a specified hotel instance in DB
		/// </summary>
		/// <param name="id">ID of hotel instance</param>
		/// <param name="hotel">hotel instance</param>
		public void UpdateHotel(int id, Hotel hotel)
		{
			if (id == hotel.ID)
			{
				_context.Update(hotel);
				_context.SaveChanges();
			}
		}

		/// <summary>
		/// Deletes hotel instance from DB
		/// </summary>
		/// <param name="id">hotel ID</param>
		/// <returns>true if hotel not already null</returns>
		public bool DeleteHotel(int id)
		{
			var hotel = _context.Hotels.Where(h => h.ID == id);
			if (hotel != null)
			{
				_context.Remove(hotel);
				_context.SaveChanges();
			}
			return true;
		}

		/// <summary>
		/// Gets a hotel instance by ID from DB
		/// </summary>
		/// <param name="id">hotel ID</param>
		/// <returns>hotel object or null if hotel null</returns>
		public async Task<Hotel> GetHotel(int id)
		{
			var hotel = await _context.Hotels.FindAsync(id);
			if (hotel == null)
			{
				return null;
			}
			return hotel;
		}

		/// <summary>
		/// Gets all hotel instances in DB and returns in a list
		/// </summary>
		/// <returns>list of Hotel objects</returns>
		public async Task<List<Hotel>> GetHotels()
		{
			return await _context.Hotels.ToListAsync();
		}

		/// <summary>
		/// Gets a room instance by ID from DB
		/// </summary>
		/// <param name="id"></param>
		/// <returns>room object or null if room null</returns>
		public async Task<Room> GetRoom(int id)
		{
			return await _context.Rooms.FirstOrDefaultAsync(r => r.ID == id);
		}

		/// <summary>
		/// Gets all room instances in DB and returns in a list
		/// </summary>
		/// <returns>list of Room objects</returns>
		public async Task<List<Room>> GetAllRooms()
		{
			return await _context.Rooms.ToListAsync();
		}

		/// <summary>
		/// Checks whether a hotel with specified ID exists
		/// </summary>
		/// <param name="id">hotel ID</param>
		/// <returns>boolean</returns>
		public bool HotelExists(int id)
		{
			return _context.Hotels.Any(h => h.ID == id);
		}
	}
}
