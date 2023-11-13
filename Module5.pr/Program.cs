using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MyException : Exception
{
    public MyException(string message) : base(message)
    {
    }
}

class MyClass
{
    public void Method1()
    {
        Console.WriteLine("Method1 начал выполнение");
        Method2();
        Console.WriteLine("Method1 завершил выполнение");
    }

    public void Method2()
    {
        Console.WriteLine("Method2 начал выполнение");
        try
        {
            // Генерируем исключение
            throw new MyException("Это мое исключение");
        }
        catch (MyException e)
        {
            Console.WriteLine($"Поймали исключение: {e.Message}");
            // Поднимаем исключение в вызывающий метод (Method1)
            throw;
        }
        finally
        {
            Console.WriteLine("Мы в блоке finally Method2");
        }
    }
}

class Program
{
    static void Main()
    {
        MyClass myClass = new MyClass();

        try
        {
            myClass.Method1();
        }
        catch (MyException e)
        {
            Console.WriteLine($"Поймали исключение в методе Main: {e.Message}");
        }

        Console.WriteLine("Программа завершила выполнение");
        Console.ReadKey();
    }
}