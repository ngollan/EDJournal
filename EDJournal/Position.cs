using System;

namespace EDJournal
{
  class Position
  {
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Position(double x, double y, double z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public static double Distance(Position a, Position b)
    {
      double dx = a.X - b.X;
      double dy = a.Y - b.Y;
      double dz = a.Z - b.Z;

      return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
  }
}