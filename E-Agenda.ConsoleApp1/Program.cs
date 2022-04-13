using System;
using E_Agenda.ConsoleApp1.Compartilhado;
using E_Agenda.ConsoleApp1.ModuloItem;
using E_Agenda.ConsoleApp1.ModuloTarefa;
using E_Agenda.ConsoleApp1.ModuloContato;

namespace E_Agenda.ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();

            while (true)
            {
                object telaSelecionada = menuPrincipal.ObterTela();

                if (telaSelecionada is null)
                    return;

                if (telaSelecionada is TelaCadastroTarefa)
                {
                    TelaCadastroTarefa telaCadastro = (TelaCadastroTarefa)telaSelecionada;
                    string opcaoSelecionada = telaCadastro.MostrarOpcoes();
                    switch (opcaoSelecionada)
                    {
                        case "1":
                            telaCadastro.Inserir();
                            break;
                        case "2":
                            telaCadastro.Editar();
                            Console.ReadKey();
                            break;
                        case "3":
                            telaCadastro.Excluir();
                            Console.ReadKey();
                            break;
                        case "4":
                            telaCadastro.Vizualizar();
                            Console.ReadKey();
                            break;
                        case "5":
                            telaCadastro.Items();
                            break;
                    }
                }
                if (telaSelecionada is ITelaCadastravel)
                {
                    ITelaCadastravel telaCadastro = (ITelaCadastravel)telaSelecionada;
                    string opcaoSelecionada = telaCadastro.MostrarOpcoes();
                    switch (opcaoSelecionada)
                    {
                        case "1":
                            telaCadastro.Inserir();
                            break;
                        case "2":
                            telaCadastro.Editar();
                            Console.ReadKey();
                            break;
                        case "3":
                            telaCadastro.Excluir();
                            Console.ReadKey();
                            break;
                        case "4":
                            telaCadastro.Vizualizar();
                            Console.ReadKey();
                            break;
                    }

                }
            }


        }

    }
}

