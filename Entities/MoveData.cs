using System.Diagnostics;

namespace MoverArquivos.Entities
{
    internal class MoveData
    {
        public static void WithCmd(string files, string link1, string link2)
        {
            String line;

            int z = 0;
            Process cmd = new Process();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr;
            if (files == "-all")
            {
                string command = "/C cd " + link1 + " && dir /b /o:n >filesnames.txt";
                cmd = Process.Start("cmd.exe", command);
                Thread.Sleep(1000);
                cmd.Kill();
                cmd.Close();
                sr = new StreamReader(link1 + "/filesnames.txt");
                z++;
            }
            else { sr = new StreamReader(files); }
            //Read the first line of text
            line = (sr.ReadLine()).Trim();
            //Continue to read until you reach end of file
            if (z == 0)
            {
                string[] vet1 = new string[3];
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
            }else if (z == 1)
            {
                while (line != null)
                {
                    string command = "/C copy " + link1 + "/" + line + " " + link2;
                    cmd = Process.Start("cmd.exe", command);

                    //write the line to console window
                    Console.WriteLine(line);

                    Thread.Sleep(3000);
                    cmd.Kill();
                    cmd.Close();

                    //Read the next line
                    line = (sr.ReadLine()).Trim();
                }
            }


            //close the file
            sr.Close();
            Console.ReadLine();
        }
    }
}


