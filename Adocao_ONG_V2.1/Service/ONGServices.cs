using Adocao_ONG_V2._1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Service
{
    public class ONGServices
    {
        string Conexao = "Data Source=localhost;Initial Catalog=Adocao_ONG_V2;User id=sa;Password=cear2712;";

        public ONGServices()
        {
        }

        public string Caminho()
        {
            return Conexao;
        }

        #region CRUD sem DELETE - PESSOA
        //public Pessoa InserirPessoaBanco()
        //{
        //    Pessoa pessoa = new Pessoa();

        //    pessoa.CadastraPessoa();

        //    ONGServices conn = new ONGServices();
        //    SqlConnection conexaosql = new SqlConnection(conn.Caminho());
        //    conexaosql.Open();

        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = $"INSERT INTO Pessoa(Cpf, Nome_Pes, Sexo, Data_Nascimento, Telefone, Logradouro, Numero, Bairro, Cidade, Estado, Cep)" + $"VALUES ('{pessoa.Cpf}','{pessoa.Nome}','{pessoa.Sexo}','{pessoa.DataNascimento}','{pessoa.TelefoneContato}','{pessoa.Logradouro}','{pessoa.Numero}','{pessoa.Bairro}','{pessoa.Cidade}','{pessoa.Estado}','{pessoa.Cep}')";

        //    cmd.Connection = conexaosql;
        //    cmd.ExecuteNonQuery();

        //    conexaosql.Close();

        //    Console.WriteLine("Cadastro Concluído\n");
        //    Console.WriteLine("\nProcesso Finalizado!\nPressione [Enter] para continuar...");
        //    Console.ReadKey();
        //    return pessoa;
        //}

        public Pessoa SelecionarPessoasBanco()
        {
            Pessoa pessoa = new Pessoa();

            ONGServices conn = new ONGServices();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cpf, Nome_Pes, Sexo, Data_Nascimento, Telefone, Logradouro, Numero, Bairro, Cidade, Estado, Cep FROM Pessoa";

            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("PESSOAS CADASTRADAS:\n");
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetString(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
                    Console.WriteLine("{0}", reader.GetString(3));
                    Console.WriteLine("{0}", reader.GetString(4));
                    Console.WriteLine("{0}", reader.GetString(5));
                    Console.WriteLine("{0}", reader.GetInt32(6));
                    Console.WriteLine("{0}", reader.GetString(7));
                    Console.WriteLine("{0}", reader.GetString(8));
                    Console.WriteLine("{0}", reader.GetString(9));
                    Console.WriteLine("{0}", reader.GetString(10));
                    Console.WriteLine("\n----------------------------\n");
                }
            }
            conexaosql.Close();
            Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
            Console.ReadKey();
            return pessoa;
        }

        public Pessoa AtualizarPessoaBanco()
        {
            int count = 0;
            Pessoa pessoa = new Pessoa();
            SqlCommand cmd = new SqlCommand();
            ONGServices conn = new ONGServices();
            SqlConnection conexaoSql = new SqlConnection(conn.Caminho());

            Console.Write("Informe o CPF que deseja atualizar: ");
            string cpfDigitado = Console.ReadLine();

            conexaoSql.Open();

            cmd = new();

            cmd.CommandText = $"SELECT * FROM Pessoa where Cpf = '{cpfDigitado}'";

            cmd.Connection = conexaoSql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("CPF digitado não localizado!");
                Console.ReadKey();
                return pessoa;
            }

            int opcao = 0;
            do
            {
                Console.WriteLine("Informe a opcao que deseja alterar: ");
                Console.WriteLine(" 1 - Nome");
                Console.WriteLine(" 2 - Sexo");
                Console.WriteLine(" 3 - Data de Nascimento");
                Console.WriteLine(" 4 - Telefone");
                Console.WriteLine(" 5 - Endereço");
                Console.Write(" Informe a opcao: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

            } while (opcao < 1 || opcao > 5);

            switch (opcao)
            {
                case 1:
                    Console.Write("Informe o novo nome: ");
                    string novoNome = Console.ReadLine().ToUpper();

                    cmd.CommandText = $"UPDATE Pessoa SET Nome_Pes = '{novoNome}' WHERE Cpf = '{cpfDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Nome alterado com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Write("Informe o novo sexo: ");
                    char novoSexo = char.Parse(Console.ReadLine().ToUpper());

                    cmd.CommandText = $"UPDATE Pessoa SET Sexo = '{novoSexo}' WHERE Cpf = '{cpfDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Sexo alterado com secesso");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Write("Informe a nova data de nascimento (ddMMyyyy): ");
                    string novaDat = Console.ReadLine().Replace("/", "");

                    cmd.CommandText = $"UPDATE Pessoa SET Data_Nascimento = '{novaDat}' WHERE Cpf = '{cpfDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Data de nascimento alterada com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Write("Informe o novo telefone: ");
                    string novoTelefone = Console.ReadLine().Replace("(", "").Replace(")", "").Replace("-", "");

                    cmd.CommandText = $"UPDATE Pessoa SET Telefone = '{novoTelefone}' WHERE Cpf = '{cpfDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Telefone alterado com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 5:
                    Console.WriteLine("Informe os dados do novo endereço");
                    Console.Write("Informe o logradouro da pessoa: ");
                    string novoLogradouro = Console.ReadLine().ToUpper();

                    Console.Write("Informe o numero da casa da pessoa: ");
                    int novoNumero = int.Parse(Console.ReadLine());

                    Console.Write("Informe o bairro da pessoa: ");
                    string novoBairro = Console.ReadLine().ToUpper();

                    Console.Write("Informe a cidade da pessoa: ");
                    string novaCidade = Console.ReadLine().ToUpper();

                    Console.Write("Informe o estado da pessoa: ");
                    string novoEstado = Console.ReadLine().ToUpper();

                    Console.Write("Informe o cep da pessoa: ");
                    string novoCep = Console.ReadLine().Replace("-", "");

                    cmd.CommandText = $"UPDATE Pessoa SET Logradouro = '{novoLogradouro}', Numero = '{novoNumero}', Bairro = '{novoBairro}', Cidade = '{novaCidade}', Estado = '{novoEstado}', Cep = '{novoCep}' WHERE Cpf = '{cpfDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Endereço alterado com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                default:
                    Console.Write("\n Opcao Inválida! Aperte [ENTER] para executar novamente.");
                    Console.ReadKey();
                    break;
            }
            return pessoa;
        }
        #endregion

        #region CRUD sem DELETE - ANIMAL
        //public Animal InserirAnimalBanco()
        //{
        //    int count = 0;
        //    Animal animal = new Animal();

        //    animal.CadastraAnimal();

        //    ONGServices conn = new ONGServices();
        //    SqlConnection conexaosql = new SqlConnection(conn.Caminho());
        //    conexaosql.Open();

        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandText = $"INSERT INTO Animal(Familia, Raca, Sexo, Nome_Ani)" + $"VALUES ('{animal.Familia}','{animal.Raca}','{animal.Sexo}','{animal.Nome}')";

        //    cmd.Connection = conexaosql;
        //    cmd.ExecuteNonQuery();

        //    conexaosql.Close();

        //    conexaosql.Open();

        //    cmd = new SqlCommand();
        //    cmd.CommandText = "SELECT * FROM Animal";

        //    cmd.Connection = conexaosql;

        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                count++;
        //            }
        //        }
        //    }

        //    cmd = new SqlCommand("INSERT INTO AnimaisDisponiveis VALUES (@Chip);", conexaosql);
        //    cmd.Parameters.Add(new SqlParameter("@Chip", count));

        //    cmd.ExecuteNonQuery();

        //    conexaosql.Close();

        //    Console.WriteLine("Cadastro concluído\n");
        //    Console.WriteLine("\nProcesso Finalizado!\nPressione [Enter] para continuar...");
        //    Console.ReadKey();
        //    return animal;
        //}

        public Animal SelecionarAnimaisBanco()
        {
            Animal animal = new Animal();

            ONGServices conn = new ONGServices();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Chip, Familia, Raca, Sexo, Nome_Ani FROM Animal";

            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("ANIMAIS CADASTRADOS:\n");
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
                    Console.WriteLine("{0}", reader.GetString(3));
                    Console.WriteLine("{0}", reader.GetString(4));
                    Console.WriteLine("\n----------------------------\n");
                }
            }
            conexaosql.Close();
            Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
            Console.ReadKey();
            return animal;
        }

        public Animal AtualizarAnimalBanco()
        {
            int count = 0;
            Animal animal = new Animal();
            SqlCommand cmd = new SqlCommand();
            ONGServices conn = new ONGServices();
            SqlConnection conexaoSql = new SqlConnection(conn.Caminho());

            Console.Write("Informe o CHIP que deseja atualizar: ");
            string chipDigitado = Console.ReadLine();

            conexaoSql.Open();

            cmd = new();

            cmd.CommandText = $"SELECT * FROM Animal where Chip = '{chipDigitado}'";
            cmd.Connection = conexaoSql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("CHIP digitado não localizado!");
                Console.ReadKey();
                return animal;
            }

            int opcao = 0;
            do
            {
                Console.WriteLine("Informe a opcao que deseja alterar: ");
                Console.WriteLine(" 1 - Familia");
                Console.WriteLine(" 2 - Raça");
                Console.WriteLine(" 3 - Sexo");
                Console.WriteLine(" 4 - Nome do animal");
                Console.Write(" Informe a opcao: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

            } while (opcao < 1 || opcao > 4);

            switch (opcao)
            {
                case 1:
                    Console.Write("Informe a nova familia: ");
                    string novaFamilia = Console.ReadLine().ToUpper();

                    cmd.CommandText = $"UPDATE Animal SET Familia = '{novaFamilia}' WHERE Chip = '{chipDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Familia alterada com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Write("Informe a nova raça: ");
                    string novaRaca = Console.ReadLine().ToUpper();

                    cmd.CommandText = $"UPDATE Animal SET Raca = '{novaRaca}' WHERE Chip = '{chipDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Raca alterado com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Write("Informe o novo sexo: ");
                    char novoSexo = char.Parse(Console.ReadLine().ToUpper());

                    cmd.CommandText = $"UPDATE Animal SET Sexo = '{novoSexo}' WHERE Chip = '{chipDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Sexo alterado com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Write("Informe o novo nome: ");
                    string novoNome = Console.ReadLine().ToUpper();

                    cmd.CommandText = $"UPDATE Animal SET Nome_Ani = '{novoNome}' WHERE Chip = '{chipDigitado}'";
                    cmd.Connection = conexaoSql;

                    cmd.ExecuteNonQuery();
                    conexaoSql.Close();
                    Console.WriteLine("Nome alterado com secesso!");
                    Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
                    Console.ReadKey();
                    break;

                default:
                    Console.Write("\n Opcao Inválida! Aperte [ENTER] para executar novamente.");
                    Console.ReadKey();
                    break;
            }
            return animal;
        }
        #endregion

        #region ADOÇÃO
        public Animal AdotarAnimal()
        {
            int count = 0;
            Animal pessoa = new Animal();
            SqlCommand cmd = new SqlCommand();

            ONGServices conn = new ONGServices();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            Console.Write("informe o CPF da pessoa que ira adotar: ");
            string cpfAdotante = Console.ReadLine();

            cmd = new();

            cmd.CommandText = $"SELECT * FROM Pessoa where Cpf = '{cpfAdotante}'";
            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("CPF digitado não cadastrado!");
                Console.ReadKey();
                conexaosql.Close();
                return pessoa;
            }
            conexaosql.Close();

            conexaosql.Open();
            count = 0;

            Console.Write("informe o CHIP do animal que ira ser adotado: ");
            string chipAdotado = Console.ReadLine();

            cmd = new();

            cmd.CommandText = $"SELECT * FROM AnimaisDisponiveis where Chip = '{chipAdotado}'";
            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                Console.WriteLine("CHIP digitado não cadastrado!");
                Console.ReadKey();
                conexaosql.Close();
                return pessoa;
            }
            conexaosql.Close();

            conexaosql.Open();

            cmd = new();

            cmd.CommandText = $"INSERT INTO Adocao(Cpf, Chip)" + $"VALUES ('{cpfAdotante}','{chipAdotado}')";
            cmd.Connection = conexaosql;

            cmd.ExecuteNonQuery();

            cmd = new($"DELETE FROM AnimaisDisponiveis where Chip = '{chipAdotado}'", conexaosql);

            cmd.ExecuteNonQuery();

            conexaosql.Close();

            Console.WriteLine("Adoção concluida!\n");
            Console.WriteLine("\nProcesso Finalizado!\nPressione [Enter] para continuar...");
            Console.ReadKey();
            return pessoa;
        }

        public Animal SelecionarAnimaisAdotadosBanco()
        {
            Animal animal = new Animal();

            ONGServices conn = new ONGServices();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cpf, Chip FROM Adocao";

            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("ADOÇÕES:\n");
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetString(0));
                    Console.WriteLine("{0}", reader.GetInt32(1));
                    Console.WriteLine("\n-------------------------------\n");
                }
            }
            conexaosql.Close();
            Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
            Console.ReadKey();
            return animal;
        }

        public Animal SelecionarAnimaisDisponiveisBanco()
        {
            Animal animal = new Animal();

            ONGServices conn = new ONGServices();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Chip FROM AnimaisDisponiveis";

            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("ANIMAIS DISPONIVEIS PARA ADOÇÃO:\n");
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("\n-------------------------------\n");
                }
            }
            conexaosql.Close();
            Console.WriteLine("\n\nProcesso Finalizado!\nPressione [Enter] para continuar...");
            Console.ReadKey();
            return animal;
        }
        #endregion
    }
}
