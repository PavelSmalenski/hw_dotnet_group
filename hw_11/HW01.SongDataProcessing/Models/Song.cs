using System;
using System.Collections.Generic;
using System.Text;

namespace HW01.SongDataProcessing.Models
{
    class Song
    {
        public SongGenre Genre { get; private set; }
        public string Name { get; private set; }
        public TimeSpan Length { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public Song(SongGenre genre, string name, TimeSpan length, string author, int year)
        {
            Genre = genre;
            Name = name;
            Length = length;
            Author = author;
            Year = year;
        }
    }
}
