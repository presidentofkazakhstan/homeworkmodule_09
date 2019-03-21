using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_09
{
    public class HDD : Storage
    {
        public int USBTwoSpeed { get; set; }
        public int AmountOfSections { get; set; }
        public int MemoryOfSections { get; set; }

        public override string Copying(File[] files)
        {
            File file = new File();
            int fullSize = file.GetFullSize(files);
            if (MemoryOfSections * 1024 <= fullSize)
            {
                return "Memory is full";
            }
            else
            {
                FreeSpace = MemoryOfSections * 1024 - fullSize;
                int sizeInKiloBytes = fullSize * 1024;
                double USBSpeedInKiloBits = USBTwoSpeed * 1024;
                double loadingTime = sizeInKiloBytes / USBSpeedInKiloBits;
                string result = Convert.ToString(loadingTime);
                return $"{result} sec";
            }
        }
        public override string GetAllInfo()
        {
            return $"Name:{NameOfDevice},\nModel:{ModelOfDevice},\nMemory:{MemoryOfSections}GB,\nUSB speed:{USBTwoSpeed}Mbyte/s";
        }
        public override double GetFreeMemory()
        {
            return FreeSpace;
        }
        public override double GetMemory()
        {
            return MemoryOfSections;
        }
    }
}
