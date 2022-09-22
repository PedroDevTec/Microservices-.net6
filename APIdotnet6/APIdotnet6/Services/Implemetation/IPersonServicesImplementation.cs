using APIdotnet6.Model;

namespace APIdotnet6.Services.Implemetation
{
    public class IPersonServicesImplementation : IPerson
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);  
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Name = "Person Name" + i,
                LastName = "Person LastName" + i,
                Adress = "Some Adress" + i,
                Gender = "Male"
            };
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Name = "joao",
                LastName = "Pedro",
                Adress = "Minas Gerais",
                Gender = "Male"
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
