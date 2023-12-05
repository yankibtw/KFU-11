using System;

namespace Tumakov13
{
    class Build
    {
        private static uint accountNumberSeed = 0;
        public uint ID { get; set; }
        public double HeightBuild { get; set;}
        public uint NumberOfFloors { get; set; }
        public uint QtyOfApartments { get; set; }
        public uint QtyOfEntrances { get; set; }

        private uint GenerateID()
        {
            accountNumberSeed++;
            return accountNumberSeed;
        }
        public Build() { }
        public Build(double heightBuild, uint numberOfFloors, uint qtyOfApartments, uint qtyOfEntrances)
        {
            ID = GenerateID();
            HeightBuild = heightBuild;
            NumberOfFloors = numberOfFloors;
            QtyOfApartments = qtyOfApartments;
            QtyOfEntrances = qtyOfEntrances;
        }

        public void GetInfoOfBuild()
        {
            Console.WriteLine($"Номер здания: {ID}\n" +
                $"Высота здания: {HeightBuild}\n" +
                $"Количество этажей в здании: {NumberOfFloors}\n" +
                $"Количество квартир в здании: {QtyOfApartments}\n" +
                $"Количество подъездов в здании: {QtyOfEntrances}");
        }
        public double CalculateHeighPerFloor()
        {
            return (HeightBuild / NumberOfFloors);
        }
        public uint? CalculateApartmentsPerEntrances()
        {
            if (QtyOfApartments % QtyOfEntrances == 0) return QtyOfApartments / QtyOfEntrances;
            else return null;
        }
        public uint? CalculateApartmentsPerFloors()
        {
            if (QtyOfApartments % NumberOfFloors == 0) return QtyOfApartments / NumberOfFloors;
            else return null;
        }
    }
}