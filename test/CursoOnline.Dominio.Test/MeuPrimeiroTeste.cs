using System;
using Xunit;

namespace CursoOnline.Dominio.Test
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Variaveis Devem Ter Mesmo Valor")]
        public void DevemVariaveisTeremMesmoValor()
        {
            // Arrange
            var variavel1 = 1;
            var variavel2 = 1;

            // ACT

            // Assert
            Assert.Equal(variavel1, variavel2);
            Assert.True(variavel1 == variavel2);
        }
    }
}
