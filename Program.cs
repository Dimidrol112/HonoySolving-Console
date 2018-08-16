using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonoySolving
{
    class Program
    {
        public static Tower[] towers;
        public static int count;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter ring count.");
            count = int.Parse(Console.ReadLine());
            towers = new Tower[count];
            InitTowers();
            Render();
            MoveStack(count, 0, 2);
            Console.ReadKey(true);
        }

        public static void InitTowers()
        {
            for (int i = 0; i < towers.Length; i++)
            {
                towers[i] = new Tower();
            }

            for (int i = 0; i < count; i++)
            {
                towers[0].rings.Add(count - i);
            }
        }

        public static int thirdAxe(int from, int to)
        {
            int result = 0;
            switch (from)
            {
                case 0:
                    if (to == 1) { result = 2; } else { result = 1; }
                    break;
                case 1:
                    if (to == 2) { result = 0; } else { result = 2; }
                    break;
                case 2:
                    if (to == 0) { result = 1; } else { result = 0; }
                    break;
            }
            return result;
        }

        public static void MoveStack(int size, int from, int to)
        {
            if (size <= 0)
                return;

            int third = thirdAxe(from, to);

            MoveStack(size - 1, from, third);

            towers[from].MoveRing(towers[to]);
            Render();

            MoveStack(size - 1, third, to);
        }



        public static void Render()
        {
            Console.WriteLine("----------------");
            foreach (var tow in towers)
            {
                foreach (var ring in tow.rings)
                {
                    Console.Write(ring + "  ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Tower
    {
        public List<int> rings = new List<int>();

        public void MoveRing(Tower tow)
        {
            tow.rings.Add(rings[rings.Count - 1]);
            rings.RemoveAt(rings.Count - 1);
        }
    }
}
