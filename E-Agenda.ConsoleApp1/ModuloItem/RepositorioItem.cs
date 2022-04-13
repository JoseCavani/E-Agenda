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
        public void Concluir(int id)
        {
            int index = Registros.FindIndex(x => x.id == id);
            Registros[index].concluido = true;
        }
    }
}
