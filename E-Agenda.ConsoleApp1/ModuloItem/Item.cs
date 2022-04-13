using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloItem
{
    public class Item : EntidadeBase
    {
       public string descricao;
      public  bool concluido;

        public Item(string descricao)
        {
            this.descricao = descricao;
            concluido = false;
        }
        public override string ToString()
        {
            return $"Id : {id}\n" +
                $"Descrição : {descricao}\n" +
                $"concluido : {concluido}";
        }
    }
}
