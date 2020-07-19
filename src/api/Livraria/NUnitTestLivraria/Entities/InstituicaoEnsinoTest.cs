using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using Livraria.Domain.Validations;

namespace NUnitTestLivraria
{
    [TestFixture]
    public class InstituicaoEnsinoTest
    {
        private InstituicaoEnsinoValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new InstituicaoEnsinoValidator();
        }

        [Test]
        public void aprensenta_erro_quando_cnpj_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.CPNJ, null as string);
        }
        [Test]
        public void aprensenta_erro_quando_telefone_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.Telefone, null as string);
        }
        [Test]
        public void aprensenta_erro_quando_endereco_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.Endereco, null as string);
        }

        [Test]
        public void aprensenta_erro_quando_nome_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.Nome, null as string);
        }


        [Test]
        public void nao_aprensenta_erro_quando_cnpj_for_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.CPNJ, "00000000000000");
        }
        [Test]
        public void nao_aprensenta_erro_quando_telefone_for_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.Telefone, "6599999999");
        }
        [Test]
        public void nao_aprensenta_erro_quando_endereco_for_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.Endereco, "Rua B Casa A Bairro X");
        }

        [Test]
        public void nao_aprensenta_erro_quando_nome_for_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(instituicaoEnsino => instituicaoEnsino.Nome, "Instituição de Ensino A");
        }


    }
}