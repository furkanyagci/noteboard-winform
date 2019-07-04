using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.Model
{
    public class Password:baseEntity
    {
        public int PasswordID { get; set; }
        public string PasswordText { get; set; }
        public int UserID { get; set; }

        //nav prop.
        public virtual User User { get; set; }
    }
}
