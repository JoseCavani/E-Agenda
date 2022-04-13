using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp1.Compartilhado
{
   public abstract class RepositorioBase<T> where T : EntidadeBase
    {
        private readonly List<T> registros;
        int contador = 0;

        protected List<T> Registros => registros;

        public RepositorioBase()
        {
            registros = new List<T>();
        }
        public virtual bool Excluir(int numeroId)
        {
            int index = registros.FindIndex(x => x.id == numeroId);

            if (index == -1)
                return false;

            registros.RemoveAt(index);
            return true;
        }
        public virtual bool Editar(int numeroId,T entidadeNova)
        {
          
          int index =  registros.FindIndex(x => x.id == numeroId);

            if (index == -1)
                return false;
            entidadeNova.id = registros[index].id;
            registros[index] = entidadeNova;
            return true;
        }
        public virtual void Inserir(T entidade)
        {
            entidade.id = ++contador;
            Registros.Add(entidade);
        }
        public virtual List<T> GetRegistros()
        {
            return Registros;
        }
           
    }
}
