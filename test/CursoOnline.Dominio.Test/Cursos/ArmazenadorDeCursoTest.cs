using Xunit;
using CursoOnline.Dominio.Cursos;
using Moq;
using Bogus;
using System;
using CursoOnline.Dominio.Test._Util;

namespace CursoOnline.Dominio.Test.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDto _cursoDto;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;

        public ArmazenadorDeCursoTest()
        {
            var faker = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Words(),
                Descricao = faker.Lorem.Paragraph(),
                CargaHoraria = faker.Random.Double(50,500),
                PublicoAlvo = "Estudante",
                Valor = faker.Random.Decimal(100,1000)
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {   /*
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descrição",
                CargaHoraria = 80,
                PublicoAlvo = 1,
                Valor = 951.11m
            }; */

            //var cursoRepositorioMock = new Mock<ICursoRepositorio>();
            //var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>())); // Valida apenas se foi chamado
            _cursoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c => c.Nome == _cursoDto.Nome &&
                    c.Descricao == _cursoDto.Descricao
                    )
                ), Times.AtLeast(1)); // Valida se foi chamado pelo curso específico e a quantidade de vezes
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem("Público Alvo Inválido");
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
    }

    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
                throw new ArgumentException("Público Alvo Inválido");

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public decimal Valor { get; set; }
    }
}
