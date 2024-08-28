namespace LINQ_0;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var array = new int[100];
        for (int i = 0; i < 100; ++i)
        {
            array[i] = random.Next(0, 100);
        }

        #region BiggerThanTen //Выбрать все числа, которые больше 10 || Операторы запросов
        {
            var biggerThanTen = from n in array
                                where n > 10
                                select n;
            Print(biggerThanTen);
        } 
        #endregion
        
        #region AnyDivisibleBy5 //Проверить, есть ли в массиве хотя бы одно число, которое делится на 5. || Методы расширений
        {
            var anyDivisibleBy5 = array.Any(num => num % 5 == 0);
            Print(anyDivisibleBy5);
        }
        #endregion
        
        #region anyPositive //Проверить, есть ли хоть одно положительное число. || Методы расширений
        {
            var anyPositive = array.Any(num => num > 0);
            Print(anyPositive);
        }
        #endregion
        
        #region allPositive //Проверить, все ли числа положительные. || Методы расширений
        {
            var allPositive = array.All(num => num > 0);
            Print(allPositive);
        }
        #endregion
        
        #region combinedList //Объединить все предыдущие проверки(регионы) в один список. || Методы расширений и операторы запросов
        {
            var biggerThanTen = from n in array
                                where n > 10
                                select n;
            var divisibleBy5 = array.Where(n => n % 5 == 0);
            
            //Так как biggerThanTen более ограничивающее, чем anyPositive и allPositive - можем ими принебречь
            var result = biggerThanTen.Intersect(divisibleBy5).ToList();
            Print(result);
        }
        #endregion
    }

    private static void Print(IEnumerable<int> collection)
    {
        Console.WriteLine(string.Join(' ', collection));
    }
    
    private static void Print(bool flag)
    {
        Console.WriteLine(flag);
    }
}