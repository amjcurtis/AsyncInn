﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
	public class Amenities
	{
		public int ID { get; set; }
		public string Name { get; set; }

		// Navigation property
		public RoomAmenities RoomAmenities { get; set; }
	}
}
