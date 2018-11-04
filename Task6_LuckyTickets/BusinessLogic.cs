// <copyright file="BusinessLogic.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task6_LuckyTickets
{
    using System;
    using System.IO;

    /// <summary>
    /// This class is for current program logic
    /// </summary>
    public class BusinessLogic
    {      
        /// <summary>
        /// Initialize the array of tickets
        /// </summary>
        /// <param name="leftrange">first ticket</param>
        /// <param name="rightRange">last ticket</param>
        /// <returns>tickets array</returns>
        public Ticket[] Initializer(int leftrange, int rightRange)
        {
            Ticket[] tickets = new Ticket[(rightRange - leftrange)];
            for (int i = leftrange; i < rightRange; i++)
            {
                tickets[i - leftrange] = new Ticket(i);
            }

            return tickets;
        }

        /// <summary>
        /// Set identifier of method depends on text file
        /// </summary>
        /// <param name="path">string with path to file</param>
        /// <returns>the identifier</returns>
        public Method SetMethod(string path)
        {
            using (StreamReader streamreader = new StreamReader(path))
            {
                string method = streamreader.ReadLine();
                string helper = method.Trim(' ');
                if (helper == null)
                {
                    Console.WriteLine("You should write the name of method in file.");
                }

                if (helper.ToLower() == "moscow")
                {
                    return Method.Moscow;
                }

                if (helper.ToLower() == "piter")
                {
                    return Method.Moscow;
                }
                else
                {
                    throw new ArgumentException("Method name is incorrect.");
                }
            }
        }

        /// <summary>
        /// Set the method depends on identifier
        /// </summary>
        /// <param name="moscow">Moscow method</param>
        /// <param name="piter">Peter method</param>
        /// <param name="luckyCount">quantity of lucky tickets</param>
        /// <param name="method">the identifier</param>
        /// <param name="tickets">tickets array</param>
        /// <returns>count of lucky tickets</returns>
        internal int MethodInitialize(Moscow moscow, Piter piter, int luckyCount, Method method, Ticket[] tickets)
        {
            switch (method)
            {
                case Method.Piter:
                    {
                        luckyCount = piter.PiterMethod(tickets);
                        break;
                    }

                case Method.Moscow:
                    {
                        luckyCount = moscow.MoscowMethod(tickets);
                        break;
                    }
            }

            return luckyCount;
        }
    }
}
