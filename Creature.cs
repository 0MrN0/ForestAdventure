﻿using System;

namespace ForestAdventure
{
    public class Creature
    {
        public readonly CreatureName Name;
        public readonly CreatureOwner Owner;

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

        public bool Equals(Creature other)
        {
            return Name == other.Name && Owner == other.Owner && Hp == other.Hp && Luck == other.Luck &&
                   Defence == other.Defence && Strength == other.Strength;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Name;
                hashCode = (hashCode * 397) ^ (int) Owner;
                return hashCode;
            }
        }

        public bool IsDie => Hp <= 0;
    }
}