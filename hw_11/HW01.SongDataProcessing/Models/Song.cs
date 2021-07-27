
namespace HW01.SongDataProcessing
{
    class Song
    {
        public string Title { get; set; }
        public int Minutes { get; set; }
        public string Author { get; set; }
        public int AlbumYear { get; set; }
        public MusicGenre Genre { get; set; }

        public Song()
        { }

        public Song(string title, int minutes, string author, int albumYear, MusicGenre genre)
        {
            Title = title;
            Minutes = minutes;
            Author = author;
            AlbumYear = albumYear;
            Genre = genre;
        }
    }
}
