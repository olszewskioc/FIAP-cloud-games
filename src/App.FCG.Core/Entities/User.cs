using App.FCG.Core.Extensions;
using App.FCG.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace App.FCG.Core.Entities
{
	public abstract class User : IdentityUser<Guid>, IEntity
	{
		public DateTime CreatedAt { get; private set; }
		public DateTime? UpdatedAt { get; private set; }
		public string Name { get; private set; }
		public string LastName { get; private set; }

		protected User()
		{
			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
		}

		public User(string email, string name, string lastName) : this()
		{
			Email = email;
			UserName = email;
			Name = name;
			LastName = lastName;
		}

		// Usa os extension methods
		public override bool Equals(object? obj) => this.EntityEquals(obj);
		public override int GetHashCode() => this.EntityGetHashCode();

		public static bool operator ==(User? a, User? b)
		{
			if (a is null && b is null) return true;
			if (a is null || b is null) return false;
			return a.Equals(b);
		}

		public static bool operator !=(User? a, User? b) => !(a == b);
	}
}
