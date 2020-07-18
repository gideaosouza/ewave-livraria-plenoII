using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using Livraria.Domain.Validations;

namespace NUnitTestLivraria
{
    [TestFixture]
    public class LivroValidatorTester
    {
        private LivroValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new LivroValidator();
        }

        [Test]
        public void aprensenta_erro_quando_titulo_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(livro => livro.Titulo, null as string);
        }
        [Test]
        public void aprensenta_erro_quando_genero_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(livro => livro.Genero, null as string);
        }
        [Test]
        public void aprensenta_erro_quando_autor_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(livro => livro.Autor, null as string);
        }

        [Test]
        public void aprensenta_erro_quando_Capa_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(livro => livro.Capa, null as string);
        }


        [Test]
        public void nao_apresenta_erro_quando_titulo_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(livro => livro.Titulo, "Semente da Vitória");
        }

        [Test]
        public void nao_apresenta_erro_quando_genero_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(livro => livro.Genero, "Auto Ajuda");
        }

        [Test]
        public void nao_apresenta_erro_quando_autor_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(livro => livro.Autor, "Nulo Cobra");
        }

        [Test]
        public void nao_apresenta_erro_quando_capa_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(livro => livro.Capa, "algumCaminhoDEStorage/nomeDaImagem.jpg");
        }
    }
}