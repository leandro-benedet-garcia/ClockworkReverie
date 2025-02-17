using System;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace ClockworkReverie.CustomMath.Relativity;

public static class Vector4Extension
{
  public static float MagnitudeTimeSquared(this Vector4 vec)
  {
    var squared = vec * vec;
    var sum = Vector128.Sum(Vector128.Create(squared.X, squared.Y, squared.Z, 0.0f));
    return sum - squared.W;
  }
}
