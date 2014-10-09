using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.OfCollection.Abstraction
{
	public class ListOfAbstract<TFrom,TTo> : IList<TTo>
		where TFrom : TTo
	{
		private readonly IList<TFrom> Target;
		public ListOfAbstract(IList<TFrom> from)
		{
			Target = from;
		}

		public int IndexOf(TTo item)
		{
			return Target.IndexOf((TFrom)item);
		}

		public void Insert(int index, TTo item)
		{
			Target.Insert(index, (TFrom)item);
		}

		public void RemoveAt(int index)
		{
			Target.RemoveAt(index);
		}

		public TTo this[int index]
		{
			get
			{
				return Target[index];
			}
			set
			{
				Target[index] = (TFrom)value;
			}
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
		return	Target.Contains((TFrom)item);
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
