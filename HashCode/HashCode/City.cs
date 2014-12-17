using System;

namespace HashCode
{
    class City
    {
        public String Name;
        public UInt32 NumberOfCitizens;
        public DateTime YearOfFoundation;
        public override string ToString()
        {
            return Name + "\n"
                   + NumberOfCitizens + "\n"
                   + YearOfFoundation;
        }
    }
}
