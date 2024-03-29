﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            List<Soldier> soldiers1 = new List<Soldier>();
            List<Soldier> soldiers2 = new List<Soldier>();
            string wordStart = "Б";
            
            AddRandomSoldiers(soldiers1);
            AddRandomSoldiers(soldiers2);
            
            CombineSoldiers(ref soldiers1, ref soldiers2, wordStart);
            
            ShowSoldiers(soldiers2);
        }

        static void CombineSoldiers(ref List<Soldier> soldiers1, ref List<Soldier> soldiers2, string wordStart)
        {
            var filteredSoldier = soldiers1.Where(soldier => 
                soldier.Name.ToUpper().StartsWith(wordStart));
            
            soldiers2 = soldiers2.Union(filteredSoldier).ToList();
            
            soldiers1 = soldiers1.Except(filteredSoldier).ToList();
        }
        
        static void AddRandomSoldiers(List<Soldier> soldiers)
        {
            Random random = new Random();

            List<string> names = new List<string>
            {
                "name1",
                "name2",
                "бname3",
                "name4",
                "name5",
                "бname6",
                "name7",
                "Бname8",
                "Бname9",
                "name10"
            };
            
            List<string> armaments = new List<string>
            {
                "armament1",
                "armament2",
                "armament3",
                "armament4",
                "armament5",
            };
            
            List<string> ranks = new List<string>
            {
                "rank1",
                "rank2",
                "rank3",
                "rank4",
                "rank5"
            };

            int minServiceLife = 12;
            int maxServiceLife = 24;
            
            for (int i = 0; i < names.Count; i++)
            {
                soldiers.Add(new Soldier(names[i], armaments[random.Next(armaments.Count)],
                    ranks[random.Next(ranks.Count)], random.Next(minServiceLife, maxServiceLife)));
            }
        }
                    
        static void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (Soldier soldier in soldiers)
            {
                Console.WriteLine($"Имя - {soldier.Name} Вооружение - {soldier.Armament} Звание - {soldier.Rank} " +
                                  $"Срок службы - {soldier.ServiceLife}");
            }
        }
                    
        class Soldier
        {
            public string Name { get; private set; }
            public string Armament { get; private set; }
            public string Rank { get; private set; }
            public int ServiceLife { get; private set; }

            public Soldier(string name, string armament, string rank, int serviceLife)
            {
                Name = name;
                Armament = armament;
                Rank = rank;
                ServiceLife = serviceLife;
            }
        }
    }
}