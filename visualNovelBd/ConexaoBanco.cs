using System.Data.SqlClient;

namespace visualNovel
{
    public static class ConexaoBanco
    {
        public static int telaUsuario;
        public static int id;
        private static SqlConnection cnn;
        public static string iniciarConexao()
        {
            try
            {
                const string PATH = "PATH_TO_DB\\visualNovelBd\\visualNovelDB.mdf";
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='" + PATH + "'";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                return "Banco de dados conectado";
            }
            catch (SqlException erro)
            {
                return "Erro: " + erro;
            }

        }

        public static string fecharConexao()
        {
            try
            {
                cnn.Close();
                return "Banco de dados desconectado";
            }
            catch (SqlException erro)
            {
                return "Erro: " + erro;
            }
        }

        public static bool validaUsuario(string nomeUsuario, string senha)
        {
            string sql = "SELECT ID, NUMERO_TELA FROM dbo.USUARIO WHERE LOGIN='" + nomeUsuario + "' AND SENHA='" + senha + "';";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            bool existeUsuario = dataReader.Read();
            if (existeUsuario)
            {
                id = dataReader.GetInt32(0);
                telaUsuario = dataReader.GetInt32(1);
            }
            dataReader.Close();
            command.Dispose();
            return existeUsuario;
        }

        public static string cadastrarUsuario(string usuario, string senha, string email)
        {
            try
            {
                if (verificaSeUsuarioExiste(usuario))
                {
                    return "Usuário já cadastrado";
                }
                string sql = "INSERT INTO dbo.USUARIO VALUES ('" + usuario + "', '" + senha + "', '" + email + "', '0');";
                SqlCommand command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                command.Dispose();
                return "Usuário cadastrado com sucesso!";
            }
            catch (SqlException erro)
            {
                return "Erro: " + erro;
            }
        }

        private static bool verificaSeUsuarioExiste(string usuario)
        {
            string sql = "SELECT * FROM dbo.USUARIO WHERE LOGIN='" + usuario + "';";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            bool existeUsuario = dataReader.Read();
            dataReader.Close();
            command.Dispose();
            return existeUsuario;
        }

        public static string buscarTelaBanco()
        {
            string fala = "";
            string sql = "SELECT FALA FROM dbo.DIALOGO WHERE NUMERO_TELA='" + telaUsuario + "';";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            bool existeFala = dataReader.Read();
            if (existeFala)
            {
                fala = dataReader.GetString(0);
            }
            dataReader.Close();
            command.Dispose();
            return fala;
        }

        public static void salvaTelaBanco()
        {
            string sql = "UPDATE dbo.USUARIO SET NUMERO_TELA='" + telaUsuario +"' WHERE ID='" + id + "';";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader = command.ExecuteReader();
            dataReader.Close();
            command.Dispose();
        }
    }
}
