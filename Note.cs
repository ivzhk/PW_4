using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Note
{
    internal class Note
    {
        public static List<Note> schedule = new List<Note>();
        
        public string name = "заметка";
        public int  data1;
        public string text = "пусто";
        public DateTime data2 = new DateTime();
    }
}
