using System.Drawing;

namespace ForestAdventure
{
    public enum Boss
    {
        Gunter,
        MrTree,
        Necromancer
    }

    public class Note
    {
        public Point Location;
        public string Story;
        public Boss BossToOpen;

        public Note(Point location, string story, Boss boss)
        {
            Location = location;
            Story = story;
            BossToOpen = boss;
        }
    }
}