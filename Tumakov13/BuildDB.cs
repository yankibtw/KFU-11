using System;
using System.Collections.Generic;

namespace Tumakov13
{
    internal class BuildDB
    {
        private Build[] builds;
    
        public BuildDB()
        {
            builds = new Build[10];

            for (int i = 0; i < 10; i++)
            {
                builds[i] = new Build();
            }
        }

        public Build this[int index]
        {
            get
            {
                if (index < 0 || index >= builds.Length)
                {
                    throw new IndexOutOfRangeException("Введите корректное значение от 0 до 10!");
                }

                return builds[index];
            }
            set
            {
                if (index < 0 || index >= builds.Length)
                {
                    throw new IndexOutOfRangeException("Введите корректное значение от 0 до 10!");
                }

                builds[index] = value;
            }
        }
    }
}
