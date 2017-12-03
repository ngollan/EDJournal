using System;

namespace EDJournal
{
  class SystemVisit : IComparable<SystemVisit>
  {
    public string Name { get; set; }
    public DateTime VisitedAt { get; set; }
    public Position Position { get; set; }

    public static double Distance(SystemVisit a, SystemVisit b)
    {
      return Position.Distance(a.Position, b.Position);
    }

    public double DistanceTo(Position other)
    {
      return Position.Distance(other, Position);
    }

    public int CompareTo(SystemVisit other)
    {
      return VisitedAt.CompareTo(other.VisitedAt);
    }
  }
}