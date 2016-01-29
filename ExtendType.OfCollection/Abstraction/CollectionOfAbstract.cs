using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.OfCollection.Abstraction
{
	public class CollectionOfAbstract<TFrom,TTo> : ICollection<TTo>
		where TFrom : TTo
	{
		private readonly ICollection<TFrom> Target;
		public CollectionOfAbstract(ICollection<TFrom> from)
		{
			Target = from;
		}
		
		public void Add(TTo item)
		{
			Target.Add((TFrom)item);
		}

		public void Clear()
		{
			Target.Clear();
		}

		public bool Contains(TTo item)
		{
			return Target.Contains((TFrom)item);
		}

		public void CopyTo(TTo[] array, int arrayIndex)
		{
			Target.Cast<TTo>().ToArray().CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return Target.Count; }
		}

		public bool IsReadOnly
		{
			get { return Target.IsReadOnly; }
		}

		public bool Remove(TTo item)
		{
			return Target.Remove((TFrom)item);
		}

		public IEnumerator<TTo> GetEnumerator()
		{
			return Target.Cast<TTo>().GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
