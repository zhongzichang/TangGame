/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/8
 * Time: 20:50
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangUtils
{
  /// <summary>
  /// Description of Point.
  /// </summary>
  [Serializable]
  public class Point
  {

    public int x;
    public int y;

    public Point()
    {
      this.x = 0;
      this.y = 0;
    }

    public Point(int x, int y)
    {
      this.x = x;
      this.y = y;
    }
    public override bool Equals(object obj)
    {
      // If this and obj do not refer to the same type, then they are not equal.
      if (obj.GetType() != this.GetType()) return false;

      // Return true if  x and y fields match.
      Point other = (Point) obj;
      return (this.x == other.x) && (this.y == other.y);
    }

    // Return the XOR of the x and y fields.
    public override int GetHashCode()
    {
      return x ^ y;
    }

    // Return the point's value as a string.
    public override String ToString()
    {
      return String.Format("({0}, {1})", x, y);
    }

    // Return a copy of this point object by making a simple field copy.
    public Point Copy()
    {
      return (Point) this.MemberwiseClone();
    }
  }
}
