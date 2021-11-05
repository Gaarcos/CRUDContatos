using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudListaTelefonica2.Models
{

    public class ErrorViewModel
    {
        public ErrorViewModel(string erro)
        {
            this.Erro = erro;
        }
        public ErrorViewModel()
        {
        }
        public string Erro { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

