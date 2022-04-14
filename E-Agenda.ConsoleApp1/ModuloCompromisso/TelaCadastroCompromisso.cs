using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.Compartilhado;
using E_Agenda.ConsoleApp1.ModuloContato;

namespace E_Agenda.ConsoleApp1.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase<RepositorioCompromisso,Compromisso>,ITelaCadastravel
    {
        RepositorioCompromisso repositorioCompromisso;
        TelaCadastroContato telaCadastroContato;
        public TelaCadastroCompromisso(RepositorioCompromisso repositorioCompromisso, TelaCadastroContato telaCadastroContato)
          : base("Cadastro de compromissos", repositorioCompromisso)
        {
            this.repositorioCompromisso = repositorioCompromisso;
            this.telaCadastroContato = telaCadastroContato;
        }

        public void Inserir()
        {
            Compromisso c = ObterCompromisso();
            base.Inserir(c);
        }
        public void Editar()
        {
            Compromisso c = ObterCompromisso();
          int id =  PegaId();
            base.Editar(c,id);
        }

        private Compromisso ObterCompromisso()
        {
            Console.WriteLine("Assunto");
            string assunto = Console.ReadLine();

            Console.WriteLine("Local");
            string local = Console.ReadLine();

           Console.Clear();
           Console.WriteLine("Lista de contatos para selecionar");
           Contato c = telaCadastroContato.PegarRegistro();

            Console.WriteLine("data");

            string line = Console.ReadLine();
            DateTime data;
            while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
            {
                Notificador.ApresentarMensagem("data invalida tente novamente", TipoMensagem.Erro);
                line = Console.ReadLine();
            }


            Console.WriteLine("hora de inicio");

             line = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(line, "H:mm", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Notificador.ApresentarMensagem("hora invalida tente novamente", TipoMensagem.Erro);
                line = Console.ReadLine();
            }
            DateTime dataInicio = data.Add(TimeSpan.Parse(line));

            Console.WriteLine("hora de fim");

            line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "H:mm", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Notificador.ApresentarMensagem("hora invalida tente novamente", TipoMensagem.Erro);
                line = Console.ReadLine();
            }
            DateTime dataFim = data.Add(TimeSpan.Parse(line));
           



            return   new Compromisso(assunto,local,dataInicio,dataFim,c);

        }

        public override void Vizualizar()
        {
            if (!TemRegistro())
                return;
            Console.WriteLine("vizualizar quais compromissos\n" +
                "1 = passados\n" +
                "2 = semanal\n" +
                "3 = diaria\n" +
                "4 = data especifica");

            switch (Console.ReadLine())
            {
                case "1":
                 MostrarTitulo($"Vizualizando Compromissos passados");
                    foreach (Compromisso c in repositorioCompromisso.GetRegistros())
                    {
                        TimeSpan t = c.DataInicio - DateTime.Now;
                        if (t.Seconds < 0)
                        Console.WriteLine(c.ToString() + Environment.NewLine);
                    }
                    break;
                case "2":
                    MostrarTitulo($"Vizualizando Compromissos semanal");
                    foreach (Compromisso c in repositorioCompromisso.GetRegistros())
                    {
                        TimeSpan t = c.DataInicio - DateTime.Now;
                        if (t.Days >= 1 && t.Days <= 7 && t.Seconds > 0)
                            Console.WriteLine(c.ToString() + Environment.NewLine);
                    }
                    break;
                case "3":
                    MostrarTitulo($"Vizualizando Compromissos diario");
                    foreach (Compromisso c in repositorioCompromisso.GetRegistros())
                    {
                        TimeSpan t = c.DataInicio - DateTime.Now;
                        if (t.Days >= 0 && t.Days < 1  && t.Seconds > 0)
                            Console.WriteLine(c.ToString() + Environment.NewLine);
                    }
                    break;
                case "4":
                    DateTime dataInicio;
                   DateTime dataFim;
                    do
                    {
                        Console.WriteLine("data inicio");
                    } while (!(DateTime.TryParse(Console.ReadLine(), out dataInicio)));
                    do
                    {
                        Console.WriteLine("data fim");
                    } while (!(DateTime.TryParse(Console.ReadLine(), out dataFim)));
                    Console.Clear();
                    MostrarTitulo($"Vizualizando Compromissos diario");
                    foreach (Compromisso c in repositorioCompromisso.GetRegistros())
                    {

                        if (c.DataInicio >= dataInicio && c.DataFim <= dataFim)
                            Console.WriteLine(c.ToString() + Environment.NewLine);
                    }
                    break;
            }
        }
    }
}
