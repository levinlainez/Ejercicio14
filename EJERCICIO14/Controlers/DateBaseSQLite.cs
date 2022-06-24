using System;
using System.Collections.Generic;
using System.Text;
using EJERCICIO14.Models;
using SQLite;
using System.Threading.Tasks;

namespace EJERCICIO14.Controlers
{
    public class DateBaseSQLite
    {
        readonly SQLiteAsyncConnection db;
        

        //constructor de clase
        public DateBaseSQLite(string pathdb)
        {
            //crear la conexion de la base datos
            db = new SQLiteAsyncConnection(pathdb);
            //creacion de la tabla dentro de sqlite
            db.CreateTableAsync<Persona>().Wait();
        }

        //Operaciones CRUD con SQLite
        //READ List Way
        public Task<List<Persona>> ObtenerListaPersona()
        {
            return db.Table<Persona>().ToListAsync();
        }

        //Mostrar solo una persona
        public Task<Persona> ObtenerPersona(int pcodigo)
        {
            return db.Table<Persona>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //guardar persona
        public Task<int> GuardarPersona(Persona persona)
        {
            if(persona.codigo != 0)
            {
                return db.UpdateAsync(persona);
            }
            else
            {
                return db.InsertAsync(persona);
            }

        
       
        }
        //Eliminar persona
        public Task<int> EliminarPersona(Persona persona)
        {
            return db.DeleteAsync(persona);
        }


    }
}
