using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloContato
{
    public class RepositorioContato : RepositorioBase<Contato>
    {
        public void AgrupadosPorCargo()
        {
            Registros.Sort();
        }
    }
}
