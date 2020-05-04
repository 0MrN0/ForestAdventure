﻿using System;

namespace ConsoleApp1
{
    public enum CreatureName
    {
        Elf,
        Rabbit,
        Raccoon,
        LittleCat,
        
        Gunter,
        MrTree,
        Necromancer,
        
        Penguin,
        Slime,
        Skeleton
    }

    public enum CreatureOwner
    {
        Human,
        Computer
    }

    public class Creature
    {
        public CreatureName Name;
        public CreatureOwner Owner;
        
        public int Hp;
        public int Luck;
        public int Defence;
        public int Strength;
        
        public Creature(CreatureOwner owner, CreatureName name, int hp, int luck, int defence, int strength)
        {
            Owner = owner;
            Name = name;
            Hp = hp;
            Luck = luck;
            Defence = defence;
            Strength = strength;
        }

        public Creature(Creature clone)
        {
            Owner = clone.Owner;
            Name = clone.Name;
            Hp = clone.Hp;
            Luck = clone.Luck;
            Defence = clone.Defence;
            Strength = clone.Strength;
        }

        public void Hit(Creature target)
        {
            var randomValue = new Random().Next(0, Luck);
            target.Hp = target.Hp - Strength + target.Defence - randomValue <= 0
                ? 0
                : target.Hp - Strength + target.Defence - randomValue;
        }

        public bool IsDie => Hp <= 0;
    }
}