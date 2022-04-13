using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using E_Agenda.ConsoleApp1.Compartilhado;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.ModuloItem;

namespace E_Agenda.ConsoleApp1.ModuloTarefa
{
    public class RepositorioTarefa : RepositorioBase<Tarefa>
    {
        internal bool AtualizarItems(int numeroId, List<Item> items)
        {
            int index = Registros.FindIndex(x => x.id == numeroId);

            if (index == -1)
                return false;
            Registros[index].Items = items;
            AtualizarPercentual(index);
            return true;
        }

        public bool ExcluirItem(int id)
        {
            int index = Registros.FindIndex(x => x.id == id);

            if (index == -1 || Registros[index].PercentualConclusão != 1)
                return false;
            Registros.RemoveAt(index);
            return true;
        }

        public override bool Editar(int numeroId, Tarefa entidadeNova)
        {

            int index = Registros.FindIndex(x => x.id == numeroId);

            if (index == -1)
                return false;
            entidadeNova.id = Registros[index].id;
            entidadeNova.DataConclusao = Registros[index].DataConclusao;
            Registros[index] = entidadeNova;
            return true;
        }

        public void AtualizarPercentual(int index)
        {
            int contador = 0;
            foreach (var item in Registros[index].Items)
            {
                if (item.concluido)
                contador++;
            }
           Registros[index].PercentualConclusão = (double)contador / (double)Registros[index].Items.Count;
        }

        internal void Ordenar()
        {
            Registros.Sort();
        }
    }
}
