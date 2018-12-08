using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB
{
    public class TakenBooks
    {
        public int Id { get; set; }
        public IList<Book> Books {get; set;}
        public int DiscipleId { get; set; }
        public int LibrarianId { get; set; }
        public DateTime TakenDate { get; set; }
    }
}
