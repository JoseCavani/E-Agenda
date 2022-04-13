using E_Agenda.ConsoleApp1.Compartilhado;
using System;
using E_Agenda.ConsoleApp1.ModuloItem;
using E_Agenda.ConsoleApp1.ModuloTarefa;

namespace E_Agenda.ConsoleApp1
{
    public class TelaMenuPrincipal
    {
        private string opcaoSelecionada;

        //// Declaração de tarefas
        private RepositorioTarefa repositorioTarefa;

        private TelaCadastroTarefa telaCadastroTarefa;

        //// Declaração de contatos
        //private IRepositorio<Revista> repositorioRevista;

        //private TelaCadastroRevista telaCadastroRevista;

        //// Declaração de compromisso
        //private IRepositorio<Amigo> repositorioAmigo;
        //private TelaCadastroAmigo telaCadastroAmigo;
        public TelaMenuPrincipal()
        {
          

            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa);


            //telaCadastroReserva = new TelaCadastroReserva(
            //    notificador,
            //    repositorioReserva,
            //    repositorioAmigo,
            //    repositorioRevista,
            //    telaCadastroAmigo,
            //    telaCadastroRevista,
            //    repositorioEmprestimo
            //);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Clube da Leitura 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Tarefa");

            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public object ObterTela()
        {
            string opcao = MostrarOpcoes();
            if (opcao == "1")
                return telaCadastroTarefa;
            return null;
        }

    }

}

