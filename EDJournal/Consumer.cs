using System;
using JSON = Newtonsoft.Json;

namespace EDJournal
{
  class Consumer
  {

    // <summary>
    // Process a journal file and yield <see cref="SystemVisit"/> objects
    // for events that indicate the player may have jumped to a new system.
    // </summary>
    //
    // <param name="file_name">
    // Full path of the journal file to be parsed.
    // </param>
    public static System.Collections.Generic.IEnumerable<SystemVisit> ProcessFile(string file_name)
    {
      foreach (string line in System.IO.File.ReadLines(file_name))
      {
        var o = JSON.Linq.JObject.Parse(line);
        string event_name = (string)o["event"];

        if (event_name == "FSDJump" || event_name == "Location")
        {
          var json_thing = (JSON.Linq.JArray)o["StarPos"];
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