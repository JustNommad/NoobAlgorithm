using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Algrithms
{
    class Point : IComparable<Point>
    {
        public string Name { get; private set; }
        public List<Edge> edges = new List<Edge>();
        public bool Checked = false;
        public int Size = 0;
        public Point parent;

        public Point() { }
        public Point(string name) => Name = name;
        public int CompareTo(Point o)
        {
            return this.Size.CompareTo(o.Size);
        }
    }
    class Edge
    {
        public Point startPoint;
        public Point endPoint;
        public int Size;

        public Edge(Point start, Point end, int size)
        {
            startPoint = start;
            endPoint = end;
            Size = size;
        }
    }
    class DijkstrasAlgorithm
    {
        Point start, end;
        List<Point> p = new List<Point>();
        List<Point> pointList;
        public DijkstrasAlgorithm()
        {
            start = new Point("Книга");
            end = new Point("Пианино");

            pointList = new List<Point>
            {
                start,
                new Point("Пластинка"),
                new Point("Постер"),
                new Point("Басгитара"),
                new Point("Барабан"),
                end
            };

            SwapPoints(pointList[0], pointList[1], 5);
            SwapPoints(pointList[0], pointList[2], 0);
            SwapPoints(pointList[1], pointList[3], 15);
            SwapPoints(pointList[1], pointList[4], 20);
            SwapPoints(pointList[2], pointList[3], 30);
            SwapPoints(pointList[2], pointList[4], 35);
            SwapPoints(pointList[3], pointList[5], 20);
            SwapPoints(pointList[4], pointList[5], 10);
        }

        public void AlgorithmRun()
        {
            string s = "Пианино";
            List<string> answer = new List<string>();
            Point temp = SearchingProcess(s);

            if(temp != null)
            {
                int a = temp.Size;
                while(temp != start)
                {
                    answer.Add(temp.Name);
                    temp = temp.parent;
                }
                Console.Write($"Путь: {start.Name} -> ");
                for(int i = answer.Count - 1; i >= 0; i--)
                {
                    Console.Write($"{answer[i]}");
                    if(i != 0)
                    {
                        Console.Write(" -> ");
                    }
                }
                Console.WriteLine($"\nДлинна: {a}");
            }
            else
            {
                Console.WriteLine("Искомого в списке нет!");
            }

        }

        public Point SearchingProcess(string f, Point next = null)
        {
            Point s;
            if (next == null)
                s = start;
            else
            {
                if (next.Name == f)
                {
                    return next;
                }
                s = next;
                p.RemoveAt(0);
            }
            foreach (var e in s.edges)
            {
                Point temp = e.endPoint;
                if(temp.Size == 0 || temp.Size > s.Size + e.Size)
                {
                    temp.Size = s.Size + e.Size;
                    temp.parent = s;
                }
                p.Add(temp);
            }
            p.Sort();
            if(p.Count == 0)
            {
                return null;
            }
            return SearchingProcess(f, p[0]);
        }

        public void PrintEdges()
        {
            foreach(var p in pointList)
            {
                Console.WriteLine($"{p.Name}: ");
                if(p.edges.Count == 0)
                {
                    Console.WriteLine("Нет связей");
                }
                foreach (var e in p.edges)
                {
                    Console.WriteLine($"{e.startPoint.Name} -> {e.endPoint.Name}: {e.Size}");
                }
                Console.WriteLine();
            }
        }

        public void SwapPoints(Point frist, Point second, int size)
        {
            Point f = frist;
            Point s = second;

            Edge edge = new Edge(f, s, size);
            f.edges.Add(edge);
        }
    }
}
