using HW01.SongDataProcessing.Models;
using System;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HW01.SongDataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song;
            try
            {
                string genre = ReadValue("Genre");
                song = new Song(Enum.IsDefined(typeof(SongGenre), genre) ? (SongGenre)Enum.Parse(typeof(SongGenre), genre) : default,
                    ReadValue("Name"),
                    TimeSpan.Parse(ReadValue("Length (hh:mm:ss)")),
                    ReadValue("Author"),
                    int.Parse(ReadValue("Year")));
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Wrong parameters entered: {ex}");
                return;
            }

            // Write to console serialized object
            string newtonsoftJson = JsonConvert.SerializeObject(GetSongData(song));
            string microsoftJson = System.Text.Json.JsonSerializer.Serialize(GetSongData(song));

            Console.WriteLine(newtonsoftJson);
            Console.WriteLine(microsoftJson);

            //Measure serialization time
            Console.WriteLine($"Time measurement for Newtonsoft library: {MeasureSerializationTime(JsonConvert.SerializeObject, GetSongData(song))}");
            Console.WriteLine($"Time measurement for Microsoft library: {MeasureSerializationTime(obj => System.Text.Json.JsonSerializer.Serialize(obj), GetSongData(song))}");
        }

        static object GetSongData(Song song)
        {
            return new { Title = song.Name, Minutes = song.Length.Minutes, AlbumYear = song.Year };
        }

        static string ReadValue(string valueName)
        {
            string res = null;
            while (string.IsNullOrEmpty(res))
            {
                Console.Write($"Provide value {valueName}: ");
                res = Console.ReadLine();
            }
            return res;
        }

        static TimeSpan MeasureSerializationTime(Func<object, string> serializer, object serializeInput, int numRuns = 100_000)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < numRuns; i++)
            {
                var _ = serializer(serializeInput);
            }
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
