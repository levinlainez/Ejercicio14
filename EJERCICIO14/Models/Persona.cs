using System;
using SQLite;

namespace EJERCICIO14.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }
        [MaxLength(70)]
        public string nombre { get; set; }
        [MaxLength(70)]
        public string descripcion {get; set; }
        public Byte[] foto { get; set; }
        
    }
}
