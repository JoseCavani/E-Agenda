using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.ModuloItem;

using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloTarefa
{

    public class TelaCadastroTarefa : TelaBase<RepositorioTarefa, Tarefa>
    {
        TelaCadastroItem telaCadastroItem;
        private readonly RepositorioTarefa repositorioTarefa;
        public TelaCadastroTarefa(RepositorioTarefa repositorioTarefa)
           : base("Cadastro de items", repositorioTarefa)
        {
            this.repositorioTarefa = repositorioTarefa;
        }

        private void VizualizarTodas()
        {
            MostrarTitulo($"Vizualizando todas as Tarefas");

            foreach (Tarefa entidade in repositorioTarefa.GetRegistros())
            {
                Console.WriteLine(entidade.ToString() + Environment.NewLine);
            }
        }
        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para  items");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public override void Vizualizar()
        {
            if (!TemRegistro())
                return;
           repositorioTarefa.Ordenar();
            Console.WriteLine("1 = pendentes\n" +
                "2 = completas\n" +
                "3 = todas");

            switch (Console.ReadLine()) {
                case "1":

            MostrarTitulo($"Vizualizando Tarefas Pendentes");
           
            foreach (Tarefa entidade in repositorioTarefa.GetRegistros())
            {
                        if (entidade.PercentualConclusão != 1)
                Console.WriteLine(entidade.ToString() + Environment.NewLine);
            }
                    break;
                case "2":
                    MostrarTitulo($"Vizualizando Tarefas Completas");

                    foreach (Tarefa entidade in repositorioTarefa.GetRegistros())
                    {
                        if (entidade.PercentualConclusão == 1)
                            Console.WriteLine(entidade.ToString() + Environment.NewLine);
                    }
                    break;
                case "3":
                    VizualizarTodas();
                    break;
            }
    }
        protected override int PegaId()
        {
            int numeroId;
            do
            {

                VizualizarTodas();
                Console.WriteLine("qual o id do registro");

            } while (!(int.TryParse(Console.ReadLine(), out numeroId)));
            return numeroId;
        }

        public void Inserir()
        {
            Tarefa item = ObterTarefa(false);
            base.Inserir(item);
        }
        public void Editar()
        {
            Tarefa item = ObterTarefa(true);
            int id = PegaId();
            base.Editar(item,id);
        }
    
        public override void Excluir()
        {
            if (!TemRegistro())
                return;
            
                if (repositorioTarefa.Excluir(PegaId()))
            {
                Notificador.ApresentarMensagem("excluido com sucesso", TipoMensagem.Sucesso);
                return;
            }
            Notificador.ApresentarMensagem("id nao encontrado ou items nao realizado", TipoMensagem.Erro);
        }

        public void Items() {
            if (!TemRegistro())
                return;
           int numeroId = PegaId();

            telaCadastroItem = repositorioTarefa.PegaTela(numeroId);

            string opcaoSelecionada = telaCadastroItem.MostrarOpcoes();
            switch (opcaoSelecionada)
            {
                case "1":
                    telaCadastroItem.Inserir();
                    repositorioTarefa.Atualizar(numeroId, telaCadastroItem.repositorioItem.GetRegistros());
                    break;
                case "2":
                    telaCadastroItem.Editar();
                    numeroId = PegaId();
                    repositorioTarefa.Atualizar(numeroId, telaCadastroItem.repositorioItem.GetRegistros());
                    Console.ReadKey();
                    break;
                case "3":
                    telaCadastroItem.Excluir();
                    numeroId = PegaId();
                    repositorioTarefa.Atualizar(numeroId, telaCadastroItem.repositorioItem.GetRegistros());
                    Console.ReadKey();
                    break;
                case "4":
                    telaCadastroItem.Vizualizar();
                    Console.ReadKey();
                    break;
                case "5":
                    telaCadastroItem.Concluir();
                    repositorioTarefa.Atualizar(numeroId, telaCadastroItem.repositorioItem.GetRegistros());
                    Console.ReadKey();
                    break;
            }
        }
        /// <summary>
        /// E para editar?
        /// </summary>
        /// <param name="editar"></param>
        /// <returns></returns>
            private Tarefa ObterTarefa(bool editar)
            {
            string titulo;
            int numero = 0;
            Prioridade prioridade;
            DateTime data;

            if (editar)
            {
                 numero = 0;
                do
                {
                    Console.WriteLine("Prioridade da tarefa \n" +
                        "1 = Alta\n" +
                        "2 = Normal\n" +
                        "3 = Baixa\n");
                } while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 3 || numero < 1);
                 prioridade = Prioridade.Baixa;
                switch (numero)
                {
                    case 1:
                        prioridade = Prioridade.Alta;
                        break;
                    case 2:
                        prioridade = Prioridade.Normal;
                        break;
                    case 3:
                        prioridade = Prioridade.Baixa;
                        break;
                }
                Console.WriteLine("titulo");
                 titulo = Console.ReadLine();
               
                return new Tarefa(prioridade, titulo, DateTime.Now, DateTime.Now);
            }

                 numero = 0;
                do
                {
                    Console.WriteLine("Prioridade da tarefa \n" +
                        "1 = Alta\n" +
                        "2 = Normal\n" +
                        "3 = Baixa\n");
                } while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 3 || numero < 1);
                 prioridade = Prioridade.Baixa;
                switch (numero)
                {
                    case 1:
                        prioridade = Prioridade.Alta;
                        break;
                    case 2:
                        prioridade = Prioridade.Normal;
                        break;
                    case 3:
                        prioridade = Prioridade.Baixa;
                        break;
                }
                Console.WriteLine("titulo");
                 titulo = Console.ReadLine();
                do
                {
                    Console.WriteLine("data de conclusão");
                } while (!(DateTime.TryParse(Console.ReadLine(), out data)));
                Tarefa t = new Tarefa(prioridade, titulo, DateTime.Now, data);
            t.PercentualConclusão = 1;
            return t;

            }
    }
}
