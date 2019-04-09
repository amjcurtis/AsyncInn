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

		private AsyncInnDbContext _context;

		public HotelService(AsyncInnDbContext context)
		{
			_context = context;
		}

		public async Task CreateHotel(Hotel hotel)
		{
			_context.Add(hotel);
			await _context.SaveChangesAsync();
		}

		public void ModifyHotel(int id)
		{
			throw new NotImplementedException();
		}

		public bool DeleteHotel(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Hotel> GetHotel(int id)
		{
			var hotel = await _context.Hotels.FindAsync(id);
			if (hotel == null)
			{
				return null;
			}
			return hotel;
		}

		public async Task<List<Hotel>> GetHotels()
		{
			return await _context.Hotels.ToListAsync();
		}

		public Room GetRoom(int id)
		{
			//TODO Write method to get a room
			
			// This will likely be part of solution
			//_context.Rooms;

			return null;
		}

		public List<Room> GetAllRooms()
		{
			//TODO Write method to get all rooms

		}
	}
}
