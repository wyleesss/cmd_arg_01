using System.Text;

class Program
{
    static bool CheckCorrectness(string[] args)
    {
        try
        {
            return Double.TryParse(args[0], out var result)
                && Double.TryParse(args[2], out result)
                && "+-/xх".Contains(args[1]); //укр-англ х
        }
        catch(IndexOutOfRangeException)
        {
            return false;
        }
    }

    static double Calculate(string[] args)
    {
        try
        {
            switch (args[1])
            {
                case "+":
                    return double.Parse(args[0]) + double.Parse(args[2]);

                case "-":
                    return double.Parse(args[0]) - double.Parse(args[2]);

                case "/":
                    return double.Parse(args[0]) / double.Parse(args[2]);

                case "x": //англ
                    return double.Parse(args[0]) * double.Parse(args[2]);

                case "х": //укр
                    return double.Parse(args[0]) * double.Parse(args[2]);

                default:
                    return 0;
            }
        }
        catch(Exception)
        {
            return 0;
        }
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (!CheckCorrectness(args))
        {
            Console.WriteLine("\nневірний синтаксис!\n\n" +
                              "шаблон правильного вводу аргументів:\n" +
                              "(число) [операція] (число)\n\n" +
                              "доступні операції:\n" +
                              "[+]: додавання\n" +
                              "[-]: віднімання\n" +
                              "[/]: ділення\n" +
                              "[x]: множення\n");
        }
        else
        {
            Console.WriteLine("\nрезультат => " + Calculate(args).ToString() + "\n");
        }
    }
}