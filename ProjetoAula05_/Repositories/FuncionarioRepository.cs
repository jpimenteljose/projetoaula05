using Dapper;
using ProjetoAula05_.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjetoAula05_.Repositories
{
    public class FuncionarioRepository
    {
        public string ConnectionString { get; set; }

        public void Inserir(Funcionario funcionario)
        {
            var sql = @"insert into Funcionario (IdFuncionario, Nome, Cpf, Matricula, DataAdmissao, IdEmpresa)
                                         values (NewId(), @Nome, @Cpf, @Matricula, @DataAdmissao, @IdEmpresa)";        

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public void Alterar(Funcionario funcionario)
        {
            var sql = @"Update Funcionario
                        Set Nome = @Nome, Cpf = @Cpf, Matricula = @Matricula, DataAdmissao = @DataAdmissao, IdEmpresa = @IdEmpresa
                        Where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public void Excluir(Funcionario funcionario)
        {
            var sql = @"Delete from Funcionario
                        Where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, funcionario);
            }
        }

        public List<Funcionario> ObterTodos()
        {
            var sql = @"Select * From Funcionario Order By Nome";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Funcionario>(sql)
                    .ToList();
            }
        }
    
        public List<Funcionario> ObterPorEmpresa(Guid IdEmpresa)
        {
            var sql = @"Select * 
                      From Funcionario
                      Where IdEmpresa = @IdEmpresa
                      Order By Nome";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Funcionario>(sql, new { IdEmpresa })
                    .ToList();
            }


        }

        public Funcionario ObterPorId(Guid id)
        {
            var sql = @"Select * 
                        From Funcionario
                        Where IdFuncionario = @Id";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection
                    .Query<Funcionario>(sql, new { id })
                    .FirstOrDefault();
            }
        }

    }
}
