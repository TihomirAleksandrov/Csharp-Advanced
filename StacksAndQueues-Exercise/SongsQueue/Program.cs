using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstSongs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Queue<string> songs = new Queue<string>(firstSongs);

            string input = Console.ReadLine();
            while (songs.Count > 0)
            {
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splitInput[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Add")
                {
                    string song = input.Substring(4);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
