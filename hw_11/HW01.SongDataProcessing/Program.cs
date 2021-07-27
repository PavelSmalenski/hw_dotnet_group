using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW01.SongDataProcessing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the song name, please:");
            string songTitle = Console.ReadLine();

            Console.WriteLine("Enter the song duration (minutes)");
            int songMinutes = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the author of the song:");
            string songAuthor = Console.ReadLine();

            Console.WriteLine("Enter issue year of the song (YYYY)");
            int albumYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter ganre of the song (Classical(or 0), Rock(or 1), Pop(or 2), Hip_hop(or 3), Reggae(or 4), " +
                "Folk(or 5), Jazz(or 6), Disco(or 7), Electronic(or 8)):");
            MusicGenre songGenre;

            string numberOfGanre = Console.ReadLine();

            bool result = MusicGenre.TryParse(numberOfGanre, out songGenre);
            if (!result)
            {
                songGenre = default(MusicGenre);
            }

            Song firstSong = new Song(songTitle, songMinutes, songAuthor, albumYear, songGenre);

            GetSongData(firstSong);

            object mySong = GetSongData(firstSong);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            string newString = Newtonsoft.Json.JsonConvert.SerializeObject(mySong);
            sw.Stop();
            Console.WriteLine($"{sw.Elapsed}");

            Console.WriteLine(newString);

            sw.Start();
            string secondString = JsonSerializer.Serialize(mySong);
            sw.Stop();
            Console.WriteLine($"{sw.Elapsed}");

            Console.WriteLine(secondString);

            Console.ReadKey();
        }

        static object GetSongData(Song newSong)
        {
            var mySong = new { newSong.Title, newSong.Minutes, newSong.Author, newSong.AlbumYear, newSong.Genre };
            return mySong;
        }
    }
}
