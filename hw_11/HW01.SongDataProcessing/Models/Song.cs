using System;
using System.Collections.Generic;
using System.Text;

namespace HW01.SongDataProcessing
{
    class Song
    {
        string _name;
        double _duration;
        string _author;
        int _issueYear;
        Genre _genre;

        public Song()
        {
            _name = "unknown";
            _duration = 0;
            _author = "unknown";
            _issueYear = 0;
            _genre = Genre.Unknown;
        }

        public Song(string name, double duration, string author, int issueYear, Genre genre)
        {
            _name = name;
            _duration = duration;
            _author = author;
            _issueYear = issueYear;
            _genre = genre;
        }

        public string Name { get => _name; set => _name = value; }
        public double Duration { get => _duration; set => _duration = value; }
        public string Author { get => _author; set => _author = value; }
        public int IssueYear { get => _issueYear; set => _issueYear = value; }
        internal Genre Genre { get => _genre; set => _genre = value; }

        public void NewSong()
        {
            string name, author;
            int issueYear, songGenre;
            string genre;
            double duration;

            Console.Write("Song name: ");
            name = Console.ReadLine();
            Console.Write("Song author: ");
            author = Console.ReadLine();            
            Console.Write("Song duration in minutes: ");
            duration = double.Parse(Console.ReadLine());
            Console.Write("Song year of issue: ");
            issueYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose song genre by number: ");
            foreach (string gn in Enum.GetNames(typeof(Genre)))
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(Genre), gn)}) {gn}");
            }
            songGenre = int.Parse(Console.ReadLine());
            genre = Enum.GetName(typeof(Genre), songGenre);
            if (string.IsNullOrEmpty(genre))
            {
                Console.Write("Incorrect number. Write genre: ");
                genre = Console.ReadLine();
            }            
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author))
            {
                throw new System.Exception("Song/author cannot be empty");
            }

            _name = name;
            _duration = duration;
            _author = author;
            _issueYear = issueYear;
            if (Enum.IsDefined(typeof(Genre), genre))
            {
                _genre = (Genre)Enum.Parse(typeof(Genre), genre);
            }
            else
            {
                _genre = Genre.Unknown;
            }
            
        }

        public static object GetSongData(Song song)
        {
            var sng = new 
            { 
                Title = song.Name, 
                Minutes = song.Duration, 
                AlbumYear = song.IssueYear 
            };
            return sng;
        }

        public override string ToString()
        {            
            return ($"{_author}-\"{_name}\"({_genre}, {_issueYear}), duration: {_duration}sec");
        }
    }
}
