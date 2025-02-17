// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace ClockworkReverie.CustomMath.DoubleNumerics;

public static unsafe partial class Vector
{
    /// <summary>Gets the element at the specified index.</summary>
    /// <param name="vector">The vector to get the element from.</param>
    /// <param name="index">The index of the element to get.</param>
    /// <returns>The value of the element at <paramref name="index" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index" /> was less than zero or greater than the number of elements.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static double GetElement(this Vector2D vector, int index)
    {
        if (index >= Vector2D.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index cannot be higher than 1");
        }

        return vector.GetElementUnsafe(index);
    }

    /// <summary>Creates a new <see cref="Vector2D" /> with the element at the specified index set to the specified value and the remaining elements set to the same value as that in the given vector.</summary>
    /// <param name="vector">The vector to get the remaining elements from.</param>
    /// <param name="index">The index of the element to set.</param>
    /// <param name="value">The value to set the element to.</param>
    /// <returns>A <see cref="Vector2D" /> with the value of the element at <paramref name="index" /> set to <paramref name="value" /> and the remaining elements set to the same value as that in <paramref name="vector" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index" /> was less than zero or greater than the number of elements.</exception>
    internal static Vector2D WithElement(this Vector2D vector, int index, double value)
    {
        if (index >= Vector2D.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index, "Index cannot be higher than 1");
        }

        Vector2D result = vector;
        result.SetElementUnsafe(index, value);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static double GetElementUnsafe(in this Vector2D vector, int index)
    {
        Debug.Assert((index >= 0) && (index < Vector2D.Count));
        ref double address = ref Unsafe.AsRef(in vector.X);
        return Unsafe.Add(ref address, index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SetElementUnsafe(ref this Vector2D vector, int index, double value)
    {
        Debug.Assert((index >= 0) && (index < Vector2D.Count));
        Unsafe.Add(ref vector.X, index) = value;
    }

    /// <summary>Reinterprets a <see langword="Vector4" /> as a new <see cref="Vector128&lt;Single&gt;" />.</summary>
    /// <param name="value">The vector to reinterpret.</param>
    /// <returns><paramref name="value" /> reinterpreted as a new <see langword="Vector128&lt;Single&gt;" />.</returns>
    public static Vector128<double> AsVector128(this Vector2D value)
    {
#if MONO
            return Unsafe.As<Vector2D, Vector128<double>>(ref value);
#else
        return Unsafe.BitCast<Vector2D, Vector128<double>>(value);
#endif
    }
}
