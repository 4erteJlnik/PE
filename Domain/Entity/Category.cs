using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Entity
{
    public class Category
    {
        /// <summary>
        /// id
        /// </summary>
        /// <value>Id</value>
        public Guid ID { get; }
        public string Name { get; set; }
        public Category(string name)
        {
            Name = name;
            ID = Guid.NewGuid();
        }
    }
}
