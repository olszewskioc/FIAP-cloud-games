using App.FCG.Core.Extensions;
using App.FCG.Core.Interfaces;

namespace App.FCG.Core.Entities
{
	public abstract class Entity : IEntity
	{
		public Guid Id { get; protected set; }
		public DateTime CreatedAt { get; protected set; }
		public DateTime? UpdatedAt { get; protected set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
			CreatedAt = DateTime.UtcNow;
		}

		public override bool Equals(object? obj) => this.EntityEquals(obj);
		public override int GetHashCode() => this.EntityGetHashCode();

		public static bool operator ==(Entity? a, Entity? b)
		{
			if (a is null && b is null) return true;
			if (a is null || b is null) return false;
			return a.Equals(b);
		}

		public static bool operator !=(Entity? a, Entity? b) => !(a == b);
	}
}
