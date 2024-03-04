using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //берём выборку рандомных чисел в том количестве, котором мы хотим
        Console.Write("Введите число, обозначающее количество элементов: ");
        int rnd = Convert.ToInt32(Console.ReadLine());

        //наполняем массив
        Random random = new Random();
        int[] array = new int[rnd];
        for (int i = 0; i < rnd; i++)
        {
            array[i] = random.Next(100);
        }

        //вывод исходного массива
        PrintArray(array);

        //int[] array = Enumerable.Range(0, rnd).Select(i => random.Next(0, 2500000)).ToArray();
        //Console.WriteLine("Исходный массив: " + string.Join(", ", array));

        //инициализация таймера
        Stopwatch stopwatch = new Stopwatch();

        //работа сортировки пузырьком 
        int[] bubbleArray = (int[])array.Clone(); //копируем наш исходный массив
        stopwatch.Start();
        int bubbleSortSwaps = BubbleSort(bubbleArray);
        stopwatch.Stop();
        Console.Write("Сортировка пузырьком: ");
        PrintArray(bubbleArray);
        Console.WriteLine("Количество перестановок: " + bubbleSortSwaps + ". Время выполнения: " + stopwatch.Elapsed);
        stopwatch.Reset();

        //работа сортировки расчёской
        int[] combArray = (int[])array.Clone();
        stopwatch.Start();
        int combSortSwaps = CombSort(combArray);
        stopwatch.Stop();
        Console.Write("Сортировка расчёской: ");
        PrintArray(combArray);
        Console.WriteLine("Количество перестановок: " + combSortSwaps + ". Время выполнения: " + stopwatch.Elapsed);
    }

    //сортировка "пузырьком"
    static int BubbleSort(int[] array)
    {
        int swapCount = 0; //количество перестановок
        
        //перебираем массив n-1 раз
        for (int i = 0; i < array.Length; i++)
        {
            //перебираем массив от i до n-2
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    //меняем элементы местами
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapCount++;
                    //PrintArray(array);
                }
            }
        }
        return swapCount;
    }

    //сортировка расчёской
    static int CombSort(int[] array)
    {
        double gap = array.Length; //задаём шаг 
        bool swapped = true; //меняем, если перестановка сделана
        int swapCount = 0; //номер перестановки

        while (gap > 1 || swapped)
        {
            gap /= 1.247;

            if (gap < 1)
                gap = 1;

            int i = 0; //индекс первого элемента
            swapped = false; //меняем флаг на противоположный, т.е. перезапускаем

            while (i + gap < array.Length)
            {
                int igap = i + (int)gap;

                //проверяем, если нынешний элемент больше, чем следующий
                if (array[i] > array[igap])
                {
                    int temp = array[i];
                    array[i] = array[igap];
                    array[igap] = temp;
                    swapped = true;
                    swapCount++;
                    //PrintArray(array);
                }

                ++i;
            }
        }
        return swapCount;
    }

    static void PrintArray(int[] array) {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}