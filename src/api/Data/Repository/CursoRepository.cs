using Dapper;
using Data.Interface;
using Domain.ViewModel;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private string connectionString = @"Data Source=DESKTOP-I788LKG\SQLEXPRESS;Initial Catalog=ESCOLA;Integrated Security=True";
        public async Task<bool> ExisteCurso(string Nome)
        {
            #region query
            const string query = @"SELECT COUNT(*) FROM Curso c WITH(NOLOCK)
                                    WHERE c.Nome = @Nome";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<bool>(query, new { Nome });
            }
        }

        public async Task<IEnumerable<CursoViewModel>> ListarCursosAsync()
        {
            #region query
            const string query = @"
            SELECT * FROM Curso c WITH(NOLOCK) WHERE c.Ativo = 1 ";

            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<CursoViewModel>(query, new {});
            }
        }

        public async Task<int> PostAsync(string Nome, bool Ativo)
        {
            #region query
            int cursoId = 0;
            const string query = @"
            INSERT INTO [dbo].[Curso]
                  ([Nome]
                  ,[Ativo])
            OUTPUT INSERTED.CursoId
            VALUES
                  (@Nome,@Ativo)
 ";

            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cursoId = await connection.ExecuteScalarAsync<int>(query, new { Nome, Ativo });
                return cursoId;
            }
        }
    }
}
