using System.Text;
using TagLib;

namespace Application
{
    class Program
    {
        static string[] fullfilesPath = Directory.GetFiles("songs/", "*.mp3*", SearchOption.AllDirectories);
        static List<double> songsDuration = new List<double>();

        static void Main(string[] args)
        {
            for (int i = 0; i < fullfilesPath.Length; i++)
            {
                var file = TagLib.File.Create(fullfilesPath[i]);
                Console.WriteLine(fullfilesPath[i] + "  ---  " +  file.Properties.Duration.TotalSeconds.ToString());

                songsDuration.Add(file.Properties.Duration.TotalSeconds);
            }

            Console.WriteLine("\n\n");
            double summ = 0;
            for (int i = 0; i < songsDuration.Count; i++)
            {
                summ += songsDuration[i];
            }

            int result = (int)Math.Round(summ / songsDuration.Count);
            Console.WriteLine(result);

            int resultMin = 0;
            while(result >= 60)
            {
                resultMin++;
                result -= 60;
            }
            Console.WriteLine(resultMin + " минут " + result + " секунд");
        }
    }
}




