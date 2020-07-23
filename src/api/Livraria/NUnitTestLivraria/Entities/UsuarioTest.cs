using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using Livraria.Domain.Validations;

namespace NUnitTestLivraria
{
    [TestFixture]
    public class UsuarioValidatorTester
    {
        private UsuarioValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new UsuarioValidator();
        }

        [Test]
        public void aprensenta_erro_quando_nome_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(usuario => usuario.Nome, null as string);
        }
        [Test]
        public void aprensenta_erro_quando_telefone_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(usuario => usuario.Telefone, null as string);
        }
        [Test]
        public void aprensenta_erro_quando_cpf_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(usuario => usuario.CPF, null as string);
        }

        [Test]
        public void aprensenta_erro_quando_email_for_nulo()
        {
            validator.ShouldHaveValidationErrorFor(usuario => usuario.Email, null as string);
        }



        [Test]
        public void nao_apresenta_erro_quando_nome_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(usuario => usuario.Nome, "Semente da Vitória");
        }

        [Test]
        public void nao_apresenta_erro_quando_telefone_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(usuario => usuario.Telefone, "Auto Ajuda");
        }

        [Test]
        public void nao_apresenta_erro_quando_cpf_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(usuario => usuario.CPF, "Nulo Cobra");
        }

        [Test]
        public void nao_apresenta_erro_quando_email_estiver_correto()
        {
            validator.ShouldNotHaveValidationErrorFor(usuario => usuario.Email, "Email@Email.com");
        }
    }
}