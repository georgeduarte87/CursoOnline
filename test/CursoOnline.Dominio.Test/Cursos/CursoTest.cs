using System;
using Xunit;
using ExpectedObjects;
using CursoOnline.Dominio.Test._Util;
using Xunit.Abstractions;
using CursoOnline.Dominio.Test._Builders;
using Bogus;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly decimal _valor;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor sendo executado");
            var faker = new Faker();

            _nome = faker.Random.Words(3);
            _cargaHoraria = faker.Random.Double(50,1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Decimal(100,1000);
            _descricao = faker.Lorem.Paragraph();
      
            //_output.WriteLine($"Double: {faker.Random.Double(0,100)}");
            //_output.WriteLine($"Company: {faker.Company.CompanyName()}");
            //_output.WriteLine($"Email: {faker.Person.Email}");
        }

        [Fact(DisplayName = "Deve Criar Curso")]
        public void DeveCriarCurso()
        {
            // Arrange
            //string nome = "Informatica Básica";
            //double cargaHoraria = 80;
            //string publicoAlvo = "Estudante";
            //decimal valor = 950;

            //var cursoEsperado = new
            //{
            //    Nome = "Informatica Básica",
            //    CargaHoraria = (double)80,
            //    PublicoAlvo = PublicoAlvo.Estudante,
            //    Valor = (decimal)950
            //};

            var cursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
            };


            // ACT
            //var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            // Assert
            //Assert.Equal(nome, curso.Nome);
            //Assert.Equal(cargaHoraria, curso.CargaHoraria);
            //Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            //Assert.Equal(valor, curso.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }


        [Fact(DisplayName = "Não Aceitar Nome Vazio")]
        public void NaoDeveCursoTerNomeVazio()
        {
            /*
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(string.Empty, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)); */

            /*
            Assert.Throws<ArgumentException>(() =>
                new Curso(string.Empty, _descricao, _cargaHoraria, _publicoAlvo, _valor));*/

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(string.Empty).Build());
        }

        [Fact(DisplayName = "Não Aceitar Nome Nulo")]
        public void NaoDeveCursoTerNomeNulo()
        { /*
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            }; */

            /*
            Assert.Throws<ArgumentException>(() =>
                new Curso(null, _descricao, _cargaHoraria, _publicoAlvo, _valor));*/

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(null).Build());
        }

        [Theory(DisplayName = "Não Aceitar Nomes Inválidos")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {   /*
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };*/

            /*
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Nome Inválido.", message); */

            /*
            Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, _descricao, _cargaHoraria, _publicoAlvo, _valor))
                .ComMensagem("Nome Inválido."); */

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome Inválido.");
        }

        [Theory(DisplayName = "Não Aceitar Carga Horária Menor Que 1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {   /*
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };*/

            /*
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Carga Horário Inválida.", message);*/

            /*
            Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, _descricao, cargaHorariaInvalida, _publicoAlvo, _valor))
                .ComMensagem("Carga Horário Inválida."); */

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga Horário Inválida.");
        }

        [Theory(DisplayName = "Não Aceitar Valor Menor Que 1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerValorMenorQue1(decimal valorInvalido)
        {   /*
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };*/

            /*
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .Message;

            Assert.Equal("Valor Inválido.", message);*/

            /*
            Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, valorInvalido))
                .ComMensagem("Valor Inválido."); */

            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor Inválido.");
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }
    }
}
