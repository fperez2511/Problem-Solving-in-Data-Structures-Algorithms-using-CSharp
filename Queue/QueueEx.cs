﻿using System;

public class QueueEx
{

	public static int CircularTour(int[][] arr, int n)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		int nextPump = 0, prevPump ;
		int count = 0;
		int petrol = 0;

		while (que.size() != n)
		{
			while (petrol >= 0 && que.size() != n)
			{
				que.add(nextPump);
				petrol += (arr[nextPump][0] - arr[nextPump][1]);
				nextPump = (nextPump + 1) % n;
			}
			while (petrol < 0 && que.size() > 0)
			{
				prevPump = que.remove();
				petrol -= (arr[prevPump][0] - arr[prevPump][1]);
			}
			count += 1;
			if (count == n)
			{
				return -1;
			}
		}
		if (petrol >= 0)
		{
			return que.remove();
		}
		else
		{
			return -1;
		}
	}

	public static void main1(string[] args)
	{
		// Testing code
		int[][] tour = new int[][]
		{
			new int[] {8, 6},
			new int[] {1, 4},
			new int[] {7, 6}
		};
		Console.WriteLine(" Circular Tour : " + CircularTour(tour, 3));
	}

	public static int convertXY(int src, int dst)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		int[] arr = new int[100];
		int steps = 0;
		int index = 0;
		int value;

		que.add(src);
		while (que.size() != 0)
		{
			value = que.remove();
			arr[index++] = value;

			if (value == dst)
			{
				for (int i = 0; i < index; i++)
				{
					Console.Write(arr[i]);
				}
				Console.Write("Steps countr :: " + steps);

				return steps;
			}
			steps++;
			if (value < dst)
			{
				que.add(value * 2);
			}
			else
			{
				que.add(value - 1);
			}
		}
		return -1;
	}

	public static void main3(string[] args)
	{
		convertXY(2, 7);
	}

	public static void maxSlidingWindows(int[] arr, int size, int k)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.size() > 0 && que.peek() <= i - k)
			{
				que.remove();
			}
			// Remove smaller values at left.
			while (que.size() > 0 && arr[que.peekLast()] <= arr[i])
			{
				que.removeLast();
			}

			que.add(i);
			// Largest value in window of size k is at index que[0]
			// It is displayed to the screen.
			if (i >= (k - 1))
			{
				Console.WriteLine(arr[que.peek()]);
			}
		}
	}

	public static void main4(string[] args)
	{
		int[] arr = new int[] {11, 2, 75, 92, 59, 90, 55};
		int k = 3;
		maxSlidingWindows(arr, 7, 3);
		// Output 75, 92, 92, 92, 90
	}

	public static int minOfMaxSlidingWindows(int[] arr, int size, int k)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		int minVal = 999999;
		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.size() > 0 && que.peek() <= i - k)
			{
				que.remove();
			}
			// Remove smaller values at left.
			while (que.size() > 0 && arr[que.peekLast()] <= arr[i])
			{
				que.remove();
			}
			que.add(i);
			// window of size k
			if (i >= (k - 1) && minVal > arr[que.peek()])
			{
				minVal = arr[que.peek()];
			}
		}
		Console.WriteLine("Min of max is :: " + minVal);
		return minVal;
	}

	public static void main5(string[] args)
	{
		int[] arr = new int[] {11, 2, 75, 92, 59, 90, 55};
		int k = 3;
		minOfMaxSlidingWindows(arr, 7, 3);
		// Output 75
	}

	public static void maxOfMinSlidingWindows(int[] arr, int size, int k)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();
		int maxVal = -999999;
		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.size() > 0 && que.peek() <= i - k)
			{
				que.remove();
			}
			// Remove smaller values at left.
			while (que.size() > 0 && arr[que.peekLast()] >= arr[i])
			{
				que.remove();
			}
			que.add(i);
			// window of size k
			if (i >= (k - 1) && maxVal < arr[que.peek()])
			{
				maxVal = arr[que.peek()];
			}
		}
		Console.WriteLine("Max of min is :: " + maxVal);
	}

	public static void main6(string[] args)
	{
		int[] arr = new int[] {11, 2, 75, 92, 59, 90, 55};
		int k = 3;
		maxOfMinSlidingWindows(arr, 7, 3);
		// Output 59, as minimum values in sliding windows are [2, 2, 59, 59, 55]
	}

	public static void firstNegSlidingWindows(int[] arr, int size, int k)
	{
		ArrayDeque<int?> que = new ArrayDeque<int?>();

		for (int i = 0; i < size; i++)
		{
			// Remove out of range elements
			if (que.size() > 0 && que.peek() <= i - k)
			{
				que.remove();
			}
			if (arr[i] < 0)
			{
				que.add(i);
			}
			// window of size k
			if (i >= (k - 1))
			{
				if (que.size() > 0)
				{
					Console.Write(arr[que.peek()]);
				}
				else
				{
					Console.Write("NAN");
				}
			}
		}
	}

	public static void Main(string[] args)
	{
		int[] arr = new int[] {3, -2, -6, 10, -14, 50, 14, 21};
		int k = 3;
		firstNegSlidingWindows(arr, 8, 3);
		// Output [-2, -2, -6, -14, -14, NAN]
	}
}