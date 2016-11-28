using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19
{
    class Program
    {
        enum Ganre { Rock, Jazz, Blues}
        struct Song {
            public string Author;
            public string Name;
            public int Length;
            public Ganre Ganre;
        }
        static Song[] songs;

        static void Main(string[] args)
        {
            songs = new Song[] {
                new Song() {Author="Jack", Name="Baby", Length = 160, Ganre= Ganre.Blues},
                new Song() {Author="Bob", Name="Baby1", Length = 260, Ganre= Ganre.Jazz},
                new Song() {Author="Bil", Name="Baby2", Length = 220, Ganre= Ganre.Blues},
                new Song() {Author="Mo", Name="Baby3", Length = 320, Ganre= Ganre.Rock},
                new Song() {Author="Nan", Name="Baby4", Length = 150, Ganre= Ganre.Jazz},
                new Song() {Author="Ram", Name="Baby5", Length = 280, Ganre= Ganre.Blues},
                new Song() {Author="Sara", Name="Baby6", Length = 300, Ganre= Ganre.Rock},
            };

            Menu();
        }

        static void Menu() {
            Console.WriteLine("Choose actions");
            Console.WriteLine("1 - Edit song");
            Console.WriteLine("2 - Find the longest song");
            Console.WriteLine("3 - Print all song of selected ganre");
            Console.WriteLine("4 - Exit");

            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    Edit();
                    Menu();
                    break;
                case "2":
                    FindLength();
                    Menu();
                    break;
                case "3":
                    FindGanre();
                    Menu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command. Try again.");
                    Menu();
                    break;
            }
        }

        static void Edit() {
            Console.WriteLine($"Enter new name");
            string name = Console.ReadLine();
            Console.WriteLine($"Enter song index from 1 to {songs.Length}");
            int index;
            bool flag = int.TryParse(Console.ReadLine(), out index);
            if (flag) {
                if (index > 0 && index <=songs.Length) {
                    songs[index - 1].Name = name;
                }
                else
                    Console.WriteLine("Out of index range");
            }
            else
                Console.WriteLine("Invalid index");

            Console.WriteLine("All songs");
            foreach (Song song in songs) {
                Console.WriteLine($"{song.Author}, {song.Name}, {song.Length}, {song.Ganre}");
            }
        }

        static void FindLength()
        {
            Song temp;
            for (int i = 0; i < songs.Length-1; i++)
            {
                for (int j = i; j < songs.Length; j++)
                {
                    if (songs[i].Length < songs[j].Length) {
                        temp = songs[i];
                        songs[i] = songs[j];
                        songs[j] = temp;
                    }
                }
            }
            Console.WriteLine($"The longest song is {songs[0].Author}, {songs[0].Name}, {songs[0].Length}, {songs[0].Ganre}");
        }

        static void FindGanre()
        {
            Ganre ganre;
            Console.WriteLine($"Enter ganre ({string.Join(",", Enum.GetNames(typeof(Ganre)))})");            
            bool flag = Enum.TryParse(Console.ReadLine(), out ganre);
            if (flag) {
                Console.WriteLine($"Songs with ganre {ganre}");
                foreach (Song song in songs)
                {
                    if (song.Ganre == ganre)
                    {
                        Console.WriteLine($"{song.Author}, {song.Name}, {song.Length}, {song.Ganre}");
                    }
                }
            }
            else
                Console.WriteLine("No such ganre");           
        }
    }
}
