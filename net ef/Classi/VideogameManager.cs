using net_ef.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Classes
{
    public static class GameManager
    {
        public static void AddGame()
        {
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Descrizione: ");
            var overview = Console.ReadLine();

            Console.Write("Data di uscita (yyyy-MM-dd): ");
            var releaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Id software house: ");
            var softwareHouseId = Convert.ToInt64(Console.ReadLine());

            using (VideogameContext db = new VideogameContext())
            {
                var game = new Videogame(name, overview, releaseDate, softwareHouseId);
                db.Add(game);
                db.SaveChanges();
            }
            Console.WriteLine("Videogioco inserito\n");
        }

        public static void AddSoftwareHouse()
        {
            using (VideogameContext db = new VideogameContext())
            {
                Console.Write("Inserisci il nome della software house: ");
                string shName = Console.ReadLine();

                SoftwareHouse softwareHouse = new SoftwareHouse { Name = shName };
                db.SoftwareHouses.Add(softwareHouse);
                db.SaveChanges();
            }
            Console.WriteLine("Operazione completata\n");
        }

        public static void SearchGame()
        {
            bool search = true;
            while (search)
            {
                Console.WriteLine("\n1. Ricerca per ID");
                Console.WriteLine("2. Ricerca per nome");
                Console.WriteLine("3. Indietro");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    case "ricerca per id":
                    case "id":
                        Console.WriteLine("Inserisci l'ID del gioco");
                        var gameID = Convert.ToInt64(Console.ReadLine());
                        using (VideogameContext db = new VideogameContext())
                        {
                            Videogame vg = db.Videogames.FirstOrDefault(vg => vg.Id == gameID);

                            if (vg == null)
                            {
                                Console.WriteLine("Nessun risultato trovato");
                                break;
                            }
                            Console.WriteLine($"Dettagli: {vg.Name} \n{vg.Overview} \n{vg.ReleaseDate}");
                        }
                        break;
                    case "2":
                    case "ricerca per nome":
                    case "nome":
                        Console.WriteLine("Inserisci il nome del gioco");
                        var gameName = Console.ReadLine();
                        using (VideogameContext db = new VideogameContext())
                        {
                            Videogame vg = db.Videogames.FirstOrDefault(vg => vg.Name == gameName);

                            if (vg == null)
                            {
                                Console.WriteLine("Nessun risultato trovato");
                                break;
                            }
                            Console.WriteLine($"Dettagli: {vg.Name} \n{vg.Overview} \n{vg.ReleaseDate}");
                        }
                        break;
                    case "3":
                    case "indietro":
                        search = false;
                        break;
                    case "esci":
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Input non valido");
                        break;
                }
            }
        }

        public static void DeleteGame()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Inserisci l'ID del gioco da eliminare");
                var gameID = Convert.ToInt64(Console.ReadLine());
                using (VideogameContext db = new VideogameContext())
                {
                    Videogame vg = db.Videogames.FirstOrDefault(vg => vg.Id == gameID);

                    if (vg == null)
                    {
                        Console.WriteLine("Nessun risultato trovato");
                        break;
                    }
                    Console.WriteLine($"Dettagli: {vg.Name} \n{vg.Overview} \n{vg.ReleaseDate}");
                    Console.WriteLine("Sei sicuro di voler eliminare questo gioco? (s/n)");

                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "s":
                            db.Remove(vg);
                            db.SaveChanges();
                            Console.WriteLine("Videogioco eliminato con successo\n");
                            loop = false;
                            break;
                        case "n":
                            Console.WriteLine();
                            loop = false;
                            break;
                        case "esci":
                        case "exit":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Input non valido");
                            break;
                    }
                }
            }
        }
    }
}