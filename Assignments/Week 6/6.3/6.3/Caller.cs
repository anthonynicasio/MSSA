using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    public class Caller
    {
        public int Id { get; }
        public string Name { get; }
        public string Issue { get; }

        public Caller(int id, string name, string issue)
        {
            Id = id;
            Name = name;
            Issue = issue;
        }

        public override string ToString() => $"#{Id} {Name} - {Issue}";
    }
}
