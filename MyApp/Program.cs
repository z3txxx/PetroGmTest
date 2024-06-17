using GeometryShared;
using System.IO;
namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Не успел сделать обращение к текстовому файлу через директории, не находит файл, предполагаю изза прав доступа
            string relativePath = Path.Combine("recources", "input.txt");
            string fullPath = Path.Combine(Environment.CurrentDirectory, relativePath);
            //ShapesFromInput shapesFromInput = new ShapesFromInput(fullPath);

            ShapesFromInput shapesFromInput = new ShapesFromInput("C:\\Users\\Эрдэм\\source\\repos\\TestNo1467\\MyApp\\resources\\input.txt");
            shapesFromInput.Run();
            Console.ReadLine();
        }
    }
}
