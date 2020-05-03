using System;

namespace ForestAdv.Domain
{
    public class Creature
    {
        public int Hp;
        public int Luck;
        public int Strength;
        public int Defence;

        public Creature(int hp, int luck, int defence, int strength)
        {
            Hp = hp;
            Luck = luck;
            Defence = defence;
            Strength = strength;
        }

        public void Hit(Creature target) => target.Hp -= Strength - target.Defence + new Random().Next(0, Luck);

        public bool IsDie() => Hp <= 0;
    }
}
//               хп		лак		деф		тычка
// Эльф:		350		50		15		75
// Кролик:		450		40		35		50
// Енот:		100		100		0		100
// Кошак:		666		0		50		0
//
// Пингвин:	    250		30		25		40
// Слайм:		200		70		10		30
// Скелет:		150		30		0		70
//
// Гюнтер:		500		50		10		50
// ДеРеВо:		1000	10		50		10
// Некромант:	750		75		20		75