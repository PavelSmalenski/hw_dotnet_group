using System;
using System.Collections.Generic;
using System.Text;

namespace HW01.SongDataProcessing
{
    class Song
    {
        public string SongName { get; set; }
        public int Duration { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }

        public Song()
        {

        }

        public Song(string name, int duration, string author, int year, Genre genre )
        {
            SongName = name;
            Duration = duration;
            Author = author;
            Year = year;
            Genre = genre;
        }

    }

    
}
