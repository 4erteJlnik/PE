using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.DTO
{
    /// <summary>
    /// Связь бд файлов
    /// </summary>
    public class Filedto : WEntitydto
    {
        public Postdto post;
        public Guid postid;
        public Peopledto Author;
        public Guid Autorid;
        public long Lenght;
    }
}
