using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Program
{
    public class Song : IComparable<Song>
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }

        public Song(string title, string artist, int year)
        {
            Title = title;
            Artist = artist;
            Year = year;
        }
        public int CompareTo(Song other)
        {
            return this.Year - other.Year;
        }

        public override string ToString()
        {
            return Title + ", " + Artist + " (" + Year.ToString() + ")";
        }
    }

    public class SongComparer : IComparer<Song>
    {
        public int Compare(Song x, Song y)
        {
            return x.CompareTo(y);
        }
    }
}
        
