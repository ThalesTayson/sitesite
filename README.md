# Projeto ASPNET

## Projeto feito com conexao SQL SERVER

### Funcionalidades

- [x] Lista de clientes
- [x] Cadastro de Cliente
- [x] Atualização de dados de Cliente
- [x] Remoção de Cliente

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[.NET](https://dotnet.microsoft.com/en-us/download), [SQL EXPRESS](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

### 🎲 Rodando projeto no localhost

```bash
# Clone este repositório
$ git clone https://github.com/ThalesTayson/sitesite.git

# Acesse a pasta do projeto no terminal
$ cd sitesite

# Adicione o pacote Microsoft.Data.SqlClient -- DEPENDÊNCIA
$ dotnet add package Microsoft.Data.SqlClient --version 5.0.0

# Execute a aplicação em modo de desenvolvimento
$ dotnet run
