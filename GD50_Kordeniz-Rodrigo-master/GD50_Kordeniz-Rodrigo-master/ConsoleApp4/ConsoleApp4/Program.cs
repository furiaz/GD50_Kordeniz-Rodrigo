using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to boigeon!\nhere you take control of a good boi and you must face all evil bois");
            int iDungeonLevel = 0;
            string sPlayerInput;
            int iPlayerInput;
            PlayerClassTemp Boi;
            Console.WriteLine("\nPlease, select your class\n1 for Fat Boi,\n2 for Stabby Boi,\n3 for Wise Boi.");
            sPlayerInput = Console.ReadLine();
            iPlayerInput = PlayerNumberCheck(0, 4, sPlayerInput);
            Random rMonsterSelected = new Random();
            Console.WriteLine("\nPlease name your Boi");
            sPlayerInput = Console.ReadLine();
            int iMonsterType;
            MonsterTemplate Monster;
            if (sPlayerInput == "")
            {
                sPlayerInput = "Sir Montgomery Alexander Massachusetts Maximilian Finnegan Rasuuuuumus Hård";
            }
            //Charater Creation
            switch (iPlayerInput)
            {
                case 1:
                    {
                        Boi = new Fat_Boi(sPlayerInput);
                        break;
                    }
                case 2:
                    {
                        Boi = new Stabby_Boi(sPlayerInput);
                        break;
                    }
                case 3:
                    {
                        Boi = new Wise_Boi(sPlayerInput);
                        break;
                    }
                default:
                    {
                        Boi = new Wise_Boi(sPlayerInput);
                        break;
                    }
            }
            Console.WriteLine("\nYou are now a Boi named {0}, go get them!", Boi.Name);

            for (iDungeonLevel = 0; iDungeonLevel < 5; iDungeonLevel++)
            {
                iMonsterType = rMonsterSelected.Next(1, 4);
                Console.WriteLine("Enemy Level:{0}", iDungeonLevel+1);
                if (iMonsterType == 1)
                {
                    Monster = new Goblin();
                    Monster.MonsterHealth += (iDungeonLevel * 4);
                    Console.WriteLine("A Gob Gob Boi ({0} HP)Appears\n", Monster.MonsterHealth);
                }
                else if (iMonsterType == 2)
                {
                    Monster = new Elf();
                    Monster.MonsterHealth += (iDungeonLevel * 4);
                    Console.WriteLine("A Pointi Boi({0} HP)Appears\n", Monster.MonsterHealth);
                }
                else if (iMonsterType == 3)
                {
                    Monster = new Bat();
                    Monster.MonsterHealth += (iDungeonLevel * 4);
                    Console.WriteLine("A Fliyng Mice Boi({0} HP)Appears\n", Monster.MonsterHealth);
                }
                else
                {
                    Monster = new Goblin();
                    Monster.MonsterHealth += (iDungeonLevel * 4);
                }
                while (Monster.MonsterHealth > 0 && Boi.Health > 0)
                {
                    Boi.Health -= Monster.MonsterAttackTemp(Boi.Dodge);
                    if (Boi.Health > 0)
                    {

                        Console.WriteLine("{0} stats: {1}hp and {2}mp", Boi.Name, Boi.Health, Boi.Mana);
                        Console.WriteLine("Select Attack:\n1 for normal Attack,\n2 for Special Attack,\n3 for Special Attack 2");
                        sPlayerInput = Console.ReadLine();
                        iPlayerInput = PlayerNumberCheck(0, 4, sPlayerInput);
                        Monster.MonsterHealth -= Boi.AttackTemp(iPlayerInput, Monster.Dodge);
                        Console.WriteLine("Monster's remaining health: {0}", Monster.MonsterHealth);
                        Console.WriteLine("--------------------------------------------------------");
                    }
                    else
                    { }

                }
                if (Boi.Health > 0)
                {
                    Console.WriteLine("Moving to Next Floor");
                    Thread.Sleep(250);
                    Console.Write(".");
                    Thread.Sleep(1500);
                    Console.Write(".");
                    Thread.Sleep(2000);
                    Console.Write(".\n");
                    Boi.Health += 25;
                }


            }

            if (Boi.Health > 0)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("You Do Da Thing Ma Boi");
                Console.WriteLine("----------------------");
            }

            else
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Da Thing Killed You Ma Boi");
                Console.WriteLine("----------------------");
            }

            Console.ReadLine();






        }
        static int PlayerNumberCheck(int Min, int Max, String Input)
        {
            int Type;
            bool IsSane;
            do
            {
                IsSane = Int32.TryParse(Input, out Type);
                if (IsSane && Type > Min && Type < Max)
                {
                    //Console.WriteLine("MIT Education in It's Best");

                }

                else
                {
                    Console.WriteLine("You typed the wrong thing, try again Boi");
                    Input = Console.ReadLine();
                    IsSane = false;
                }

            } while (!IsSane);

            return Type;
        }

    }
}
