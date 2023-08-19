using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoverArquivos.Entities
{
    internal class MoveData
    {
        public static void WithCmd(string quantity, string link1, string link2)
        {
            String line;
            string[] vet1 = new string[3];
            string[] vet2 = new string[1];
            Process cmd = new Process();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr;
            if (quantity == "-all")
            {
                string command = "/C cd " + link1 + " && dir /b /o:n >filesnames.txt";
                cmd = Process.Start("cmd.exe", command);
                sr = new StreamReader(link1 + "/filesnames.txt");
            }
            else { sr = new StreamReader(quantity); }
            //Read the first line of text
            line = (sr.ReadLine()).Trim();
            //Continue to read until you reach end of file
            while (line != null)
            {
                string[] words = line.Split(' ');
                int i = 0;
                foreach (string word in words)
                {
                    vet1[i] = word;
                    i++;
                }
                for (int u = 0; u < 3; u++)
                {
                    string command = "/C move " + link1 + "/" + vet1[u] + " " + link2;
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
    }
}
    

