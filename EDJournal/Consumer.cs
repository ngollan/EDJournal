using System;

namespace EDJournal
{
  class Consumer
  {
    public static System.Collections.Generic.IEnumerable<SystemVisit> ProcessFile(string file_name)
    {
      foreach (string line in System.IO.File.ReadLines(file_name))
      {
        var o = Newtonsoft.Json.Linq.JObject.Parse(line);
        string event_name = (string)o["event"];

        if (event_name == "FSDJump" || event_name == "Location")
        {
          var json_thing = (Newtonsoft.Json.Linq.JArray)o["StarPos"];
          yield return new SystemVisit()
          {
            Name = (string)o["StarSystem"],
            VisitedAt = DateTime.Parse((string)o["timestamp"]),
            Position = new Position(
                  (double)json_thing[0],
                  (double)json_thing[1],
                  (double)json_thing[2]
              )
          };
        }
      }
    }
  }
}