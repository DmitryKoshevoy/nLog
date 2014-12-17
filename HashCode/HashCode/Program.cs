using System;
using System.Collections;
using System.Globalization;


namespace HashCode
{
    class Person
    {
        private readonly String _firstName;
        private readonly String _secondName;
        private readonly String _number;
        private readonly City _city;

        public Person(String firstName, String secondName, String number, City city )
        {
            _firstName = firstName;
            _secondName = secondName;
            _number = number;
            _city = city;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Person))
                return false;
            return (_firstName == ((Person)obj)._firstName) 
                   && (_secondName == ((Person)obj)._secondName)
                   && (_number == ((Person)obj)._number)
                   && (_city == ((Person)obj)._city);
        }

        public override int GetHashCode()
        {
            return (_firstName.Length + _secondName.Length
                    + Convert.ToInt32(Convert.ToUInt64(_number) / 333333333) + (Int32)_city.NumberOfCitizens
                    + _city.Name.Length + Convert.ToInt32(_city.YearOfFoundation.Year));
        }
        public override string ToString()
        {
            return _firstName + "\n"
                   + _secondName + "\n"
                   + _number+ "\n"
                   + _city;

        }
    }

    class HashTable : IEnumerable
    {
        private Person[] _personsArray = new Person[10];

        public void Add(Person person, Int32 hashcode)
        {
            Int32 index = hashcode % _personsArray.Length;
            if (_personsArray[index] == null)
            {
                _personsArray[index] = person;
            }
            else if (_personsArray[index].Equals(person))
            {
                Console.WriteLine("The same odject is already exist");
            }
            else
            {
                Array.Resize(ref _personsArray, _personsArray.Length*2);
                index = hashcode % _personsArray.Length;
                _personsArray[index] = person;
            }
            
        }

        public void Remove(Int32 hashcode)
        {
            Int32 index = hashcode % _personsArray.Length;
            _personsArray[index] = null;

        }

        public Boolean Contains(Int32 hascode)
        {
           Int32 index = hascode % _personsArray.Length;
           return _personsArray[index] != null;
        }
        public IEnumerator GetEnumerator()
        {
            return new HashTableEnum(_personsArray);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var cityes = new City[30];
            var persons = new Person[30];
            var rnd = new Random();
            var hashTabe = new HashTable();
            for (int i = 0; i < 30; i++)
            {
                cityes[i]= new City()
                {
                    Name = "Gomel-"+i,
                    NumberOfCitizens = Convert.ToUInt32(rnd.Next()),
                    YearOfFoundation = new DateTime(1663,7,7)
                };
                persons[i] = new Person("Ivan-"+i, "Petrov-"+i, rnd.Next().ToString(CultureInfo.InvariantCulture), cityes[i]);
                hashTabe.Add(persons[i], persons[i].GetHashCode());
            }
            foreach (var variable in hashTabe)
            {
                if(variable!=null)
                Console.WriteLine(variable.ToString());
            }
            Console.ReadKey();
        }
    }
}
