using System;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Task02
	{
		[TestCase(0, 0)]
		[TestCase(1, 1)]
		[TestCase(1, 4)]
		[TestCase(5, 3)]
		[TestCase(16, 5)]
		public void TaskSolution(int size, int slice)
		{
			var values = new string[size];
			for(var index = 1; index < values.Length + 1; ++index)
			{
				values[index - 1] = index > slice ? $"[~{index - slice,2}]" : $"[{index,3}]";
			}

			// a = 3

			$"\n-- N: {size}; M: {slice}".Log();

			if(slice > size)
			{
				slice = size - 1;
				slice = slice < 0 ? 0 : slice;
				$"trimming M to: {slice}".Log();
			}

			$"initial : {string.Join(" ", values)}".Log();

			var indexF = 0;
			var indexR = values.Length - 1;
			while(indexF < indexR)
			{
				(values[indexF], values[indexR]) = (values[indexR], values[indexF]);
				indexF++;
				indexR--;
			}

			indexF = values.Length - slice;
			indexR = values.Length - 1;
			while(indexF < indexR)
			{
				(values[indexF], values[indexR]) = (values[indexR], values[indexF]);
				indexF++;
				indexR--;
			}

			indexF = 0;
			indexR = values.Length - slice - 1;
			while(indexF < indexR)
			{
				(values[indexF], values[indexR]) = (values[indexR], values[indexF]);
				indexF++;
				indexR--;
			}

			$"complete: {string.Join(" ", values)}".Log();
		}
	}

	internal static class Extensions
	{
		public static void Log(this string message)
		{
			TestContext.Progress.WriteLine(message);
		}
	}
}
