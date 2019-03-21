using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac_09
{
    public class DVD : Storage
    {
        public double ReadingSpeed { get; set; }
        public RecordType type { get; set; }

        public override string Copying(File[] files)
        {
            File file = new File();
            int fullSize = file.GetFullSize(files);
            double whatType = 0;
            if (type == RecordType.unilateral)
            {
                whatType = 4.7 * 1024;
            }
            else
            {
                whatType = 9 * 1024;
            }
            if (whatType <= fullSize)
            {
                return "Memory is full";
            }
            else
            {
                FreeSpace = whatType - fullSize;
                int sizeInKiloBytes = fullSize * 1024;
                double ReadingSpeedInKiloBits = ReadingSpeed * 1024;
                double loadingTime = sizeInKiloBytes / ReadingSpeedInKiloBits;
                string result = Convert.ToString(loadingTime);
                return $"{result} sec";
            }
        }

        public override double GetFreeMemory()
        {
            return FreeSpace;
        }
        public override string GetAllInfo()
        {
            return $"Name:{NameOfDevice},\nModel:{ModelOfDevice},\nType:{type},\nReading speed:{ReadingSpeed}Mbyte/s";
        }


        public override double GetMemory()
        {
            if (type == RecordType.unilateral)
            {
                return 4.7;
            }
            else
            {
                return 9;
            }
        }
    }
}
