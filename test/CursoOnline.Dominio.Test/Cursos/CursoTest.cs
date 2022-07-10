using System;
using Xunit;
using ExpectedObjects;
using CursoOnline.Dominio.Test._Util;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest
    {
        [Fact(DisplayName = "Deve Criar Curso")]
        public void DeveCriarCurso()
        {
            // Arrange
            //string nome = "Informatica Básica";
            //double cargaHoraria = 80;
            //string publicoAlvo = "Estudante";
            //decimal valor = 950;

            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            // ACT
            //var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

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
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(string.Empty, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor));
        }

        [Fact(DisplayName = "Não Aceitar Nome Nulo")]
        public void NaoDeveCursoTerNomeNulo()
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(null, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor));
        }

        [Theory(DisplayName = "Não Aceitar Nomes Inválidos")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            /*
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Nome Inválido.", message); */

            Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Nome Inválido.");
        }

        [Theory(DisplayName = "Não Aceitar Carga Horária Menor Que 1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            /*
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Carga Horário Inválida.", message);*/

            Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Carga Horário Inválida.");
        }

        [Theory(DisplayName = "Não Aceitar Valor Menor Que 1")]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerValorMenorQue1(decimal valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (decimal)950
            };

            /*
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .Message;

            Assert.Equal("Valor Inválido.", message);*/

            Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .ComMensagem("Valor Inválido.");
        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido.");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horário Inválida.");

            if (valor < 1)
                throw new ArgumentException("Valor Inválido.");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }
}
