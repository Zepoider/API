using System;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver<string> str = new Driver<string>();
            
            str.Add(new Cell<string>("fox"));
            str.Add(new Cell<string>("lion"));
            str.Add(new Cell<string>("duck"));
            str.Add(new Cell<string>("rabbit"));
            str.Add(new Cell<string>("elephant"));
            str.Add(new Cell<string>("dog"));
            str.Add(new Cell<string>("fog"));
            str.Add(new Cell<string>("frog"));
            str.Add(new Cell<string>("snake"));
            str.Add(new Cell<string>("alliigator"));
            str.Add(new Cell<string>("fish"));
            str.Add(new Cell<string>("12 monkey"));
            str.Add(new Cell<string>("Monkey"));
            str.Add(new Cell<string>("7"));
            str.Add(new Cell<string>("dick"));



            str.Sort();

            for (int i = 0; i < str.lenth; i++)
            {
                Console.WriteLine(str.GetByIndex(i).data);
            }

            Console.ReadKey();
        }
    }
}
