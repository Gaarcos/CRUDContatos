using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudListaTelefonica2.Models;

namespace CrudListaTelefonica2.DAO
{
    public class ContatosDAO
    {
        public void Inserir(ContatosViewModel f)
        {
            string sql =
            "insert into listagemTelefonica(nome, telefone,  endereco)" +
            "values (@nome, @telefone, @endereco)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(f));
        }
        public void Alterar(ContatosViewModel pessoa)
        {
            string sql =
            "update listagemTelefonica set nome = @nome, " +
            "telefone = @telefone, " +
            "endereco = @endereco " +
            "where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(pessoa));
        }
        private SqlParameter[] CriaParametros(ContatosViewModel f)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("id", f.Id);
            parametros[1] = new SqlParameter("nome", f.Nome);
            parametros[2] = new SqlParameter("telefone", f.Telefone);
            parametros[3] = new SqlParameter("endereco", f.Endereco);
            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "delete listagemTelefonica where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
        private ContatosViewModel MontaPessoa(DataRow registro)
        {
            var a = new ContatosViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            a.Telefone = registro["telefone"].ToString();
            a.Endereco = registro["endereco"].ToString();
            return a;
        }
        public ContatosViewModel Consulta(int id)
        {
            string sql = "select * from listagemTelefonica where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaPessoa(tabela.Rows[0]);
        }
        public List<ContatosViewModel> Listagem()
        {
            List<ContatosViewModel> lista = new List<ContatosViewModel>();
            string sql = "select * from listagemTelefonica order by nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaPessoa(registro));
            return lista;
        }
    }
}
