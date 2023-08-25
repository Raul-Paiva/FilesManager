namespace MoverArquivos.Entities
{
    internal class ErrorInterface
    {
        public static string Code(string code)
        {
            switch (code)
            {
                case ("ERROR_0001"):
                    return 
                        "Unrecognized command.\n" +
                        "Commands are all lowercase. Try again\n";

                case ("ERROR_0002"):
                    return
                        "Unrecognized parameter\n" +
                        "Commands are all lowercase. Try again\n";
                case ("ERROR_0003"):
                    return
                        "Incomplete command.\n" +
                        "Try again\n";
                default:
                    return
                        "Unrecognized error\n" +
                        "Commands are all lowercase. Try again\n";


            }                    
        }
    }
}
