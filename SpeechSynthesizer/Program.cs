// Written by Noah Coleman
// 10/26/2020

// This program reads text from a .txt file and implements a speech synthesizer to speak the song's lyrics

using System;
using System.Speech.Synthesis;

namespace Speech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int songNumber = -1;
            // Creating a new SpeechSynthesizer object called using System.Speech.Synthesis
            SpeechSynthesizer aSpeechSynthesizer = new SpeechSynthesizer();
            // Making a new song object
            Song aSong = new Song();

            // Array of song paths
            string[] anArrayOfSongPaths =
                {   @"C:\Users\noahc\Desktop\Old School Stuff\CIS 122\Lecture Files\Songs\Gorgeous by Taylor Swift.txt",
                    @"C:\Users\noahc\Desktop\Old School Stuff\CIS 122\Lecture Files\Songs\Grenade Bruno Mars.txt",
                    @"C:\Users\noahc\Desktop\Old School Stuff\CIS 122\Lecture Files\Songs\Too Late by Weeknd.txt",
                    @"C:\Users\noahc\Desktop\Old School Stuff\CIS 122\Lecture Files\Songs\Feel Good.txt" };


            // User data entry
            Console.WriteLine("List of songs:");
            Console.WriteLine("Enter 1 for Gorgeous by Taylor Swift");
            Console.WriteLine("Enter 2 for Grenade by Bruno Mars");
            Console.WriteLine("Enter 3 for Too Late by The Weeknd");
            Console.WriteLine("Enter 4 for Feel Good Inc");

            // Try/catch to make sure user enters an int.
            try
            {
                songNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Input needs to be a number between 1 and 4.");
            }


            // Listing Installed Voices
            /*
            foreach (var v in aSpeechSynthesizer.GetInstalledVoices().Select(v => v.VoiceInfo))
            {
                Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}", v.Description, v.Gender, v.Age);
            }
            */
            Console.WriteLine();

            // Select a voice
            aSpeechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);


            // Write each line to console and speak the lyrics
            try
            {
                for (int i = 0; i < aSong.GetSong(anArrayOfSongPaths[songNumber - 1]).Length; i++)
                {
                    Console.WriteLine(aSong.GetSong(anArrayOfSongPaths[songNumber - 1])[i]);
                    aSpeechSynthesizer.Speak(aSong.GetSong(anArrayOfSongPaths[songNumber - 1])[i]);
                }
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine("Input needs to be a number between 1 and 4.");
            }

            Console.ReadLine();
        }
    }
}