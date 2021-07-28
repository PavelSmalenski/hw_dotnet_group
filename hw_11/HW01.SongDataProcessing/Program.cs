using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace HW01.SongDataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Song song1 = EnterSong();// new Song("Name", 123, "SongAuthor", 2000, (Genre)2);// EnterSong();

            string sonngStr = GetSongData(song1).ToString();
            Console.WriteLine(sonngStr);

            Console.WriteLine(JsonConvert.SerializeObject(song1));

            int syzeArray = 10;
            Song[] songs = new Song[syzeArray];
            for (int i = 0; i < syzeArray; i++)
            {
                songs[i] = new Song($"Name{i}", 123, $"SongAuthor{i}", 2000, (Genre)2);
            }

            Stopwatch sw = new Stopwatch();

            NewtonsoftJSON(songs, sw);

            TimeSpan timeJSON = sw.Elapsed;
            sw.Reset();

            SystemJSON(songs, sw);

            Console.WriteLine($"Время JsonConvert      = {timeJSON}"); ;
            Console.WriteLine($"Время System.Text.Json = {sw.Elapsed}");

        }

        public static object GetSongData(Song song)
        {
            var result = new { Name = song.SongName, Duration = song.Duration, Year = song.Year };

            return result;
        }

        public static Song EnterSong()
        {
            Song song = new Song();

            Console.WriteLine("Введите название песни:");
            song.SongName = Console.ReadLine();

            Console.WriteLine("Введите длительность песни:");
            song.Duration = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите автора песни:");
            song.Author = Console.ReadLine();

            Console.WriteLine("Введите год выпуска песни:");
            song.Year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите/выберете жанр песни:");
            Console.WriteLine(" Unknown=0, Pop=1, Rock=2, Classic=3, Jazz=4, Electronic=5");
            string strGenre = Console.ReadLine();
            int intGenre = 0;

            if (Enum.IsDefined(typeof(Genre), strGenre))  
            {
                song.Genre = (Genre)Enum.Parse(typeof(Genre), strGenre);
            }

            if (Int32.TryParse(strGenre, out intGenre))
            {
                if (Enum.IsDefined(typeof(Genre), intGenre))  
                {
                    song.Genre = (Genre)Enum.Parse(typeof(Genre), strGenre);
                }
            }

            return song;
        }

        private static void SystemJSON(Song[] songs, Stopwatch sw)
        {
            sw.Start();
            for (int i = 0; i < songs.Length; i++)
            {
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(songs[i]));
            }
            sw.Stop();
        }

        private static void NewtonsoftJSON(Song[] songs, Stopwatch sw)
        {
            sw.Start();
            for (int i = 0; i < songs.Length; i++)
            {
                Console.WriteLine(JsonConvert.SerializeObject(songs[i]));
            }
            sw.Stop();
        }
    }
}
