// <copyright file="Piter.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task6_LuckyTickets
{
    /// <summary>
    /// For working with Peter's method
    /// </summary>
    internal class Piter
    {
        /// <summary>
        /// Get how much lucky tickets in array
        /// </summary>
        /// <param name="tickets">tickets array</param>
        /// <returns>quantity of lucky tickets</returns>
        public int PiterMethod(Ticket[] tickets)
        {
            int firstThree = 0;
            int secondThree = 0;
            int count = 0;
            foreach (var ticket in tickets)
            {
                string helper = string.Format("{0:000000}", ticket.Number);
                firstThree = int.Parse(helper[0].ToString()) + int.Parse(helper[2].ToString()) + int.Parse(helper[4].ToString());
                secondThree = int.Parse(helper[1].ToString()) + int.Parse(helper[3].ToString()) + int.Parse(helper[5].ToString());
                if (firstThree == secondThree)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
