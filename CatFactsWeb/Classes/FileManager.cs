namespace CatFactsWeb.Classes
{
    public class FileManager
    {
        public static string Filename { get; set; } = "catfile.txt";
        public static string Filepath { get; set; } = "./";

        public static void Write(string textToWrite)
        {
            string file = Filepath + Filename;
            if (!File.Exists(file))
            {
                File.Create(file).Close();
            }

            File.AppendAllText(file, textToWrite + Environment.NewLine);
        }
    }
}
