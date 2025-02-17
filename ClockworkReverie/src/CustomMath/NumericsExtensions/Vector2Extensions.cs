using System.Numerics;

namespace ClockworkReverie.CustomMath;

public static class Vector2Extensions
{
  public static Vector2 AddScaledVector(this Vector2 vec, Vector2 other, float scale)
  {
    var scaled = Vector2.Multiply(other, scale);
    return Vector2.Add(vec, scaled);
  }
}