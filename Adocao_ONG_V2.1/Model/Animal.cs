﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Model
{
    public class Animal
    {
        public string Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }

        public Animal()
        {
        }

        public Animal(string familia, string raca, char sexo, string nome)
        {
            Familia = familia;
            Raca = raca;
            Sexo = sexo;
            Nome = nome;
        }

        public void CadastraAnimal()
        {
            Console.Write("Informe a familia do animal: ");
            Familia = Console.ReadLine().ToUpper();

            Console.Write("Informe a raça do animal: ");
            Raca = Console.ReadLine().ToUpper();

            do
            {
                Console.Write("Informe o sexo do animal (M ou F): ");
                Sexo = char.Parse(Console.ReadLine().ToUpper());
            } while (Sexo != 'M' && Sexo != 'F');

            Console.Write("Digite [S] se o animal for receber um nome, se não digite qualquer coisa: ");
            string resposta = Console.ReadLine().ToUpper();
            if (resposta == "S")
            {
                Console.Write("Informe o nome do animal: ");
                Nome = Console.ReadLine().ToUpper();
            }
            else
                Nome = "";
        }

        public readonly static string INSERT = "INSERT INTO Animal(Familia, Raca, Sexo, Nome_Ani) VALUES (@Familia,@Raca,@Sexo,@Nome);";

        public readonly static string SELECT = "SELECT * FROM Animal";

        public override string ToString()
        {
            return $"{Familia}{Raca}{Sexo}{Nome}";
        }
    }
}
