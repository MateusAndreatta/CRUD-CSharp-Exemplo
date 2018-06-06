using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCrud
{
    class Conexao
    {

        public static SqlConnection Conectar()
        {
            string str = "Data Source=localhost;Initial Catalog=CrudBanco_bd;Integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            return conn;
        }
    }
}
