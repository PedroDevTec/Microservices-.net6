using APIdotnet6.Model;

namespace APIdotnet6.Services
{
    public interface IPerson 
    {
        Person Create(Person person);
        Person Update(Person person);

        Person FindById(long id);

        void Delete(long id);

        List<Person> FindAll();
    }
}
