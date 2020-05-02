using System;
using System.Collections.Generic;

namespace SuperHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            people.Add(new SuperHero("Wolverine", string.Empty, "James Howlett", "Adamantium Retractable-Claws"));
            people.Add(new SuperHero("Deadpool", string.Empty, "Wade Winston Wilson", "Regenerative Healing"));
            people.Add(new SuperHero("Hulk", string.Empty, "Bruce Banner", "Rage & Size"));
            people.Add(new Villain("Magneto", string.Empty, "Professor X"));
            people.Add(new Villain("Venom", string.Empty, "Spider Man"));
            people.Add(new Villain("Bane", string.Empty, "Batman"));
            people.Add(new Person("Bruce Wayne", "Batman"));
            people.Add(new Person("Tony Stark", "Iron Man"));
            people.Add(new Person("Clint Barton", "Hawkeye"));


            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}: {person.PrintGreeting()}");
            }
            Console.ReadKey();

        }

        

        class Person
        {
            public string Name { get; set; }
            public string NickName { get; set; }
            public Person(string name, string nickname)
            {
                Name = name;
                NickName = nickname;
            }

            /*public override string ToString()
            {
                return Name;
            }*/

            public virtual string PrintGreeting()
            {
                return $"Hi, my name is {Name}, but people call me {NickName} i'm just an ordinary person in a world of superheroes and villains.";
            }
        }

        class SuperHero : Person
        {
            public string SuperPower { get; set; }
            public string RealName { get; set; }
            public SuperHero(string name, string nickname, string realname, string superpower) : base(name, nickname)
            {
                RealName = realname;
                SuperPower = superpower;
            }

            public override string PrintGreeting()
            {
                return $"I am {RealName}. When I am {Name} my superpower is {SuperPower}";
            }
        }

        class Villain : Person
        {
            public string Nemesis { get; set; }
            public Villain(string name, string nickname, string nemesis) : base(name, nickname)
            {
                Nemesis = nemesis;
            }

            public override string PrintGreeting()
            {
                return $"I am {Name}. Have you seen {Nemesis}";
            }
        }
    }
}
