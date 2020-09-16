using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TP3.Domain
{
    public class Amigo
    {
        //Cada amigo deve possuir nome, sobrenome, e-mail, telefone e data de aniversário
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Campo Nome é obrigatório.")]
        [StringLength(50, ErrorMessage ="O Campo nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Campo sobrenome deve ter no máximo 50 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Campo email deve ter no máximo 50 caracteres.")]
        [EmailAddress(ErrorMessage = "O Campo email não está em um formato correto")]
        public string Email { get; set; }

        public string Telefone { get; set; }
        
        public DateTime DataDeAniversario { get; set; }

    }
}
