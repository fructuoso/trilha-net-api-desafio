using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TrilhaApiDesafio.Tests.Integration.Setup;
using TrilhaApiDesafio.Models;
using System.Net.Http.Json;
using System;

namespace TrilhaApiDesafio.Tests.Integration
{
    public class TarefaControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;
        public TarefaControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact(DisplayName = "Dada uma requisição GET para /Tarefa/1, deve retornar status code 200")]
        public async Task TestObterPorId()
        {
            // Arrange
            const int id = 1;

            // Act
            var response = await _client.GetAsync($"/Tarefa/{id}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }


        [Fact(DisplayName = "Dada uma requisição GET para /Tarefa/ObterTodos, deve retornar status code 200")]
        public async Task TestObterTodos()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/Tarefa/ObterTodos");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Dada uma requisição GET para /Tarefa/ObterPorTitulo, deve retornar status code 200")]
        public async Task TestObterPorTitulo()
        {
            // Arrange
            const string titulo = "Exemplo";

            // Act
            var response = await _client.GetAsync($"/Tarefa/ObterPorTitulo?titulo={titulo}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Dada uma requisição GET para /Tarefa/ObterPorData, deve retornar status code 200")]
        public async Task TestObterPorData()
        {
            // Arrange
            var data = new DateTime(2022, 01, 01);

            // Act
            var response = await _client.GetAsync($"/Tarefa/ObterPorData?data={data:yyyy-MM-dd}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Dada uma requisição GET para /Tarefa/ObterPorStatus, deve retornar status code 200")]
        public async Task TestObterPorStatus()
        {
            // Arrange
            const EnumStatusTarefa status = EnumStatusTarefa.Pendente;

            // Act
            var response = await _client.GetAsync($"/Tarefa/ObterPorStatus?status={status}");
            

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Dada uma requisição POST para /Tarefa, deve retornar status code 201")]
        public async Task TestCriar()
        {
            // Arrange
            var tarefa = new Tarefa() {
                Titulo = "Tarefa A",
                Descricao = "Descrição da tarefa A",
                Data = System.DateTime.Now,
                Status = EnumStatusTarefa.Pendente
            };

            // Act
            var response = await _client.PostAsJsonAsync("/Tarefa", tarefa);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact(DisplayName = "Dada uma requisição PUT para /Tarefa/{id}, deve retornar status code 200")]
        public async Task TestAtualizar()
        {
            // Arrange
            var tarefa = new Tarefa() {
                Titulo = "Tarefa B",
                Descricao = "Descrição da tarefa B",
                Data = System.DateTime.Now.AddDays(2),
                Status = EnumStatusTarefa.Pendente
             };

            // Act
            var response = await _client.PutAsJsonAsync("/Tarefa/1", tarefa);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Dada uma requisição DELETE para /Tarefa/{id}, deve retornar status code 204")]
        public async Task TestDeletar()
        {
            // Arrange
            const int id = 2;

            // Act
            var response = await _client.DeleteAsync($"/Tarefa/{id}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}