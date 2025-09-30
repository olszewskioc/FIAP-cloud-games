using App.FCG.Core.Interfaces;

namespace App.FCG.Core.Extensions
{
	public static class EntityExtensions
	{
		public static bool EntityEquals(this IEntity entity, object? obj)
		{
			if (obj is not IEntity other)
				return false;

			if (ReferenceEquals(entity, other))
				return true;

			if (entity.GetType() != other.GetType())
				return false;

			if (entity.Id == Guid.Empty || other.Id == Guid.Empty)
				return false;

			return entity.Id == other.Id;
		}

		public static int EntityGetHashCode(this IEntity entity)
		{
			return (entity.GetType().ToString() + entity.Id).GetHashCode();
		}
	}
}
