using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloContato
{
    public class Contato : EntidadeBase, IComparable<Contato>
    {
        string nome;
        string email;
        string telefone;
        string empresa;
        string cargo;

        public Contato(string nome,
        string email,
        string telefone,
        string empresa,
        string cargo)
        {
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.empresa = empresa;
            this.cargo = cargo;
        }

        public string Nome { get => nome; }

        public int CompareTo(Contato other)
        {
          return  cargo.CompareTo(other.cargo);
        }

        public override string ToString()
        {
            return $"Id : {id}\n" +
                $"nome : {Nome}\n" +
                $"email : {email}\n" +
                $"telefone : {telefone}\n" +
                $"empresa : {empresa}\n" +
                  $"cargo : {cargo}\n";
        }
    }
}
