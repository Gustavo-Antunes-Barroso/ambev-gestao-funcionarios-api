using Ambev.GestaoFuncionarios.Domain.Entities;
using Ambev.GestaoFuncionarios.Domain.Repositories;
using Ambev.GestaoFuncionarios.ORM.Context;
using Ambev.GestaoFuncionarios.ORM.Queries;
using Dapper;

namespace Ambev.GestaoFuncionarios.ORM.Repositories
{
    public class FuncionarioRepository(DapperContext context) : IFuncionarioRepository
    {
        private readonly DapperContext _context = context;

        public async Task<Funcionario> CreateAsync(Funcionario funcionario)
        {
            await _context.CreateConnection().ExecuteAsync(FuncionarioSql.Create, funcionario);
            return funcionario;
        }

        public async Task UpdateAsync(Funcionario funcionario)
        {
            await _context.CreateConnection().ExecuteAsync(FuncionarioSql.Update, funcionario);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.CreateConnection().ExecuteAsync(FuncionarioSql.Delete, new { Id = id });
        }

        public async Task<Funcionario?> GetByIdAsync(Guid id)
        {
            return await _context.CreateConnection().QueryFirstOrDefaultAsync<Funcionario>(FuncionarioSql.GetById, new { Id = id });
        }

        public async Task<IEnumerable<Funcionario>> GetAllAsync(bool? isGestor = null)
        {
            string sql = FuncionarioSql.GetAll;

            if (isGestor.HasValue && isGestor.Value)
                sql += FuncionarioSql.WhereIsGestor;

            return await _context.CreateConnection().QueryAsync<Funcionario>(sql, new { IsGestor = isGestor });
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.CreateConnection().QueryFirstOrDefaultAsync<bool>(FuncionarioSql.EmailExists, new { Email = email });
        }

        public async Task<bool> EmailExistsAsync(Guid id, string email)
        {
            string sql = $"{FuncionarioSql.EmailExists}{FuncionarioSql.AndIdDiferent}";
            return await _context.CreateConnection().QueryFirstOrDefaultAsync<bool>(sql, new { Id = id, Email = email });
        }

        public async Task<bool> DocumentExistsAsync(string document)
        {
            return await _context.CreateConnection().QueryFirstOrDefaultAsync<bool>(FuncionarioSql.DocumentExists, new { Documento = document });
        }

        public async Task<bool> DocumentExistsAsync(Guid id, string document)
        {
            string sql = $"{FuncionarioSql.DocumentExists}{FuncionarioSql.AndIdDiferent}";
            return await _context.CreateConnection().QueryFirstOrDefaultAsync<bool>(sql, new { Id = id, Documento = document });
        }
    }
}
