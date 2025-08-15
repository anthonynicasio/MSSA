using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _6._1._1
{
    internal class House
    {
        // The data for our house
        public int HouseNumber;
        public string Address;
        public string HouseType;

        // The pointer to the next house
        public House Next;
    }

    class HouseList
    {
        // These will be the references to the first and last houses
        public House head;
        public House tail;

        /* TODO: Create methods for managing the list
         * e.g. searching, adding a new house, etc.
         */

        public HouseList()
        {
            this.head = null;
            this.tail = null;
        }
        public void AddHouse(int houseNumber, string address, string houseType)
        {
            House newHouse = new House()
            {
                HouseNumber = houseNumber,
                Address = address,
                HouseType = houseType
            };

            if (this.head == null)
            {
                this.head = newHouse;
                this.tail = newHouse;
            }
            else
            {
                newHouse.Next = newHouse;
                tail = newHouse;
            }

        }
        public House SearchHouse(int houseNumberToFind)
        {
            // Start search at beginning of the list

            House current = head;

            while (current != null)
            {
                if (current.HouseNumber == houseNumberToFind)
                {
                    return current; // We found it, so we return the House object
                }
                else
                {
                    current = current.Next; // Move to the next house
                }
            }
            return null; // We reached the end of the list without finding it
        }

        public void RemoveHouse(int houseNumber)
        {
            // Check if the list is empty
            if (head == null)
            {
                return;

            }

            // Check if we're removing the head
            if (head.HouseNumber == houseNumber)
            {
                head = head.Next;
                return;
            }

            // Search for the house to remove (middle or tail)
            House previous = head;
            House current = head.Next;
            while (current != null)
            {
                if (current.HouseNumber == houseNumber)
                {
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        // This means we just removed the tail
                        tail = previous;
                    }
                    return;
                }
                previous = current;
                current = current.Next;
            }

        }
    }
}