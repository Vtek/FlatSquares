using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatSquares.Common
{
	/// <summary>
	/// Random helper.
	/// </summary>
	public static class RandomHelper
	{
		/// <summary>
		/// The random instance.
		/// </summary>
		static Random Random { get; } = new Random();

		/// <summary>
		/// Nexts int.
		/// </summary>
		/// <returns>The int.</returns>
		public static int NextInt() => Random.Next();

		/// <summary>
		/// Nexts int.
		/// </summary>
		/// <returns>The int.</returns>
		/// <param name="maxValue">Max value.</param>
		public static int NextInt(int maxValue) => Random.Next(maxValue);

		/// <summary>
		/// Nexts int.
		/// </summary>
		/// <returns>The int.</returns>
		/// <param name="minValue">Minimum value.</param>
		/// <param name="maxValue">Max value.</param>
		public static int NextInt(int minValue, int maxValue) => Random.Next(minValue, maxValue);

		/// <summary>
		/// Nexts bool.
		/// </summary>
		/// <returns><c>true</c>, if bool was nexted, <c>false</c> otherwise.</returns>
		public static bool NextBool() => NextInt(2) == 1;

		/// <summary>
		/// Nexts float.
		/// </summary>
		/// <returns>The float.</returns>
		public static float NextFloat() => (float)Random.NextDouble();

		/// <summary>
		/// Nexts float.
		/// </summary>
		/// <returns>The float.</returns>
		/// <param name="maxValue">Max value.</param>
		public static float NextFloat(float maxValue) => maxValue * NextFloat();

		/// <summary>
		/// Nexts float.
		/// </summary>
		/// <returns>The float.</returns>
		/// <param name="minValue">Minimum value.</param>
		/// <param name="maxValue">Max value.</param>
		public static float NextFloat(float minValue, float maxValue) => (maxValue - minValue) * NextFloat() + minValue;

		/// <summary>
		/// Nexts radians angle.
		/// </summary>
		/// <returns>The radians angle.</returns>
		public static float NextRadiansAngle() => NextFloat(-MathHelper.Pi, MathHelper.Pi);

		/// <summary>
		/// Nexts vector.
		/// </summary>
		/// <returns>The vector.</returns>
		public static Vector NextVector() => Vector.Polar(1.0f, NextRadiansAngle());

		/// <summary>
		/// Choose a specified T in values.
		/// </summary>
		/// <param name="values">Values.</param>
		public static T Choose<T>(params T[] values) => values[NextInt(values.Length)];

		/// <summary>
		/// Return a Shuffled enumerable of values
		/// </summary>
		/// <returns>Shuffled enumerable</returns>
		public static IEnumerable<T> Shuffle<T>(params T[] values) => values.OrderBy(x => Guid.NewGuid()).AsEnumerable();
	}
}
