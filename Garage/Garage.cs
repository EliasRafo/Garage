using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("TestGarage")]


namespace Garage
{
    // Generic class
    [Serializable]
    internal class Garage<T> : IEnumerable<T>  where T : Vehicle
    {
        private T[] vehicles;
        private int capacity;
        private int count;

        public bool IsFull => count == capacity;  // IsFull = true if garage is full

        public int Capacity => capacity;

        public Garage(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity should be bigger than zero.");
            
            this.capacity = capacity;
            vehicles = new T[capacity];
            count = 0;
        }

        public bool AddVehicle(T vehicle)  // Add vehicle to garage
        {
            bool result = false;
            
            if(vehicle is null) throw new ArgumentNullException(nameof(vehicle), "Vehicle not allowd to be null");

            if (!IsFull)  // Checking if garage is full
            {
                for (int i = 0; i < capacity; i++)
                {
                    if (vehicles[i] == null)
                    {
                        vehicles[i] = vehicle;
                        count++;
                        result = true;
                        break;
                    }
                }
            }
            
            return result;
        }

        
        public IEnumerator<T> GetEnumerator()   
        {
            foreach (T item in vehicles)
            {
                if(item is not null)
                     yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      
        internal bool RemoveVehicle(T vehicle)  // Remove vehicle from garage
        {
            bool result = false;
            
            if (vehicle is null) 
                throw new ArgumentNullException(nameof(vehicle), "Vehicle not allowd to be null");
            else
            {
                int index = Array.IndexOf(vehicles, vehicle);
                Array.Clear(vehicles, index, 1);
                count--;
                result = true;
            }

            return result;
        }
    }
}
