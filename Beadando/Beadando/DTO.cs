using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Beadando
{
    public class DTO
    {

        public DTO() { }
        public string? Nev { get; set; }
        public int? Helyek_szama { get; set; }
        public double? Osszeg { get; set; }
        public string? Kupon { get; set; }
        public string? Meddig { get; set; }
        public string? Utvonal { get; set; }
        public string? Tipus { get; set; }
        public string? Osztaly { get; set; }

    }
}
