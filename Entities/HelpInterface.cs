namespace MoverArquivos.Entities
{
    internal class HelpInterface
    {
        public override string ToString()
        {
            return 
                "Interface de Ajuda \n" + 
                "\n" +
                "   ajuda -> Abre a interface de ajuda(help).\n" +
                "   clear -> Cleans the prompt." +
                "   copy [-adb or -cmd] [-all or files.txt(directory)] [from where the files come(directory)] [for where the files go(directory)]\n" +
                "           -> Copies one or more files to another location;\n" +
                "           - [-adb] -> copy from a device connected by ADB;\n" +
                "           - [-cmd] -> copy files accessible by cmd;\n" +
                "           - [-all] -> selects all files from selected directory(ONLY WORKS IN CMD);\n" +
                "           - [files.txt(directory)] -> list of files to be copy(needs to have 3 columns and one space between each column).\n" +
                "   exit -> Quits the program.\n" +
                "   help -> Open the help interface.\n" +
                "   move [-cmd] [-all or files.txt(directory)] [from where the files come(directory)] [for where the files go(directory)]\n" +
                "           -> Moves one or more files to another location;\n" +
                "           - [-cmd] -> only option available for now;\n" +
                "           - [-all] -> selects all files from selected directory(ONLY WORKS IN CMD);\n" +
                "           - [files.txt(directory)] -> list of files to be copy(needs to have 3 columns and one space between each column).\n" +
                "WARNING: Use these bars ( / ) to write directories.\n";
        }
    }
}
