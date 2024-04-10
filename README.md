# DIO - Trilha .NET - API e Entity Framework
www.dio.me

## Notas do Fructuoso sobre o Fork

Este repositório é um *fork* do projeto original [digitalinnovationone/trilha-net-api-desafio](https://github.com/digitalinnovationone/trilha-net-api-desafio), adaptado especificamente para a mentoria **A Jornada do GitHub Actions: Descubra o Caminho para a Qualidade de Código**. Esta sessão de mentoria está agendada para o dia 6 de Maio de 2024, e tem como objetivo explorar práticas avançadas de CI/CD utilizando o GitHub Actions.

### Modificações Realizadas:
Para assegurar que o repositório esteja plenamente operacional para nossa demonstração, implementamos a seguinte alteração crítica:

- **Atualização do Entity Framework:** Para simplificar a execução e tornar o ambiente de demonstração mais acessível, modificamos a configuração do Entity Framework para utilizar um banco de dados InMemory, eliminando a necessidade de um SQL Server externo.

Agradeço seu interesse e apoio à minha mentoria. Espero que as modificações e o conteúdo demonstrado possam servir como um recurso valioso para sua jornada de aprendizado em desenvolvimento de software e automação de CI/CD.


## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de API e Entity Framework, da trilha .NET da DIO.

## Contexto
Você precisa construir um sistema gerenciador de tarefas, onde você poderá cadastrar uma lista de tarefas que permitirá organizar melhor a sua rotina.

Essa lista de tarefas precisa ter um CRUD, ou seja, deverá permitir a você obter os registros, criar, salvar e deletar esses registros.

A sua aplicação deverá ser do tipo Web API ou MVC, fique a vontade para implementar a solução que achar mais adequado.

A sua classe principal, a classe de tarefa, deve ser a seguinte:

![Diagrama da classe Tarefa](diagrama.png)

Não se esqueça de gerar a sua migration para atualização no banco de dados.

## Métodos esperados
É esperado que você crie o seus métodos conforme a seguir:


**Swagger**


![Métodos Swagger](swagger.png)


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |

Esse é o schema (model) de Tarefa, utilizado para passar para os métodos que exigirem

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
```


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.


## Como Executar (VS Code)

Para executar essa aplicação no terminal basta executar o comando abaixo:

```bash
dotnet run TrilhaApiDesafio.csproj
```