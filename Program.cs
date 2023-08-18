using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MoverArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            String line;
            string[] vet = new string[3];
            try
            {
                Process cmd = new Process();
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\raule\\Desktop\\nomes.txt");
                //Read the first line of text
                line = (sr.ReadLine()).Trim();
                //Continue to read until you reach end of file
                while (line != null)
                {

                    string[] words = line.Split(' ');
                    int i = 0;
                    foreach (string word in words)
                    {                    
                        vet[i] = word;
                        i++;
                    }
                    for (int u = 0; u < 3; u++)
                    {
                        string command = "/C adb pull /sdcard/DCIM/Camera/" + vet[u] + " E:/FamiliaPaiva/FotosNuria";
                        cmd = Process.Start("cmd.exe", command);
                    }

                    //write the line to console window
                    Console.WriteLine(line);

                    Thread.Sleep(10000);
                    cmd.Kill();
                    cmd.Close();
                                 
                    //Read the next line
                    line = (sr.ReadLine()).Trim();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            
        }
    }
}