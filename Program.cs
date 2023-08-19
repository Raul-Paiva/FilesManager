using System;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using MoverArquivos.Entities;

namespace MoverArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            NewCommand:
            Console.Write("> ");
            string comando = Console.ReadLine();
            string[] vet = comando.Split(" ");
            int verification = 0;
            switch (comando)
            {
                case ("ajuda"):
                    HelpInterface hi2 = new HelpInterface();
                    Console.WriteLine(hi2);
                    verification++;
                    break;
                case ("exit"):
                    Environment.Exit(1);
                    break;
                case ("help"):
                    HelpInterface hi1 = new HelpInterface();
                    Console.WriteLine(hi1);
                    verification++;
                    break;
                case ("clear"):
                    Console.Clear();
                    verification++;
                    break;
                default:
                    Console.WriteLine("Unrecognized command.");
                    Console.WriteLine("Commands are all lowercase. Try again");
                    Console.WriteLine();
                    verification++;
                    break;
            }
            if (verification == 0)
            {
                switch (vet[0])
                {
                    case ("copy"):
                        switch (vet[1])
                        {
                            case ("-adb"):
                                try { CopyData.WithAdb(vet[2], vet[3], vet[4]); }
                                catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                                finally { Console.WriteLine("The work is done. (•◡•)"); }
                                break;
                            case ("-cmd"):
                                try { CopyData.WithCmd(vet[2], vet[3], vet[4]); }
                                catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                                finally { Console.WriteLine("The work is done. (•◡•)"); }
                                break;
                            default:
                                Console.WriteLine("Unrecognized command.");
                                Console.WriteLine("Commands are all lowercase. Try again");
                                Console.WriteLine();
                                break;
                        }

                        break;
                    case ("move"):
                        switch (vet[1])
                        {
                            case ("-cmd"):
                                try { MoveData.WithCmd(vet[2], vet[3], vet[4]); }
                                catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                                finally { Console.WriteLine("The work is done. (•◡•)"); }
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Unrecognized command.");
                        Console.WriteLine("Commands are all lowercase. Try again");
                        Console.WriteLine();
                        break;
                }
            }
            goto NewCommand;        
        }
    }
}