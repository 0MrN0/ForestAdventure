﻿using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine
            (@"-'start' to start
- 'exit' to exit");
            var args = Console.ReadLine();
            if (args != "start")
            {
                Console.WriteLine(":c");
            }
            else
            {
                StartGame();
            }
        }

        static void StartGame()
        {
            var game = new Game();
            game.InitForestField();
            var dx = 0;
            var dy = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hero is in " + game.Forest.Hero.Location);
                Console.WriteLine("Game: " + game.State);
                Console.WriteLine("exit to exit, stats to get stats");
                Console.WriteLine("up, down, left or right to try move");
                dx = 0;
                dy = 0;

                var str = Console.ReadLine();
                if (str == "exit")
                {
                    Console.WriteLine("GameOver");
                    break;
                }
                else if (str == "stats")
                {
                    game.GetStats();
                    Console.WriteLine("Press key to continue");
                    Console.ReadKey();
                    continue;
                }
                else if (str == "up")
                    dy = -1;
                else if (str == "down")
                    dy = 1;
                else if (str == "left")
                    dx = -1;
                else if (str == "right")
                    dx = 1;
                else
                {
                    Console.WriteLine("i dont understand");
                    Console.WriteLine("Press key to continue");
                    Console.ReadKey();
                    continue;
                }
                game.Forest.MoveTo(dx, dy);

                if (game.Forest.IsNote())
                {
                    var note = game.Forest.GetNoteFromLocation();
                    Console.WriteLine("You found a note");
                    Console.WriteLine(note.Story);
                    Console.WriteLine("Press key to continue");
                    Console.ReadKey();
                    game.Forest.ReadNote();
                    continue;
                }

                if (game.Forest.IsCarrot())
                {
                    var carrot = game.Forest.GetCarrotFromLocation();
                    Console.WriteLine("Your friends ate a holy carrot");
                    Console.WriteLine("All your friends incremented their " + carrot.Attribute);
                    Console.WriteLine("Press key to continue");
                    Console.ReadKey();
                    game.Forest.EatCarrot();
                    continue;
                }

                if (game.Forest.IsMonster())
                {
                    Console.WriteLine("Panic! Monsters!!!");
                    game.InitBattle();
                    var queue = game.Battle.GetQueue();
                    while (!game.Battle.IsEndBattle())
                    {
                        Console.Clear();
                        Console.WriteLine("Game: " + game.State);
                        game.Battle.ShowHp();
                        var curCreat = queue.Dequeue();
                        if (curCreat.IsDie)
                            continue;
                        
                        Console.WriteLine("Now " + curCreat.Name + "'s turn");

                        if (curCreat.Owner == CreatureOwner.Computer)
                        {
                            var target = game.Battle.ChooseTarget(game.Battle.PlayerTeam);
                            curCreat.Hit(target);
                            Console.WriteLine(curCreat.Name + " hit " + target.Name);
                            Console.WriteLine("Press key to continue");
                            Console.ReadKey();
                        }
                        else
                        {
                            var target = game.Battle.ChooseTarget(game.Battle.ComputerTeam);
                            curCreat.Hit(target);
                            Console.WriteLine(curCreat.Name + " hit " + target.Name);
                            Console.WriteLine("Press key to continue");
                            Console.ReadKey();
                        }

                        queue.Enqueue(curCreat);
                    }
                }
                game.CheckHero();
                game.CheckMonsters();
                if (game.State == GameState.HeroDie)
                {
                    Console.WriteLine("You're lose");
                    break;
                }
                else
                {
                    game.Forest.RemoveCurrentMonsterCamp();
                }

                if (game.State == GameState.MonstersDie)
                {
                    Console.WriteLine("You're win!)");
                    break;
                }
            }
        }
    }
}