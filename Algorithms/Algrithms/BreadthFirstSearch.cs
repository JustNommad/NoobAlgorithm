using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Algrithms
{
    class Person
    {
        public string Name { get; set; }
        public List<string> FriendList = new List<string>();
        public bool Status = false;
        public bool Checked = false;

        public Person (string name, bool status, List<string> friendlist)
        {
            Name = name;
            Status = status;
            FriendList = friendlist;
        }
    }
    class BreadthFirstSearch
    {
        Dictionary<string, Person> friendsHashTable;
        Queue<string> queue = new Queue<string>();
        Person Me;
        public BreadthFirstSearch()
        {
            Me = new Person("Максим", false, new List<string> { "Арсений", "Егор", "Паша" });
            queue.Enqueue(Me.Name);

            friendsHashTable = new Dictionary<string, Person>
            {
                {"Максим", Me },
                {"Арсений", new Person("Арсений", false, new List<string>{"Эдик", "Валера" }) },
                {"Егор", new Person("Егор", false, new List<string>{"Гоша", "Алексей", "Виктор" }) },
                {"Паша", new Person("Паша", false, new List<string>{"Женя", "Леха", "Маша" }) },

                {"Эдик", new Person("Эдик", false, new List<string>{"Валера"}) },
                {"Валера", new Person("Валера", false, null) },
                {"Гоша", new Person("Гоша", false, null) },
                {"Алексей", new Person("Алексей", false, new List<string>{"Паша"}) },
                {"Виктор", new Person("Виктор", true, null) },
                {"Женя", new Person("Женя", false, null) },
                {"Леха", new Person("Леха", false, null) },
                {"Маша", new Person("Маша", false, null) }
            };
        }

        public string Search()
        {
            Queue<string> tempQ = new Queue<string>();

            while(queue.Count != 0)
            {
                string pName = queue.Dequeue();
                Person person = friendsHashTable[pName];

                if(person.Checked == false)
                {
                    if (person.Status == true)
                    {
                        return $"Это {person.Name}";
                    }
                    person.Checked = true;
                    if(person.FriendList != null)
                    {
                        foreach (var f in person.FriendList)
                        {
                            tempQ.Enqueue(f);
                        }
                    }
                }
            }
            queue = tempQ;
            if(queue.Count == 0)
            {
                return "Ничего не найдено";
            }
            return Search();
        }
    }
}
