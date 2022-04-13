using E_Agenda.ConsoleApp1.Compartilhado;
using System;
using E_Agenda.ConsoleApp1.ModuloItem;
using E_Agenda.ConsoleApp1.ModuloTarefa;
using E_Agenda.ConsoleApp1.ModuloContato;
using E_Agenda.ConsoleApp1.ModuloCompromisso;

namespace E_Agenda.ConsoleApp1
{
    public class TelaMenuPrincipal
    {
        private string opcaoSelecionada;

        //// Declaração de tarefas
        private RepositorioTarefa repositorioTarefa;

        private TelaCadastroTarefa telaCadastroTarefa;

        //// Declaração de contatos
        private RepositorioContato repositorioContato;

        private TelaCadastroContato telaCadastroContato;

        //// Declaração de compromisso
        private RepositorioCompromisso repositorioCompromisso;

        private TelaCadastroCompromisso telaCadastroCompromisso;
        public TelaMenuPrincipal()
        {
          

            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa);
            repositorioTarefa.Inserir(new Tarefa(Prioridade.Baixa, "a", DateTime.Now, DateTime.Now));
            repositorioTarefa.Inserir(new Tarefa(Prioridade.Alta, "a", DateTime.Now, DateTime.Now));



            repositorioContato = new RepositorioContato();
            telaCadastroContato = new TelaCadastroContato(repositorioContato);


            repositorioContato.Inserir(new Contato("a", "b", "c", "d", "e"));

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, telaCadastroContato);


            repositorioCompromisso.Inserir(new Compromisso("a","a",DateTime.Parse("13/04/2022 23:26"),DateTime.Parse("13/04/2022 23:22"), new Contato("a", "b", "c", "d", "e")));
            repositorioCompromisso.Inserir(new Compromisso("a", "a", DateTime.Parse("13/04/2021 5:26"), DateTime.Parse("13/04/2021 5:22"), new Contato("a", "b", "c", "d", "e")));
            repositorioCompromisso.Inserir(new Compromisso("a", "a", DateTime.Parse("15/04/2022 5:26"), DateTime.Parse("15/04/2022 5:22"), new Contato("a", "b", "c", "d", "e")));
           
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
            Console.WriteLine("Digite 2 para Contato");
            Console.WriteLine("Digite 3 para Compromisso");

            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public object ObterTela()
        {
            string opcao = MostrarOpcoes();
            if (opcao == "1")
                return telaCadastroTarefa;
           else if (opcao == "2")
                return telaCadastroContato;
            else if (opcao == "3")
                return telaCadastroCompromisso;
            return null;
        }

    }

}

