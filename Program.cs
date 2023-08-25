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
            ErrorInterface error = new ErrorInterface();
            Console.Write("> ");
            string comando = Console.ReadLine();
            string[] vet = comando.Split(" ");
            int verification = 0;
            switch (comando)
            {
                case (""):
                    verification++;
                    break;
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
            }
            if (verification == 0)
            {
                if (vet[0] == "copy")
                {
                    if (vet.Length == 5)
                    {
                        if (vet[1] == "-adb")
                        {
                            try { CopyData.WithAdb(vet[2], vet[3], vet[4]); }
                            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                            finally { Console.WriteLine("The work is done."); }
                        }
                        else if (vet[1] == "-cmd")
                        {
                            try { CopyData.WithCmd(vet[2], vet[3], vet[4]); }
                            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                            finally { Console.WriteLine("The work is done."); }
                        }
                        else { Console.WriteLine(ErrorInterface.Code("ERROR_0002")); }
                    }
                    else { Console.WriteLine(ErrorInterface.Code("ERROR_0003")); }
                }
                else if (vet[0] == "move")
                {
                    if (vet.Length == 5)
                    {
                        if (vet[1] == "-cmd")
                        {
                            try { MoveData.WithCmd(vet[2], vet[3], vet[4]); }
                            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                            finally { Console.WriteLine("The work is done!"); }
                        }
                        else { Console.WriteLine(ErrorInterface.Code("ERROR_0002")); }
                    }
                    else { Console.WriteLine(ErrorInterface.Code("ERROR_0003")); }

                }
                else if (vet[0] == "organize")
                {
                    if (vet.Length == 3)
                    {
                        if (vet[1] == "-type")
                        {
                            try { OrganizeData.ByType(vet[2]); }
                            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
                            finally { Console.WriteLine("The work is done!"); }
                        }
                        else { Console.WriteLine(ErrorInterface.Code("ERROR_0002")); }
                    }
                    else { Console.WriteLine(ErrorInterface.Code("ERROR_0003")); }
                }
                else { Console.WriteLine(ErrorInterface.Code("ERROR_0001")); }
            }
            goto NewCommand;
        }
    }
}