using Aula10_MVC_.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Aula10_MVC_.Repositories
{
    public class PessoaMdfRepository
    {
        private string _connectionString;

        public IEnumerable<PessoaModel> GetAll()
        {
            Console.WriteLine();
            Console.WriteLine("======================");
            Console.WriteLine("Dados da tabela Pessoa");

            var _connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mariana.dsantos\source\repos\MVC_AULA10\Aula10[MVC]\Aula10[MVC]\AppData\Pessoa.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = $"SELECT Id, Nome, Nascimento FROM Pessoa";

            var pessoas = new List<PessoaModel>();

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        var idColumnIndex = reader.GetOrdinal("Id");
                        var nomeColumnIndex = reader.GetOrdinal("Nome");
                        while (reader.Read())
                        {
                            var id = reader.GetFieldValue<int>(idColumnIndex);
                            var nome = reader.GetFieldValue<string>(nomeColumnIndex);
                            var nascimento = reader.GetFieldValue<DateTime>(nascimentoColumnIndex);

                            var novaPessoa = new PessoaModel
                            {
                                id

                            }


                            Console.WriteLine($"ID: {id}, Nome: {nome}");
                        }
                    }

                }
            }

            return pessoas;
        }

        public void Add(PessoaModel newPessoaModel)
        {
            Console.Write("Entre com o nome: ");
            var input = Console.ReadLine();

            var connectionString =
                 @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mariana.dsantos\source\repos\MVC_AULA10\Aula10[MVC]\Aula10[MVC]\AppData\Pessoa.mdf;Integrated Security=True;Connect Timeout=30";

            var cmdText = "INSERT INTO Pessoa" +
                "		(Nome, Nascimento)" +
                "VALUES	(@pessoaNome, @pessoaNascimento);";

            using (var sqlConnection = new SqlConnection(connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@pessoaNome", SqlDbType.VarChar).Value = newPessoaModel.Nome;
                sqlCommand.Parameters
                    .Add("@pessoaNascimento", SqlDbType.Date).Value = newPessoaModel.Nascimento;

                sqlConnection.Open();

                var resutScalar = sqlCommand.ExecuteScalar();
            }
        }
    }
}
