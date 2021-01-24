// Written by Noah Coleman
// 10/26/2020

using System.IO;

namespace Speech
{
    public class Song
    {
        // Class Variables

        // Accessors

        // Constructors
        public Song()
        {
            // empty constructor
        }

        // Methods
        public string[] GetSong(string aPath)
        {
            string[] lyrics = File.ReadAllLines(aPath);
            return lyrics;
        }
    }
}
