using Refit;
using Repository.Command;
using Repository.Interfaces;
using Repository.ViewModel;
using System.Security.Cryptography;
using System.Text;

namespace Repository.Service
{
    public class UsuarioService
    {
        const string url = "https://localhost:2024/api";

        public async Task<UsuarioViewModel> BuscarUsuario(int UsuarioId)
        {
            var api = RestService.For<IUsuarioService>(url);
            return api.BuscarUsuario(UsuarioId).Result.Data;
        }
        public async Task<UsuarioViewModel> UsuarioLogado(UsuarioCommand command)
        {
            command.Senha = MD5Hash(command.Senha);
            var api = RestService.For<IUsuarioService>(url);
            return api.UsuarioLogado(command).Result.Data;
        }

        public async Task<object> CriarNovoUsuario(InsertUsuarioCommand command)
        {
            command.Senha = MD5Hash(command.Senha);
            string Nome = command.Nome;
            int TipoUsuarioId = (int)command.TipoUsuarioId;
            string NomeUsuario = command.NomeUsuario;
            string Senha = command.Senha;
            bool Ativo = command.Ativo;

            var api = RestService.For<IUsuarioService>(url);
            object obj = api.NovoUsuario(Nome, NomeUsuario, Senha, TipoUsuarioId, Ativo).Result.Data;
            return obj;

        }
        public async Task<object> CriarNovoCurso(CriarCursoCommand command)
        {
            string Nome = command.Nome;
            bool Ativo = command.Ativo;

            var api = RestService.For<IUsuarioService>(url);
            object obj =  api.NovoCurso(Nome, Ativo).Result.Data;
            return obj;

        }
        public async Task<object> CriarNovaTurma(CriarTurmaCommand command)
        {
            string Nome = command.Turma;
            bool Ativo = command.Ativo;
            int CursoId = command.CursoId;
            int Ano = command.Ano;
            var api = RestService.For<IUsuarioService>(url);
            object obj = api.NovoTurma(Nome, Ativo, Ano, CursoId).Result.Data;
            return obj;

        }
        public async Task<IEnumerable<CursoViewModel>> ListarCursos()
        {
            var api = RestService.For<IUsuarioService>(url);
            var r= api.ListarCursos().Result.Data;

            return r.ToList();
        }
        public async Task<IEnumerable<TurmaViewModel>> ListarTurmas()
        {
            var api = RestService.For<IUsuarioService>(url);
            var r = api.ListarTurmas().Result.Data;

            return r.ToList();
        }
        public async Task<UsuarioViewModel> Editar(EditarUsuarioCommand command)
        {
            command.Senha = MD5Hash(command.Senha);
            int UsuarioId = command.UsuarioId;
            string Nome = command.Nome;
            int TipoUsuarioId = (int)command.TipoUsuarioId;
            string NomeUsuario = command.NomeUsuario;
            string Senha = command.Senha;
            bool Ativo = command.Ativo;
            var api = RestService.For<IUsuarioService>(url);
            return api.Editar(UsuarioId, Nome, NomeUsuario, Senha, TipoUsuarioId, Ativo).Result.Data;
        }
        public async Task<UsuarioViewModel> InativarAtivar(int Id, bool Ativo)
        {
            var api = RestService.For<IUsuarioService>(url);
            return api.InativarAtivar(Id, Ativo).Result.Data;
        }

        private static string MD5Hash(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(senha));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            string hash = strBuilder.ToString();
            return hash;
        }
    }
}
