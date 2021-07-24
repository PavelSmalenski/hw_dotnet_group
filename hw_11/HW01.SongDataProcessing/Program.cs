using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace HW01.SongDataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            /*try
            {
                Song song = new Song();
                song.NewSong();
                Console.WriteLine(song);
                Console.WriteLine(Song.GetSongData(song));
                songs.Add(song);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }*/

            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                songs.Add(new Song(Faker.Internet.UserName(),
                                   (double)rnd.Next(100, 500) / 100,
                                   Faker.Name.FullName(),
                                   rnd.Next(1860, 2021),
                                   (Genre)(rnd.Next(1, 12))));
            }
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(songs));
            SerializingByMicrosoftAPI(songs);
            SerializingByNewtonsoft(songs);

        }

        static void SerializingByMicrosoftAPI(List<Song> songs)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string output = System.Text.Json.JsonSerializer.Serialize(songs);
            //Console.WriteLine(output);
            List<Song> dSongs = System.Text.Json.JsonSerializer.Deserialize<List<Song>>(output);
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed by Microsoft API: {stopwatch.Elapsed}");
        }
        static void SerializingByNewtonsoft(List<Song> songs)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(songs);
            //Console.WriteLine(output);
            List<Song> dSongs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(output);
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed by Newtonsoft API: {stopwatch.Elapsed}");
        }
    }
}
