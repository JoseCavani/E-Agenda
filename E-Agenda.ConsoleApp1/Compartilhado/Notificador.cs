using System;

namespace E_Agenda.ConsoleApp1
{
    public static class Notificador
        {
            public static void ApresentarMensagem(string mensagem, TipoMensagem tipoMensagem)
            {
                switch (tipoMensagem)
                {
                    case TipoMensagem.Sucesso:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case TipoMensagem.Atencao:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;

                    case TipoMensagem.Erro:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(mensagem);
                Console.ResetColor();
                Console.ReadLine();
            }

        }
    
}

