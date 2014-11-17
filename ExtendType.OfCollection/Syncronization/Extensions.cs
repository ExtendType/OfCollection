using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace ExtendType.OfCollection.Syncronization
{
	public static class Extensions
	{
		public static ICollection<T> Reconcile<T, TTo>(this ICollection<T> instance, ICollection<TTo> to, Func<T, TTo, bool> on, Action<T> add = null, Action<T, TTo> update = null, Action<TTo> remove = null)
		{
			if (instance != null && to != null && !to.IsReadOnly)
			{

				if (remove != null)
				{
					IEnumerable<TTo> toAsCopy = to.ToArray();
					foreach (TTo item in toAsCopy.Where(p =>
					{
						return !instance.Any(pr => on(pr, p));
					})) remove(item);
				}
				if (update != null)
				{
					IEnumerable<TTo> toAsCopy = to.ToArray();
					foreach (T item in instance.Where(p =>
					{
						return toAsCopy.Any(pu => on(p, pu));
					})) update(item, to.Where(p => on(item, p)).FirstOrDefault());
				}
				if (add != null)
				{
					IEnumerable<TTo> toAsCopy = to.ToArray();
					foreach (T item in instance.Where(p =>
					{
						return !toAsCopy.Any(pa => on(p, pa));
					})) add(item);
				}
			}
			return instance;
		}
	}
}
