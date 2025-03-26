namespace Ambev.GestaoFuncionarios.ORM.Queries
{
    public static class FuncionarioSql
    {
        public const string Create = @"
        INSERT INTO funcionarios (id, nome, sobrenome, documento, email, telefone, nome_gestor, data_nascimento, is_gestor, data_criacao, data_atualizacao, id_gestor)
        VALUES (@Id, @Nome, @Sobrenome, @Documento, @Email, @Telefone, @NomeGestor, @DataNascimento, @IsGestor, @DataCriacao, @DataAtualizacao, @IdGestor);";

        public const string Update = @"
        UPDATE funcionarios
        SET nome = @Nome,
            sobrenome = @Sobrenome,
            documento = @Documento,
            email = @Email,
            telefone = @Telefone,
            nome_gestor = @NomeGestor,
            data_nascimento = @DataNascimento,
            is_gestor = @IsGestor,
            data_atualizacao = @DataAtualizacao,
            id_gestor = @IdGestor
        WHERE id = @Id";

        public const string Delete = @"
        DELETE 
        FROM funcionarios 
        WHERE id = @Id";

        public const string GetById = @"
        SELECT 
            id,
            nome, 
            sobrenome, 
            documento,
            email,
            telefone,
            nome_gestor as NomeGestor,
            data_nascimento as DataNascimento,
            is_gestor as IsGestor,
            data_criacao as DataCriacao,
            data_atualizacao as DataAtualizacao,
            id_gestor as IdGestor
        FROM funcionarios 
        WHERE id = @Id";

        public const string GetAll = @"
        SELECT 
            id,
            nome, 
            sobrenome, 
            documento,
            email,
            telefone,
            nome_gestor  as NomeGestor,
            data_nascimento as DataNascimento,
            is_gestor as IsGestor,
            data_criacao as DataCriacao,
            data_atualizacao as DataAtualizacao,
            id_gestor as IdGestor
        FROM funcionarios";

        public const string EmailExists = @"
        SELECT 
            COUNT(1) 
        FROM funcionarios 
        WHERE email = @Email";

        public const string DocumentExists = @"
        SELECT 
            COUNT(1) 
        FROM funcionarios 
        WHERE documento = @Documento";

        public const string AndIdDiferent = @" AND id <> @Id";

        public const string WhereIsGestor = " WHERE is_gestor = @IsGestor";
    }
}
