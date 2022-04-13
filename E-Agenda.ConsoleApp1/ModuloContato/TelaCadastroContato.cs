using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace E_Agenda.ConsoleApp1.ModuloContato
{
    public class TelaCadastroContato: TelaBase<RepositorioContato, Contato>, ITelaCadastravel
    {
           
        public RepositorioContato repositorioContato;

        public TelaCadastroContato(RepositorioContato repositorioContato)
            : base("Cadastro de contatos", repositorioContato)
        {
            this.repositorioContato = repositorioContato;
        }

        public void Inserir()
        {
            Contato contato = ObterItem();
            base.Inserir(contato);
        }
        public void Editar()
        {
            Contato contato = ObterItem();
            base.Editar(contato);
        }
        private bool IsValidEmail(string emailaddress)
        {
            return new EmailAddressAttribute().IsValid(emailaddress);
        }

        private  bool validTelephoneNo(string telNo)
        {
            return Regex.Match(telNo, @"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$").Success;
        }

        public Contato ObterItem()
        {
            string email;
            string telefone;
            do {
                Console.WriteLine("e-mail");
                email = Console.ReadLine();
            } while (!IsValidEmail(email));

            do
            {
                Console.WriteLine("numero de telefone (xx) xxxxx-xxxx");
                telefone = Console.ReadLine();

            } while (!(validTelephoneNo(telefone)));

            Console.WriteLine("nome");
            string nome = Console.ReadLine();

            Console.WriteLine("empresa");
            string empresa = Console.ReadLine();

            Console.WriteLine("cargo");
            string cargo = Console.ReadLine();


            return new Contato(nome,email,telefone,empresa,cargo);


        }

    }
}

