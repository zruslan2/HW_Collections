using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания(1-7)");
            int ch = int.Parse(Console.ReadLine());
            if (ch == 1)
            {
                Console.WriteLine("1. Создать коллекцию List <int> . Вывести на экран позицию и значение элемента, являющегося вторым максимальным значением в коллекции. Вывести на экран сумму элементов на четных позициях.");
                List<int> num = new List<int> { 5, 4, 1, 3, 8, 10 };
                num.Add(12);
                for (int i = 0; i < num.Count; i++)
                {
                    Console.Write(num[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
                num.Sort();
                num.Reverse();
                for (int i = 0; i < num.Count; i++)
                {
                    Console.Write(num[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
                Console.WriteLine("Второе максимальное значение: ");
                Console.WriteLine(num[1]);
                Console.WriteLine("\n");
                int sum = 0;
                for (int i = 0; i < num.Count; i++)
                {
                    if (num[i] % 2 == 0)
                    {
                        Console.Write(num[i]);
                        Console.Write(" ");
                        sum += num[i];
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("Сумма элементов на четных позициях");
                Console.WriteLine(sum);
            }
            else if (ch == 2)
            {
                Console.WriteLine("2. Удалить все нечетные элементы списка List<int>");
                List<int> num = new List<int> { 5, 4, 1, 3, 8, 10 };
                for (int i = 0; i < num.Count; i++)
                {
                    Console.Write(num[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("\n");
                num.RemoveAll(i => i % 2 != 0);
                Console.WriteLine("\n");
                for (int i = 0; i < num.Count; i++)
                {
                    Console.Write(num[i]);
                    Console.Write(" ");
                }
            }
            else if (ch == 3)
            {
                Console.WriteLine("3. Дана коллекция типа List<double>. Вывести на экран элементы списка, значение которых больше среднего арифметического всех элементов коллекции.");
                List<double> num = new List<double> { 5.2, 4.5, 1.6, 3.8, 8.4, 10.5 };
                for (int i = 0; i < num.Count; i++)
                {
                    Console.Write(num[i]);
                    Console.Write(" ; ");
                }
                double sum = 0;
                for (int i = 0; i < num.Count; i++)
                {
                    sum += num[i];
                }
                Console.WriteLine("\n");
                Console.WriteLine("Sum: {0}\nAverage: {1}", sum, sum / num.Count);
                Console.WriteLine("\nЭлементы больше среднего арифметического всех элементов коллекции");
                for (int i = 0; i < num.Count; i++)
                {
                    if (num[i] > (sum / num.Count))
                    {
                        Console.Write(num[i]);
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("\n");
            }
            else if (ch == 4)
            {
                Console.WriteLine("4. Напечатать содержимое текстового файла t, выписывая литеры каждой его строки в обратном порядке.");
                var f = File.ReadAllLines("t.txt");
                foreach (var s in f)
                {
                    var stack = new Stack();
                    foreach (var c in s)
                        stack.Push(c);
                    var count = stack.Count;
                    for (var i = 0; i < count; i++)
                        Console.Write(stack.Pop());
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            else if (ch == 5)
            {
                Console.WriteLine("5. Даны 2 строки s1 и s2. Из каждой можно читать по одному символу. Выяснить, является ли строка s2 обратной s1.");
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                Console.WriteLine(s1 == new string(s2.Reverse().ToArray()) ? "Строка s2 является обратной строке s1" : "Строка s2 не является обратной строке s1");
            }
            else if (ch == 6)
            {
                Console.WriteLine("6. Дан текстовый файл. За один просмотр файла напечатать элементы файла в следующем порядке: сначала все слова, начинающиеся на гласную букву, потом все слова, начинающиеся на согласную букву, сохраняя исходный порядок в каждой группе слов.");
                var text = File.ReadAllText("1.txt");
                Queue<char> digits = new Queue<char>();
                Queue<char> other = new Queue<char>();
                foreach (char i in text)
                {
                    if (char.IsDigit(i))
                    {
                        digits.Enqueue(i);
                    }
                    else
                    {
                        other.Enqueue(i);
                    }
                }
                while (other.Count > 0)
                {
                    Console.Write(other.Dequeue());
                }

                while (digits.Count > 0)
                {
                    Console.Write(digits.Dequeue());
                }
            }
            else if (ch == 7)
            {
                Console.WriteLine("7.	Дан файл, содержащий числа. За один просмотр файла напечатать элементы файла в следующем порядке: сначала все положительные числа, потом все отрицательные числа, сохраняя исходный порядок в каждой группе чисел.");
                Queue<int> positive = new Queue<int>();
                Queue<int> negative = new Queue<int>();
                StreamReader sr = new StreamReader("numbers.txt");
                string[] numbers = sr.ReadToEnd().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < numbers.Length; i++)
                {
                    int result = 0;
                    if (int.TryParse(numbers[i], out result))
                    {
                        if (result > 0)
                            positive.Enqueue(result);
                        if (result < 0)
                            negative.Enqueue(result);
                    }
                }
                Console.Write("Положительные числа: ");
                foreach (int num in positive)
                {
                    Console.Write("{0} ", num);
                }
                Console.Write("\nОтрицательные числа: ");
                foreach (int num in negative)
                {
                    Console.Write("{0} ", num);
                }
                Console.WriteLine();
            }
        }
    }
}
