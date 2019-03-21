using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_09
{
    public class Flash : Storage
    {
        public double USBThreeSpeed { get; set; }
        public double Memory { get; set; }

        public override string Copying(File[] files)
        {
            File file = new File();
            int fullSize = file.GetFullSize(files);
            if (Memory * 1024 <= fullSize)
            {
                return "Memory is full";
            }
            else
            {
                FreeSpace = Memory * 1024 - fullSize;
                int sizeInKiloBytes = fullSize * 1024;
                double USBSpeedInKiloBits = USBThreeSpeed * 1024;
                double loadingTime = sizeInKiloBytes / USBSpeedInKiloBits;
                string result = Convert.ToString(loadingTime);
                return $"{result} sec";
            }
        }

        public override string GetAllInfo()
        {
            return $"Name:{NameOfDevice},\nModel:{ModelOfDevice},\nMemory:{Memory}GB,\nUSB speed:{USBThreeSpeed}Mbyte/s";
        }
        public override double GetFreeMemory()
        {
            return FreeSpace;
        }
        public override double GetMemory()
        {
            return Memory;
        }
    }
}
