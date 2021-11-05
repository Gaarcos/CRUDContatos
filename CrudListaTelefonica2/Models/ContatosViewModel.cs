using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudListaTelefonica2.Models
{
    public class ContatosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
