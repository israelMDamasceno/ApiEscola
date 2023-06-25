using Dapper;
using Data.Interface;
using Domain.Command;
using Domain.ViewModel;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string connectionString = @"Data Source=DESKTOP-I788LKG\SQLEXPRESS;Initial Catalog=ESCOLA;Integrated Security=True";
        public async Task<UsuarioViewModel> GetBuscarUsuarioLogado(UsuarioCommand command)
        {
            #region query
            const string query = @"SELECT 
                                   u.Ativo,
                                   u.Usuario NomeUsuario,
                                   u.TipoUsuarioId,
                                   u.UsuarioId,
                                   p.Nome,
                                   p.PessoaId
                                   FROM [ESCOLA].[DBO].[Usuario] u WITH(NOLOCK)
                                   JOIN [ESCOLA].[DBO].[Pessoa] p WITH(NOLOCK) ON u.UsuarioId = p.UsuarioId
                                   WHERE 
                                   u.Usuario = @Usuario 
                                   AND u.Senha = @Senha";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<UsuarioViewModel>(query, new { Usuario = command.NomeUsuario, Senha = command.Senha });
            }
        }

        public async Task<UsuarioViewModel> GetBuscarUsuario(int UsuarioId)
        {
            #region query
            const string query = @"SELECT 
                                   u.Ativo,
                                   u.Usuario NomeUsuario,
                                   u.TipoUsuarioId,
                                   u.UsuarioId,
                                   p.Nome,
                                   p.PessoaId
                                   FROM [ESCOLA].[DBO].[Usuario] u WITH(NOLOCK)
                                   JOIN [ESCOLA].[DBO].[Pessoa] p WITH(NOLOCK) ON u.UsuarioId = p.UsuarioId
                                   WHERE 
                                   u.UsuarioId = @UsuarioId";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<UsuarioViewModel>(query, new { UsuarioId });
            }
        }

        public async Task<int> PostAsync(InsertUsuarioCommand command)
        {
            #region query
            int userId = 0;
            const string query = @"
                                    INSERT INTO Usuario(Usuario, TipoUsuarioId,Ativo, Senha)
                                    OUTPUT INSERTED.UsuarioId
                                    VALUES(@NomeUsuario, @TipoUsuarioId,@Ativo, @Senha)
                                    ";

            const string queryInsertPessoa = @"INSERT INTO Pessoa(Nome, UsuarioId)
                                               OUTPUT INSERTED.PessoaId
                                                VALUES(@Nome, @UsuarioId)
                     ";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                userId = await connection.ExecuteScalarAsync<int>(query, new { NomeUsuario = command.NomeUsuario, Senha = command.Senha, Ativo = command.Ativo, TipoUsuarioId = command.TipoUsuarioId });
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<int>(queryInsertPessoa, new { Nome = command.Nome, UsuarioId = userId });
            }

        }

        public async Task<int> PutAsync(EditarUsuarioCommand command)
        {
            #region query
            const string query = @"UPDATE [dbo].[Usuario]
   SET [Usuario] = @NomeUsuario
      ,[Senha] = @Senha 
WHERE [UsuarioId] = @UsuarioId


UPDATE [dbo].[Pessoa]
   SET [Nome] = @Nome
 WHERE [UsuarioId] = @UsuarioId


";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<int>(query, new { NomeUsuario = command.NomeUsuario, Senha = command.Senha, Nome = command.Nome, UsuarioId = command.UsuarioId });
            }
        }

        public Task<int> PutAtivarInativarAsync(int id, bool Ativo)
        {
            #region query
            const string query = @"";
            #endregion
            throw new NotImplementedException();
        }
        public async Task<bool> ExisteNome(string nome)
        {
            #region query
            const string query = @"SELECT COUNT(*) FROM Pessoa p WITH(NOLOCK)
                                    WHERE p.Nome = @Nome";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<bool>(query, new { Nome = nome });
            }
        }
        public async Task<bool> ExisteUsuario(string Usuario)
        {
            #region query
            const string query = @"SELECT Count(*) FROM Usuario u WITH(NOLOCK)
                                   WHERE u.Usuario = @Usuario";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<bool>(query, new { Usuario });
            }
        }
    }
}
