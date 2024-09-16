using System;
using System.Globalization;

public class CustomConverter
{
    public bool Convert<T>(string value, out T result) where T : IConvertible
    {
        try
        {
            if (typeof(T) == typeof(int))
            {
                result = (T)(object)int.Parse(value);
                return true;
            }
            else if (typeof(T) == typeof(double))
            {
                result = (T)(object)double.Parse(value, CultureInfo.InvariantCulture);
                return true;
            }
            else if (typeof(T) == typeof(DateTime))
            {
                result = (T)(object)DateTime.Parse(value, CultureInfo.InvariantCulture);
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
        catch (FormatException)
        {
            result = default;
            return false;
        }
        catch (OverflowException)
        {
            result = default;
            return false;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        CustomConverter converter = new CustomConverter();

        if (converter.Convert("123", out int intResult))
        {
            Console.WriteLine($"Конвертировано в int: {intResult}");
        }
        else
        {
            Console.WriteLine("Ошибка конвертации в int");
        }

        if (converter.Convert("123.45", out double doubleResult))
        {
            Console.WriteLine($"Конвертировано в double: {doubleResult}");
        }
        else
        {
            Console.WriteLine("Ошибка конвертации в double");
        }

        if (converter.Convert("2024-09-16", out DateTime dateTimeResult))
        {
            Console.WriteLine($"Конвертировано в DateTime: {dateTimeResult}");
        }
        else
        {
            Console.WriteLine("Ошибка конвертации в DateTime");
        }
    }
}