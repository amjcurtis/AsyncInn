﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
	public class Hotel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string StreetAddress { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public int Phone { get; set; }

		// Navigation property
		public ICollection<HotelRoom> HotelRoom { get; set; }
	}
}
