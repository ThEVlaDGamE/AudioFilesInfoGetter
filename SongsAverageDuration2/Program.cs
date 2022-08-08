using System.Text;
using TagLib;

namespace Application
{
    class Program
    {
        // Путь, по которому сканировать файлы
        static string audioPath = "";
        // Расширение, с файлы с которым будут сканироваться
        static string searchingPattern = "*.mp3*";

        static string[] fullfilesPath;
        static List<double> songsDuration = new List<double>();

        static void Main(string[] args)
        {
            // Получение всех файлов с указанным расширением по указанному пути, включая подкаталоги (последний аргумент)
            fullfilesPath = Directory.GetFiles(audioPath, searchingPattern, SearchOption.AllDirectories);

            // Составление массива длительности файлов, вывод длительность каждого файла в консоль
            for (int i = 0; i < fullfilesPath.Length; i++)
            {
                var file = TagLib.File.Create(fullfilesPath[i]);
                Console.WriteLine(fullfilesPath[i] + "  ---  " +  file.Properties.Duration.TotalSeconds.ToString());

                songsDuration.Add(file.Properties.Duration.TotalSeconds);
                // Для получения другой информации обращайтесь к file.Properties.
            }

            Console.WriteLine("\n\n");
            // Подсчёт общей длительности файлов (в секундах)
            double summ = 0;
            for (int i = 0; i < songsDuration.Count; i++)
            {
                summ += songsDuration[i];
            }

            // Подсчёт средней длины файла
            int result = (int)Math.Round(summ / songsDuration.Count);

            // Вывод результатов в консоль
            Console.WriteLine("Общая длительность файлов: " + GetMinSecString((int)Math.Round(summ)));
            Console.WriteLine("Средня длительность файлов: " + GetMinSecString(result));


            Console.ReadLine();
        }

        static string GetMinSecString(int seconds)
        {
            int resultMin = 0;
            while (seconds >= 60)
            {
                resultMin++;
                seconds -= 60;
            }

            return (resultMin + " минут " + seconds + " секунд");
        }
    }
}




