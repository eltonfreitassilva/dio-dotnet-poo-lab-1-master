using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Bank.Classes
{
    public class Cliente
    {
        public Cliente(string nome,string sobrenome,string cpfCnpj)
        {


        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string cpfCnpj { get; private set; }

        public string NomeCompleto
        {
            get
            {

                return this.Nome + ' ' + this.Sobrenome;
            }
        }

    }
}
