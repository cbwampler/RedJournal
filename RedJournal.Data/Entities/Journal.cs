using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Data.Entities
{
    public class Journal
    {
        public int JournalId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
