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
        internal bool Atualizar(int numeroId, List<Item> items)
        {

            Tarefa tarefa = Registros.Find(x => x.id == numeroId);
            if (tarefa == default)
                return false;
            AtualizarPercentual(tarefa, items);
            return true;
        }

        public override bool Excluir(int id)
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

        private void AtualizarPercentual(Tarefa tarefa, List<Item> items)
        {
            int contador = 0;
            foreach (var item in items)
            {
                if (item.concluido)
                contador++;
            }
           tarefa.PercentualConclusão = (double)contador / items.Count;
        }

        internal void Ordenar()
        {
            Registros.Sort();
        }

        public TelaCadastroItem PegaTela(int id)
        {
           return Registros.Find(x => x.id == id).telaCadastroItem;
        }
    }
}
