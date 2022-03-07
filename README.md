# Cadastro de Caminhões

## Projeto utilizando dotnet 6 dbfirst

### github actions está configurado para rodar testes a cada push

pasta "CadastroCaminhao" contem o projeto

pasta "CadastroCaminhao.Test" contem alguns testes

Para rodar utilize o comando **´dotnet run´** na pasta CadastroCaminhao e abra a url **/swagger**

Para rodar os testes utilize o comando **´dotnet test´** na pasta CadastroCaminhao.Test

Requisito principal

- Como usuário, eu necessito de um cadastro de caminhões, onde eu possa:
- Visualizar os caminhões cadastrados;
  - As propriedades mínimas do caminhão deverão ser:
    - Modelo (Poderá aceitar apenas FH e FM)
    - Ano de Fabricação (Ano deverá ser o atual)
    - Ano Modelo (Poderá ser o atual ou o ano subsequente)
- Atualizar as informações de um caminhão;
- Excluir um caminhão;
- Inserir um novo caminhão.

Requisito secundário

- Poderão existir vários modelos de caminhões.
  - Os modelos permitidos serão somente (FH e FM)

Requisitos técnicos

- Utilizar ASP.NET Core;
- Utilizar base de dados local;
- Utilizar ORM para mapear as tabelas de base de dados
  - Utilizar “Migrations” para criação da base de dados;
  - A criação da base de dados deverá ser automática (sem a necessidade de utilizar algum comando adicional).
- Criar testes unitários (Cobrir ao menos 80% dos fluxos)
