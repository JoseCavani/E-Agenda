using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp1.Compartilhado
{
    public abstract class TelaBase<RepositorioBase, T> where T : EntidadeBase
    {
        private RepositorioBase<T> repositorio;


        protected string Titulo { get; set; }

        public TelaBase(string titulo,RepositorioBase<T> repositorioBase)
        {
            Titulo = titulo;
            repositorio = repositorioBase;
        }


        public virtual string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    
         public virtual void Excluir()
        {
            if (!TemRegistro())
                return;
            do
            {
                if (repositorio.Excluir(PegaId()))
                {
                    Notificador.ApresentarMensagem("excluido com sucesso", TipoMensagem.Sucesso);
                    return;
                }
                Notificador.ApresentarMensagem("id nao encontrado", TipoMensagem.Erro);
            } while (true);
        }
        protected virtual void Editar(T EntidadeNova)
        {
            if (!TemRegistro())
                return;
            do
            {

                bool deuCerto = repositorio.Editar(PegaId(), EntidadeNova);

                if (deuCerto)
                {
                    Notificador.ApresentarMensagem("editado com sucesso", TipoMensagem.Sucesso);
                    return;
                }

                Console.Clear();
                Notificador.ApresentarMensagem("Id não encontrado", TipoMensagem.Atencao);
            } while (true);

        }

        protected virtual int PegaId()
        {
            int numeroId;
            do
            {

                Vizualizar();
                Console.WriteLine("qual o id do registro");

            } while (!(int.TryParse(Console.ReadLine(), out numeroId)));
            return numeroId;
        }

        protected virtual void Inserir(T entidade) 
        {
            Console.Clear();
            MostrarTitulo($"Inserindo  {typeof(T).Name}");
            repositorio.Inserir(entidade);
            Notificador.ApresentarMensagem($"{typeof(T).Name} inserido com sucesso",TipoMensagem.Sucesso);
        }
        public virtual void Vizualizar()
        {
            MostrarTitulo($"Vizualizando {typeof(T).Name}");
            if (!TemRegistro())
                return;
            foreach (object entidade in repositorio.GetRegistros())
            {
                Console.WriteLine(entidade.ToString() + Environment.NewLine);
            }
        }

        public bool TemRegistro()
        {
            if (repositorio.GetRegistros().Count == 0)
            {
                Notificador.ApresentarMensagem("não ha registros", TipoMensagem.Atencao);
                return false;
            }
            return true;
        }

        public virtual T PegarRegistro()
        {
            Vizualizar();
           return repositorio.GetRegistro(PegaId());
        }

    }
}
