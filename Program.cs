using System;
using System.Globalization;

namespace ED_DistanceSummer {
  class Program
  {
    static void Main(string[] args)
    {
      var visits = new System.Collections.Generic.SortedSet<EDJournal.SystemVisit>();
      var systems = new System.Collections.Generic.HashSet<string>();

      string journal_path = System.IO.Path.Combine(
          Environment.GetEnvironmentVariable("USERPROFILE"),
          "Saved Games",
          "Frontier Developments",
          "Elite Dangerous"
      );

      foreach (string journal_file in System.IO.Directory.EnumerateFiles(journal_path, "Journal.*.log"))
      {
        foreach (var visit in EDJournal.Consumer.ProcessFile(journal_file))
        {
          visits.Add(visit);
          systems.Add(visit.Name);
        }
      }

      double distance = 0;
      EDJournal.Position previous = null;

      foreach (var visit in visits)
      {
        if (previous != null)
        {
          distance += visit.DistanceTo(previous);
        }
        previous = visit.Position;
      }

      Console.WriteLine("Found {0} visits to {1} distinct systems. Travelled {2} light years.",
        visits.Count,
        systems.Count,
        distance.ToString("N2", CultureInfo.CreateSpecificCulture("en-UK"))
      );
    }
  }
}