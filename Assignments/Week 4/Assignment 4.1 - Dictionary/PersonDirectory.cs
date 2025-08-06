using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class PersonDirectory
    {
        private Dictionary<string, Person> people = new Dictionary<string, Person>();
        public void AddPerson(string fullName, Person person)
        {
            people[fullName] = person;
        }
        public bool RemovePerson(string fullName)
        {
            return people.Remove(fullName);
        }
        public Person GetPerson(string fullName)
        {
            return people.TryGetValue(fullName, out var person) ? person : null;
        }

        public List<Person> GetAllPeople()
        {
            return people.Values.ToList();
        }

    }
}
