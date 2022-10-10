using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Model
{
    public class Pessoa
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string TelefoneContato { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }


        public Pessoa()
        {
        }

        public Pessoa(string cpf, string nome, char sexo, string dataNascimento, string telefoneContato, string logradouro, int numero, string bairro, string cidade, string cep, string estado)
        {
            Cpf = cpf;
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            TelefoneContato = telefoneContato;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Estado = estado;
        }

        public void CadastraPessoa()
        {
            Console.Write("Informe o CPF da pessoa (11 digitos): ");
            Cpf = Console.ReadLine().ToUpper();

            Console.Write("Informe o nome da pessoa: ");
            Nome = Console.ReadLine().ToUpper();

            do
            {
                Console.Write("Informe o sexo da pessoa (M ou F): ");
                Sexo = char.Parse(Console.ReadLine().ToUpper());
            } while (Sexo != 'M' && Sexo != 'F');

            Console.Write("Informe a data de nascimento da pessoa (ddMMyyyy): ");
            DataNascimento = Console.ReadLine().Replace("/", "");

            Console.Write("Informe um telefone para contato com a pessoa: ");
            TelefoneContato = Console.ReadLine().Replace("(", "").Replace(")", "").Replace("-", "");

            Console.Write("Informe o logradouro da pessoa: ");
            Logradouro = Console.ReadLine().ToUpper();

            Console.Write("Informe o numero da casa da pessoa: ");
            Numero = int.Parse(Console.ReadLine());

            Console.Write("Informe o bairro da pessoa: ");
            Bairro = Console.ReadLine().ToUpper();

            Console.Write("Informe a cidade da pessoa: ");
            Cidade = Console.ReadLine().ToUpper();

            Console.Write("Informe o estado da pessoa: ");
            Estado = Console.ReadLine().ToUpper();

            Console.Write("Informe o cep da pessoa: ");
            Cep = Console.ReadLine().Replace("-", "");
        }

        public readonly static string INSERT = "INSERT INTO Pessoa(Cpf, Nome_Pes, Sexo, Data_Nascimento, Telefone, Logradouro, Numero, Bairro, Cidade, Estado, Cep) VALUES (@Cpf,@Nome,@Sexo,@DataNascimento,@TelefoneContato,@Logradouro,@Numero,@Bairro,@Cidade,@Estado,@Cep);";

        public readonly static string SELECT = "SELECT Cpf, Nome_Pes, Sexo, Data_Nascimento, Telefone, Logradouro, Numero, Bairro, Cidade, Estado, Cep FROM Pessoa";

        public override string ToString()
        {
            return $"{Cpf}{Nome}{Sexo}{DataNascimento}{TelefoneContato}{Logradouro}{Numero}{Bairro}{Cidade}{Cep}{Estado}";
        }
    }
}
