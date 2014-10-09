using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.OfCollection.Abstraction
{
	public static class Extensions
	{
		/// <summary>
		/// Wraps an underlying type in a list of an abstract type
		/// </summary>
		public static IList<TTo> AsAbstract<TFrom, TTo>(this IList<TFrom> instance)
			where TFrom : new()
			where TFrom : TTo
		{
			if (instance == null) return null;
			return new ListOfAbstract<TFrom,TTo>(instance);
		}
		/// <summary>
		/// Wraps an underlying type in a collection of an abstract type
		/// </summary>
		public static ICollection<TTo> AsAbstract<TFrom, TTo>(this ICollection<TFrom> instance)
			where TFrom : new()
			where TFrom : TTo
		{
			if (instance == null) return null;
			return new CollectionOfAbstract<TFrom, TTo>(instance);
		}
	}
}
