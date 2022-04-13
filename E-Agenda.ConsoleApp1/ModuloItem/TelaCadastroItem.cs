using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloItem
{
    public class TelaCadastroItem : TelaBase<RepositorioItem,Item>
    {
        public RepositorioItem repositorioItem;

        public TelaCadastroItem(RepositorioItem repositorioItem)
            : base("Cadastro de items", repositorioItem)
        {
            this.repositorioItem = repositorioItem;
        }

        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Concluir");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Inserir()
        {
            Item item = ObterItem();
            base.Inserir(item);
        }
        public void Editar()
        {
            Item item = ObterItem();
            int id = PegaId();
            base.Editar(item,id);
        }

        public void Concluir()
        {
           if(repositorioItem.Concluir(PegaId()))
            Notificador.ApresentarMensagem("item concluido com sucesso", TipoMensagem.Sucesso);
           else
                Notificador.ApresentarMensagem("nao encontrado", TipoMensagem.Erro);
        }
        public Item ObterItem()
        {
            Console.WriteLine("descrição do item");
            string descricao = Console.ReadLine();

            return new Item(descricao);
        }

    }
}
