﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine
            ("-'start' to start \n-'exit' to exit");
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
            while (true)
            {
                Console.WriteLine("Hero is in " + game.Forest.Hero.Location);
                Console.WriteLine("Game: " + game.State);
                Console.WriteLine("'X Y' to move (X, Y)");
                var str = Console.ReadLine();
                if (str == "exit") break;
                if (str == "stats") game.GetStats();
                var args = str?.Split(' ');
                if (args?.Length != 2 
                    || !int.TryParse(args[0], out var x)
                    || !int.TryParse(args[1], out var y)) continue;
                
                game.Forest.MoveTo(new Point(x, y));
                if (game.Forest.IsCarrot())
                {
                    var carrot = game.Forest.GetCarrotFromLocation();
                    Console.WriteLine("Your friends ate a holy carrot");
                    Console.WriteLine("All your friends incremented their " + carrot.Attribute);
                    game.Forest.EatCarrot();
                }

                if (game.Forest.IsFight())
                {
                    Console.WriteLine("Panic! Monsters!!!");
                    game.InitBattle();
                    var queue = game.Battle.GetQueue();
                    while (!game.Battle.IsEndBattle())
                    {
                        Console.WriteLine();
                        game.Battle.ShowHp();
                        var curCreat = queue.Dequeue();
                        if (curCreat.IsDie)
                            continue;
                        Console.WriteLine("Now " + curCreat.Name + "'s turn");
                        if (curCreat.Owner == CreatureOwner.Computer)
                        {
                            var target = game.Battle.ChooseTarget(game.Battle.PlayerTeam);
                            curCreat.Hit(target);
                        }
                        else
                        {
                            Console.WriteLine("Choose target: 0, 1, 2?");
                            if (!int.TryParse(Console.ReadLine(), out var i))
                            {
                                Console.WriteLine("Okay, you passed your turn");
                                if (i < 0 || i > 3)
                                    Console.WriteLine("Okay, you passed your turn");
                            }
                            else
                            {
                                var target = game.Battle.ComputerTeam[i];
                                curCreat.Hit(target);
                            }
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

                Console.WriteLine();
                Console.WriteLine(game.Forest.Monsters.Count);
                
                Console.WriteLine();
                Console.WriteLine();
                
            }
        }
    }
}