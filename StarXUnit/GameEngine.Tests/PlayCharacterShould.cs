using IniciandoXUnit;
using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{

    public class PlayCharacterShould: IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        public PlayCharacterShould(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Creating new PlayerCharacter");
            _sut = new PlayerCharacter();
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
        }

        #region Teste Booleano
        [Fact]
        [Trait("Category", "Teste Booleano")]
        public void ExperienciaDoJogador()
        {

            Assert.True(_sut.IsNoob());

        }
        #endregion

        #region Testes com String
        [Fact]
        [Trait("Category", "Testes com String")]
        public void VerificandoNomeCompleto()
        {

            _sut.LastName = "Ferreira";

            Assert.Equal($"{_sut.FirstName} Ferreira", _sut.FullName);
        }

        [Fact]
        [Trait("Category", "Testes com String")]
        public void NomeCompletoComecandoPeloPrimeiroNome()
        {

            _sut.LastName = "Ferreira";

            Assert.StartsWith($"{_sut.FirstName}", _sut.FullName);
        }

        [Fact]
        [Trait("Category", "Testes com String")]
        public void NomeCompletoTerminandoPeloUltimoNome()        {
           
            _sut.LastName = "Ferreira";

            Assert.EndsWith("Ferreira", _sut.FullName);
        }

        [Fact]
        [Trait("Category", "Testes com String")]
        public void NomeCompletoIgnorandoCaseSensitive()
        {

            _sut.FirstName = "ALEXANDRE";
            _sut.LastName = "FERREIRA";

            Assert.Equal($"{_sut.FirstName} {_sut.LastName}", _sut.FullName, ignoreCase: true);
        }


        [Fact]
        [Trait("Category", "Testes com String")]
        public void NomeCompleto_verificandoSubstring()
        {           
            _sut.LastName = "Ferreira";

            Assert.Contains($"{_sut.FirstName} Fe", _sut.FullName);
        }

        [Fact]
        [Trait("Category", "Testes com String")]
        public void NomeCompleto_PrimeiraLetraMaiscula()
        {
            _sut.FirstName = "Alexandre";
            _sut.LastName = "Ferreira";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }
        #endregion

        #region Testes com valores numéricos

        [Fact]
        [Trait("Category", "Testes com valores numéricos")]
        public void ComecaComDefaultValorParaHealth()
        {
          

            Assert.Equal(100, _sut.Helth);
        }

        [Fact]
        [Trait("Category", "Testes com valores numéricos")]
        public void HelthDiferenteDeZero()
        {         

            Assert.NotEqual(0, _sut.Helth);
        }

        [Fact]
        [Trait("Category", "Testes com valores numéricos")]
        public void IncreaseHealthAfterSleep()
        {            

            _sut.Sleep(); //Expect increase between 1 to 100 inclusive

            //Assert.True(sut.Helth >=101 && sut.Helth <= 200);

            Assert.InRange(_sut.Helth, 101, 200);
        }
        #endregion

        #region Testes com valores nulos

        [Fact]
        [Trait("Category", "Testes com valores nulos")]
        public void DeveTerValorNumericoComoDefault()
        {           

            Assert.Null(_sut.NickName);
        }

        #endregion


        #region Testes com coleções

        [Fact]
        [Trait("Category", "Testes com coleções")]
        public void HaveALongBow()
        {           

            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        [Trait("Category", "Testes com coleções")]
        public void NotHaveAStaffOfWonder()
        {           

            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }

        [Fact]
        [Trait("Category", "Testes com coleções")]
        public void HaveAtLeastOneKindOfWord()        {
           

            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        [Trait("Category", "Testes com coleções")]
        public void HaveAllExpectedWeapons()        {
           

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        [Trait("Category", "Testes com coleções")]
        public void HaveNoEmptyDefaultWeapons()
        {
          

            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }


        #endregion

        #region Testes com eventos

        [Fact]
        [Trait("Category", "Testes com eventos")]
        public void RaiseSleptEvent()
        {          

            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact(Skip = "Não precisa executar este teste.")]
        [Trait("Category", "Testes com eventos")]
        public void RaisePropertyChangedEvent()
        {          
            Assert.PropertyChanged(_sut, "Helth", () => _sut.TakeDamage(10));

        }

       


        #endregion






    }
}
