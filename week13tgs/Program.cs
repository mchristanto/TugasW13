using System;
using System.Linq;
using System.Collections.Generic;
namespace praktikumW12
{
    class MainClass
    {
        public static void Main()
        {
            var mauApa = 0;
            var counter = 0;
            var addScroll = 0;
            var queuePosition = 0;
            var searchScroll = 0;

            List<string> newScroll = new List<string>();
            List<string> scrolls = new List<string>() { "Book of Peace", "Scroll of Swords", "Silence Guide Book" };
            while (true)
            {
                Console.Write("1. My Scroll List\n2. Add Scroll\n3. Search Scroll\n4. Remove Scroll\nChoose what to do : ");
                mauApa = Convert.ToInt16(Console.ReadLine());
                if (mauApa == 1)
                {
                    Console.Clear();
                    counter = 0;
                    Console.WriteLine("Scroll to learn list : ");
                    foreach (var scroll in scrolls)
                    {
                        counter++;
                        Console.WriteLine($"Scroll {counter} : {scroll}");
                    }
                    Console.WriteLine();                   
                }
                else if (mauApa == 2)
                {
                    Console.Write("How many scroll to add : ");
                    addScroll = Convert.ToInt16(Console.ReadLine());
                    Console.Write("In what number of Queue : ");
                    queuePosition = Convert.ToInt16(Console.ReadLine());
                    for (int i = 0; i < addScroll; i++)
                    {
                        Console.WriteLine($"Scroll {i + 1} Name : ");
                        newScroll.Add(Console.ReadLine());
                    }
                    if (queuePosition < 1)
                    {
                        queuePosition = 0;
                    }
                    else if (queuePosition > scrolls.Count())
                    {
                        queuePosition = scrolls.Count();
                    }
                    counter = -1;
                    foreach (var scroll in newScroll)
                    {
                        scrolls.Insert(queuePosition + counter, scroll);
                        counter++;
                    }
                    newScroll.Clear();
                }
                else if (mauApa == 3)
                {                    
                    Console.Write("Insert scroll name : ");
                    string name = Console.ReadLine();             
                    foreach (var scroll in scrolls)
                    {
                        if (name.ToLower() == scroll.ToLower())
                        {
                            Console.WriteLine($"Book found. Queue number : {scrolls.IndexOf(scroll) + 1}");
                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        Console.WriteLine("Book not found");
                    }
                    Console.WriteLine();
                }
                else if (mauApa == 4)
                {
                    Console.Write("Remove from list by scroll name? Y/N  ");
                    string remove = Console.ReadLine().ToLower();
                    if (remove == "y" || remove == "Y")
                    {
                        Console.Write($"Input scroll name : ");
                        string scrollName = Console.ReadLine().ToLower();
                        if (scrolls.Contains(scrollName
                            , StringComparer.OrdinalIgnoreCase))
                        {
                            scrolls.RemoveAll(n => n.Equals(scrollName, StringComparison.OrdinalIgnoreCase));
                            Console.WriteLine("Book Removed!");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Book not found");
                        }
                    }
                    else if (remove == "n" || remove == "N")
                    {
                        Console.Write($"Input scroll queue: ");
                        int removeName = Convert.ToInt32(Console.ReadLine());
                        while (removeName <= 0)
                        {
                            Console.Write("Queue not found. Insert scroll queue : ");
                            removeName = Convert.ToInt32(Console.ReadLine());
                        }
                        while (removeName > scrolls.Count)
                        {
                            Console.Write("Queue not found. Insert scroll queue : ");
                            removeName = Convert.ToInt32(Console.ReadLine());
                            counter++;
                        }
                        if (removeName <= scrolls.Count)
                        {
                            while (removeName <= 0)
                            {
                                Console.Write("Queue not found. Insert scroll queue : ");
                                removeName = Convert.ToInt32(Console.ReadLine());
                            }
                            scrolls.RemoveAt(queuePosition);
                            Console.Write("Book Removed!");                           
                        }                       
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Wrong selection. Choose again: ");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
