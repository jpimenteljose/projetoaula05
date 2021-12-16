using ProjetoAula05_.Controllers;
using System;

namespace ProjetoAula05_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE EMPRESAS E FUNCIONÁRIOS\n");

            var empresaController = new EmpresaController();

            Console.WriteLine("(1) Cadastrar empresa");
            Console.WriteLine("(2) Atualizar empresa");
            Console.WriteLine("(3) Excluir empresa");
            Console.WriteLine("(4) Consultar empresas");
            Console.WriteLine("(5) Sair");

            try
            {
                Console.Write("\nEscolha a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        empresaController.CadastrarEmpresa();
                        Main(args); //recursividade
                        break;
                    case 2:
                        empresaController.AtualizarEmpresa();
                        Main(args); //recursividade
                        break;
                    case 3:
                        empresaController.ExcluirEmpresa();
                        Main(args); //recursividade
                        break;
                    case 4:
                        empresaController.ConsultarEmpresas();
                        Main(args); //recursividade
                        break;
                    case 5:
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
