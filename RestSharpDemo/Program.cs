using RestSharpDemo.Model;
using System;
using System.Collections.Generic;

namespace RestSharpDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                try
                {
                    DisplayMenu();
                    char pressedChar = Console.ReadKey(true).KeyChar;
                    Console.Clear();
                    switch (pressedChar)
                    {
                        case 'q':
                            return;

                        case '1':
                            Sync();
                            break;

                        case '2':
                            Async();
                            break;

                        case '3':
                            GetAll();
                            break;

                        case '4':
                            Post();
                            break;

                        case '5':
                            Delete();
                            break;

                        case '6':
                            DeleteAll();
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Appuyer sur une touche pour retouner au menu...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Une exception s'est produite : {e.Message}");
                }
            } while (true);
        }

        private static void Async()
        {
            Console.WriteLine("Get async");
            int numero = SaisirEntier();
            RestSharpSample sample = new RestSharpSample();
            Contrat contrat = sample.GetDataAsync(numero).Result;
            DisplayContrat(contrat);
        }

        private static void Delete()
        {
            Console.WriteLine("Delete par numéro");
            int numero = SaisirEntier();
            RestSharpSample sample = new RestSharpSample();
            sample.DeleteDataAsync(numero);
            Console.WriteLine($"Le contrat {numero} a été supprimé !");
        }

        private static void DeleteAll()
        {
            Console.WriteLine("Delete all");
            RestSharpSample sample = new RestSharpSample();
            sample.DeleteAllDataAsync();
            Console.WriteLine("Tous les contrats ont été supprimés !");
        }

        private static void DisplayContrat(Contrat contrat)
        {
            if (contrat == null)
            {
                Console.WriteLine("Pas de contrat correspondant");
            }
            else
            {
                Console.WriteLine($"Contrat {contrat.Produit} n° : {contrat.Numero}");
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("#####################");
            Console.WriteLine("Menu :");
            Console.WriteLine("#####################");
            Console.WriteLine("1 - Get sync");
            Console.WriteLine("2 - Get async");
            Console.WriteLine("3 - Get all");
            Console.WriteLine("4 - Post");
            Console.WriteLine("5 - Delete par numéro");
            Console.WriteLine("6 - Delete all");
            Console.WriteLine("Q - Quit");
        }

        private static void GetAll()
        {
            Console.WriteLine("Get all");
            RestSharpSample sample = new RestSharpSample();
            IEnumerable<Contrat> contrats = sample.GetContrats().Result;
            foreach (var contrat in contrats)
            {
                DisplayContrat(contrat);
            }
        }

        private static void Post()
        {
            Console.WriteLine("Post");
            int numero = SaisirEntier();
            Produit produit = SaisirProduit();
            RestSharpSample sample = new RestSharpSample();
            sample.PostDataAsync(new Contrat { Produit = produit, Numero = numero });
            Console.WriteLine($"Le contrat {numero} a été créé !");
        }

        private static int SaisirEntier()
        {
            do
            {
                Console.WriteLine("Saisir un entier :");
                string line = Console.ReadLine();
                if (!int.TryParse(line, out int entier))
                {
                    Console.WriteLine("Mauvaise saisie !");
                    continue;
                }

                return entier;
            } while (true);
        }

        private static Produit SaisirProduit()
        {
            do
            {
                Console.WriteLine("Taper un numéro de produit (Mres = 1, Mrec = 2, Ri = 3)");
                string line = Console.ReadLine();
                if (!int.TryParse(line, out int entier) || entier < 1 || entier > 3)
                {
                    Console.WriteLine("Mauvaise saisie !");
                    continue;
                }

                return (Produit)entier;
            } while (true);
        }

        private static void Sync()
        {
            Console.WriteLine("Get sync");
            int numero = SaisirEntier();
            RestSharpSample sample = new RestSharpSample();
            Contrat contrat = sample.GetData(numero);
            DisplayContrat(contrat);
        }
    }
}