using System;
using System.Collections.Generic;

namespace Dominion.Logic
{
	public static class ListExtensions
	{
		public static void Shuffle<T>(this IList<T> list, Random rnd)
		{
			for (var i = list.Count; i > 0; i--)
			{
				list.Swap(0, rnd.Next(0, i));
			}
		}

		private static void Swap<T>(this IList<T> list, int i, int j)
		{
			T temp = list[i];
			list[i] = list[j];
			list[j] = temp;
		}
    }
}