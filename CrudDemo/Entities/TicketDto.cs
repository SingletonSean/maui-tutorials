using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDemo.Entities
{
    public class TicketDto
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Points { get; set; }
    }
}
