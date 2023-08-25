using System.Diagnostics;

namespace MoverArquivos.Entities
{
    internal class OrganizeData
    {
        public static void ByType(string files)
        {
            String line;
            Process cmd = new Process();
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr;
            string command = "/C cd " + files + " && dir /b /o:n >filesnames.txt";
            cmd = Process.Start("cmd.exe", command);
            sr = new StreamReader(files + "/filesnames.txt");
            //Read the first line of text
            line = (sr.ReadLine()).Trim();
            //Continue to read until you reach end of file
            while (line != null)
            {
                List<string> fileParts = new (line.Split("."));
                string fileType = fileParts.Last();
                string command1 = "/C mkdir "+ files + "/" + fileType + " && " + "move " + files + "/" + line + " " + files + "/" + fileType;
                cmd = Process.Start("cmd.exe", command1);

                Thread.Sleep(3000);
                cmd.Kill();
                cmd.Close();

                //Read the next line
                line = (sr.ReadLine()).Trim();
            }

            //close the file
            sr.Close();
            string command2 = "/C del " + files + "/filesnames.txt";
            cmd = Process.Start("cmd.exe", command2);
            Thread.Sleep(1000);
            cmd.Kill();
            cmd.Close();
            Console.ReadLine();
        }
    }
}
