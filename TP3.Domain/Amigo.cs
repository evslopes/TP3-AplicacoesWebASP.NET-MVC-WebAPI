using System;
using System.Collections.Generic;
using System.Text;

namespace TP3.Domain
{
    public class Amigo
    {
        //Cada amigo deve possuir nome, sobrenome, e-mail, telefone e data de aniversário
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeAniversario { get; set; }

    }
}
