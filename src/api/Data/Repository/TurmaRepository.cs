using Dapper;
using Data.Interface;
using Domain.ViewModel;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private string connectionString = @"Data Source=DESKTOP-I788LKG\SQLEXPRESS;Initial Catalog=ESCOLA;Integrated Security=True";
        public async Task<bool> ExisteTurma(string Nome)
        {
            #region query
            const string query = @"SELECT COUNT(*) FROM Turma c WITH(NOLOCK)
                                    WHERE c.Turma = @Nome";
            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.ExecuteScalarAsync<bool>(query, new { Nome });
            }
        }

        public async Task<IEnumerable<TurmaViewModel>> ListarTurmasAsync()
        {
            #region query
            const string query = @"
            SELECT * FROM Turma t WITH(NOLOCK) WHERE t.Ativo = 1 ";

            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<TurmaViewModel>(query, new { });
            }
        }

        public async Task<int> PostAsync(string Nome, bool Ativo, int Ano, int CursoId)
        {
            #region query
            int TurmaId = 0;
            const string query = @"
        INSERT INTO [dbo].[TURMA]
           ([CursoId]
           ,[Turma]
           ,[Ano]
           ,[Ativo])
     OUTPUT INSERTED.TurmaId
     VALUES
           (@CursoId
           ,@Turma
           ,@Ano
           ,@Ativo 

 ";

            #endregion
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                TurmaId = await connection.ExecuteScalarAsync<int>(query, new { Turma = Nome, Ativo = Ativo, Ano = Ano, CursoId = CursoId });
                return TurmaId;
            }
        }
    }
}

