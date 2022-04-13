using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloItem
{
    public class RepositorioItem : RepositorioBase<Item>
    {
        public bool Concluir(int id)
        {
            
           if (Registros.Find(x => x.id == id) == default)
                return false;
            else
            {
                Registros.Find(x => x.id == id).concluido = true;
                return true;
            }
           
        }
    }
}
