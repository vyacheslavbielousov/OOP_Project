
class Program
{

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; // Unicode is UTF-16LE
        Console.InputEncoding = System.Text.Encoding.Unicode;
        // Обов'язковий вивід згідно з вимогами Версії 1
        Console.WriteLine("ПІБ студента: Іванов Іван Іванович, курс: 2, група: КН-21");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 1");
        Console.WriteLine("Старт імітації");
        Console.WriteLine("======================================================================");

        // TODO: Creating and adding things for future releases

        Console.WriteLine("======================================================================");
        Console.WriteLine("Фініш імітації");

        Console.ReadLine();
    }
}