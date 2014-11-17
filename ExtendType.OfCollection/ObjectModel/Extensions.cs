using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendType.OfCollection.ObjectModel
{
	public static class Extensions
	{
		public static ObservableCollection<T> OnAdd<T>(this ObservableCollection<T> instance, Action<T> action)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Add && action != null && e.NewItems != null) foreach (T item in e.NewItems) action(item);
			};
			return instance;
		}
		public static ObservableCollection<T> OnReplace<T>(this ObservableCollection<T> instance, Action<T> newItems, Action<T> oldItems)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Replace)
				{
					if (newItems != null && e.NewItems != null) foreach (T item in e.NewItems) newItems(item);
					if (oldItems != null && e.OldItems != null) foreach (T item in e.OldItems) oldItems(item);
				}
			};
			return instance;
		}

		public static ObservableCollection<T> OnRemove<T>(this ObservableCollection<T> instance, Action<T> action)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Remove && action != null && e.OldItems != null) foreach (T item in e.OldItems) action(item);
			};
			return instance;
		}
		public static ObservableCollection<T> OnReset<T>(this ObservableCollection<T> instance, Action<T> action)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Reset && action != null && e.OldItems != null) foreach (T item in e.OldItems) action(item);
			};
			return instance;
		}
		public static ObservableCollection<T> OnAnyItem<T>(this ObservableCollection<T> instance, Action<T> action)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if(e.NewItems != null) foreach (T item in e.NewItems) action(item);
				if(e.OldItems != null) foreach (T item in e.OldItems) action(item);
			};
			return instance;
		}
		public static ObservableCollection<T> OnAnyNewItem<T>(this ObservableCollection<T> instance, Action<T> action)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace && action != null && e.NewItems != null) foreach (T item in e.NewItems) action(item);
			};
			return instance;
		}
		public static ObservableCollection<T> OnAnyOldItem<T>(this ObservableCollection<T> instance, Action<T> action)
		{
			instance.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset || e.Action == NotifyCollectionChangedAction.Replace && action != null && e.OldItems != null) foreach (T item in e.OldItems) action(item);
			};
			return instance;
		}
	}
}
