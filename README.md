# VagaFiap
Projeto Vaga Fiap

#Para Executar sem erros, peço que entre nos 3 repositories e troca a string de conexão aprontando para instância que vão criar a base;

Scripts

# Antes de executar o projeto, abra uma instância no Microsoft SQL Management Studio
# Execute o script para criar as tabelas

CREATE DATABASE ESCOLA
GO

USE ESCOLA
GO


GO
PRINT N'Criando Tabela Usuario'
CREATE TABLE [ESCOLA].[dbo].[Usuario](
   UsuarioId INT PRIMARY KEY IDENTITY(1,1),
   TipoUsuarioId INT NOT NULL,
   Usuario VARCHAR(255) NOT NULL,
   Senha VARCHAR(60) NOT NULL,
   Ativo BIT NOT NULL
)

GO
PRINT N'Criando Tabela Pessoa'
CREATE TABLE [ESCOLA].[dbo].[Pessoa](
   PessoaId INT PRIMARY KEY IDENTITY(1,1),
   UsuarioId INT NOT NULL,
   Nome VARCHAR(255) NOT NULL,
)

GO
PRINT N'Criando Tabela Curso'
CREATE TABLE [ESCOLA].[dbo].[Curso](
   CursoId INT PRIMARY KEY IDENTITY(1,1),
   Nome VARCHAR(255) NOT NULL,
   Ativo BIT NOT NULL,
)

GO
PRINT N'Criando Tabela Turma'
CREATE TABLE [ESCOLA].[dbo].[TURMA](
  TurmaId INT PRIMARY KEY IDENTITY(1,1),
  CursoId INT NOT NULL,
  Turma VARCHAR(45) NOT NULL,
  Ano INT NOT NULL,
  Ativo BIT NOT NULL
)

GO
PRINT N'Criando Tabela AlunoTurma'
CREATE TABLE [ESCOLA].[dbo].[AlunoTurma](
   AlunoTurmaId INT PRIMARY KEY IDENTITY(1,1),
   UsuarioId INT NOT NULL,
   TurmaId INT NOT NULL
)

GO
PRINT N'Criando Foreign Key Tabela Pessoa'

GO
ALTER TABLE [ESCOLA].[dbo].[Pessoa]
ADD CONSTRAINT [FK_Pessoa_Usuario] FOREIGN KEY
([UsuarioId]) REFERENCES USUARIO ([UsuarioId])


GO
PRINT N'Criando Foreign Key Tabela Turma'

GO
ALTER TABLE [ESCOLA].[dbo].[Turma]
ADD CONSTRAINT [FK_Turma_Curso] FOREIGN KEY
([TurmaId]) REFERENCES Turma ([TurmaId])


GO
PRINT N'Criando Foreign Key Tabela AlunoTurma'

GO
ALTER TABLE [ESCOLA].[dbo].[AlunoTurma]
ADD CONSTRAINT [FK_AlunoTurma_Usuario] FOREIGN KEY
([UsuarioId]) REFERENCES Usuario ([UsuarioId])

GO
ALTER TABLE [ESCOLA].[dbo].[AlunoTurma]
ADD CONSTRAINT [FK_AlunoTurma_Turma] FOREIGN KEY
([TurmaId]) REFERENCES Turma ([TurmaId])

# se desejar pode executar o script de insert para fazer select nas tabelas criadas
# Importante se atentar para cada Id
USE ESCOLA
GO

INSERT Usuario(Usuario, Senha, TipoUsuarioId, Ativo)
Values('User1', 'e7d80ffeefa212b7c5c55700e4f7193e', 1, 1)
SELECT * FROM [ESCOLA].[dbo].Usuario] WITH (NOLOCK)


INSERT INTO Pessoa(Nome,UsuarioId)
VALUES('User teste', 1)
SELECT * FROM [ESCOLA].[dbo].[Pessoa] WITH (NOLOCK)

INSERT INTO [ESCOLA].[dbo].[Curso](Nome, Ativo)
VALUES ('PEDAGOGIA', 1)
SELECT * FROM [ESCOLA].[dbo].[Curso] WITH (NOLOCK)

INSERT INTO [ESCOLA].[dbo].[TURMA](Turma,CursoId, Ano, Ativo)
VALUES ('PEDAGOGIA', 1, 2023, 1)
SELECT * FROM [ESCOLA].[dbo].TURMA WITH (NOLOCK)

INSERT INTO [ESCOLA].[dbo].[AlunoTurma](TurmaId, UsuarioId)
VALUES(1, 1)
SELECT * FROM [ESCOLA].[dbo].[AlunoTurma] WITH (NOLOCK)
