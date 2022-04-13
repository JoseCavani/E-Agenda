﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp1.ModuloItem;

using E_Agenda.ConsoleApp1.Compartilhado;

namespace E_Agenda.ConsoleApp1.ModuloTarefa
{
    public class Tarefa : EntidadeBase, IComparable<Tarefa>
    {
       public Prioridade prioridade;
        string titulo;
        DateTime dataCriacao;
        DateTime dataConclusao;
        double percentualConclusão;

        public TelaCadastroItem telaCadastroItem;
        public RepositorioItem repositorioItem;

        public Tarefa(Prioridade prioridade, string titulo, DateTime dataCriacao, DateTime dataConclusao)
        {
            this.prioridade = prioridade;
            this.titulo = titulo;
            this.dataCriacao = dataCriacao;
            this.dataConclusao = dataConclusao;

            repositorioItem = new RepositorioItem();
            telaCadastroItem = new TelaCadastroItem(repositorioItem);
        }

        public double PercentualConclusão { get => percentualConclusão; set => percentualConclusão = value; }
        public DateTime DataConclusao { get => dataConclusao; set => dataConclusao = value; }

        public override string ToString()
        {
            return $"Id  {id}\n" +
                $"prioridade  {prioridade}\n" +
                $"titulo  {titulo}\n" +
                $"Data de criação {dataCriacao}\n" +
                $"data de conclusão {DataConclusao}\n" +
                $"Percentual de conclusão {percentualConclusão *100}%";
        }

        public int CompareTo(Tarefa other)
        {
         return other.prioridade.CompareTo(prioridade);
        }
    }
}
