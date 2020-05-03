using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using ForestAdv.Domain;


namespace ForestAdventure
{
    enum MapTiles
    {
        Tree,
        Trail,
        Castle
    }
    public class Plushka
    {
        public string Value { get; set; }
        public Point Location { get; set; }
        
        public List<int> ChangeValue(List<Stats> stats, string value) //должно быть не тут
        {
              
        }
    }

    public class Stats
    {
        public string Power { get; set; }
        public string Luck { get; set; }
        public string Protection { get; set; }
    }
    

    public class Player
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public ForestFiled Filed { get; set; }
    }
    

    public class MonsterCamp
    {
        List<Creature> Monsters;
        Point Position;

        public MonsterCamp(List<Creature> monsters, Point position)
        {
            Monsters = monsters;
            Position = position;
        }
    }
    

    public class Story
    {
        // 1,2,3 - обучение
        // 4,5,6,8,9,10,12,13,15 - сюжетка
        // 7,11,14 - монстры
        private List<int> NomberPartStory;
    }
    

    public class Note
    {
        
    }

    
    public class ForestFiled
    {
        public Point[,] Map;
        public List<MonsterCamp> Monsters;
        public List<Plushka> Buffs;
        public List<Note> Notes;
    }
}