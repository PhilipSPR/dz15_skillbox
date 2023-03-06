using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

async Task<int[]> sortToLow(object o)
{
    int[] mas = (int[])o;
    int perm;
    Console.WriteLine($"Начало сортировки с помощю async await");
    for (int i = 0; i < mas.Length; i++)
    {
        for (int j = 0; j < mas.Length - 1; j++)
        {
            if (mas[j] < mas[j + 1])
            {
                perm = mas[j + 1];
                mas[j + 1] = mas[j];
                mas[j] = perm;
                Thread.Sleep(250);
            }
        }
    }
    Console.WriteLine($"Конец  сортировки с помощю async await");
    
    return mas;
}
void sort(object o)
{
    Thread.CurrentThread.Name = "sort";
    Console.WriteLine($"Поток {Thread.CurrentThread.Name} начал работу");
    int[] mas = (int[])o;
    int perm;

    for (int i = 0; i < mas.Length; i++)
    {
        for (int j = 0; j < mas.Length - 1; j++)
        {
            if (mas[j] > mas[j + 1])
            {
                perm = mas[j + 1];
                mas[j + 1] = mas[j];
                mas[j] = perm;
                Thread.Sleep(50);
            }
        }
    }
    foreach (int i in mas)
    {
        Console.WriteLine($"Поток: {Thread.CurrentThread.Name} i: {i}");
    }
    Console.WriteLine($"Поток {Thread.CurrentThread.Name} закончил работу");
}

Thread.CurrentThread.Name = "Main";
Console.WriteLine($"Начало потока {Thread.CurrentThread.Name}");
int[] mas = new int[] { 1, 3, 2, 1, 3, 15, 14, 1 };
var t1 = new Task(sort, mas);
t1.Start();
Console.WriteLine($"Поток main ждёт пока отработает метод sort");
t1.Wait();
int[] x = await sortToLow(mas);
foreach (int i in x)
{
    Console.WriteLine($"Поток: {Thread.CurrentThread.Name} I: {i}");
}

Console.WriteLine($"Конец потока {Thread.CurrentThread.Name}");
