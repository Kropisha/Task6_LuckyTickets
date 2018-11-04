// <copyright file="UI.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task6_LuckyTickets
{
    using System;
    using System.IO;
    using ShowMenuLib;

    /// <summary>
    /// Present visualization for user
    /// </summary>
    internal class UI : GetMenu
    {
        /// <summary>
        /// default start ticket
        /// </summary>
        private const int DEFAULT_MIN = 000001;

        /// <summary>
        /// default end ticket
        /// </summary>
        private const int DEFAULT_MAX = 100000;

        /// <summary>
        /// Show menu for board task
        /// </summary>
        /// <param name="type">The header-line of menu</param>
        /// <returns>user choice</returns>
        public override char ShowMenu(string type)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(type);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("           1.Help                 ");
            Console.WriteLine("           2.Do it                ");
            Console.WriteLine("           3.Quit                 ");
            Console.WriteLine();
            Console.WriteLine(" What is your choice? [tap number]");

            return Console.ReadKey().KeyChar;
        }

        /// <summary>
        /// Show logic depending on the choice
        /// </summary>
        /// <param name="i">position of user choice(from top)</param>
        public override void UserChoice(int i)
        {
            UserAction action;
            do
            {
                Console.SetCursorPosition(0, 0);
                Enum.TryParse(this.ShowMenu(" Welcome to the lucky tickets task!").ToString(), out action);
                Console.WriteLine();
                Console.ResetColor();

                switch (action)
                {
                    case UserAction.Help:
                        Help helper = new Help();
                        try
                        {
                            Console.ResetColor();
                            Console.WriteLine(helper.References(@"..\..\Files\TicketRef.txt"));
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine("Some problem with file" + ex.Message);
                        }

                        Console.ReadKey();
                        break;
                    case UserAction.Program:
                        Console.ResetColor();
                        this.GetTaskMenu();
                        break;
                    case UserAction.Quit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
            while (action != UserAction.Quit);
        }

        /// <summary>
        /// Set the path for file with identifier
        /// </summary>
        /// <param name="isOk">is file correct</param>
        /// <returns>string with path</returns>
        private string PathInitializer(bool isOk)
        {
            string path = string.Empty;
            try
            {
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    isOk = false;
                    throw new FileNotFoundException("The path to file is incorrect.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return path;
        }

        /// <summary>
        /// Get menu for current task 
        /// </summary>
        private void GetTaskMenu()
        {
            Moscow moscow = new Moscow();
            Piter piter = new Piter();
            BusinessLogic bl = new BusinessLogic();
            Ticket ticket = new Ticket(DEFAULT_MIN);
            int luckyCount = 0;
            int leftrange = DEFAULT_MIN;
            int rightRange = DEFAULT_MAX;
            bool isOk = true;
            Console.WriteLine("Please, write the path to file, which contained method name.");
            Console.WriteLine("Example: ../../Files/Moscow.txt");
            string path = this.PathInitializer(isOk);
            Method method;
            method = bl.SetMethod(path);

            try
            {
                Console.WriteLine("Enter the number of ticket from which we start:");
                leftrange = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of ticket which will the last:");
                rightRange = int.Parse(Console.ReadLine());
                if (leftrange <= 0)
                {
                    isOk = false;
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentOutOfRangeException("First ticket shouldn't be less than 1.");
                }

                if (rightRange >= 999999)
                {
                    isOk = false;
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new ArgumentOutOfRangeException("Last ticket should be less than 999999");
                }
            }
            catch (FormatException ex)
            {
                isOk = false;
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You should write a natural number." + ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (isOk)
            {
                Ticket[] tickets = bl.Initializer(leftrange, rightRange);
                luckyCount = bl.MethodInitialize(moscow, piter, luckyCount, method, tickets);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"You have {luckyCount} lucky tickets.");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}
