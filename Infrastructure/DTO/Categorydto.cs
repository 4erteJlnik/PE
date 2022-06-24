using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.DTO
{
    /// <summary>
    /// Связь бд категории
    /// </summary>
    public class Categorydto
    {
        public Guid ID;
        public string Name;
        public List<Postdto> Post;
    }
}
