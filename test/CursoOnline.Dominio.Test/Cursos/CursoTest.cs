using ExpectedObjects;
using Xunit;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class CursoTest
    {
        [Fact]
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
                PublicoAlvo = "Estudante",
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
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, decimal valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
    }
}
