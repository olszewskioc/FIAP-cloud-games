﻿
namespace App.FCG.Core.Entities
{
	public class Game : EntityBase
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string PublisherName { get; set; } // Entidade futura
		public DateOnly ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}
}
