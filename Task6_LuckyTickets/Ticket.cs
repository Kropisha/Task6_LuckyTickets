// <copyright file="Ticket.cs" company="My Company">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace Task6_LuckyTickets
{
    using System;

    /// <summary>
    /// This class is for ticket instance
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// arrays of ticket
        /// </summary>
        private Ticket[] tickets;

        /// <summary>
        /// number of ticket
        /// </summary>
        private int number;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class
        /// </summary>
        /// <param name="currentNumber">ticket's number</param>
        public Ticket(int currentNumber)
        {
            this.Number = currentNumber;
        }

        /// <summary>
        /// Gets or sets number of current ticket
        /// </summary>
        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        /// <summary>
        /// Get current ticket of array
        /// </summary>
        /// <param name="values">the array of tickets</param>
        /// <returns>current ticket of array</returns>
        public Ticket this[int[] values]
        {
            get
            {
                foreach (var value in values)
                {
                    if (value > 0 && value < 999999)
                    {
                        return this.tickets[value];
                    }
                }

                throw new IndexOutOfRangeException("The number of ticket is not correct.");
            }
        }
    }
}
