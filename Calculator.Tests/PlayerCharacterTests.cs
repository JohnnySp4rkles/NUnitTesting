using NUnit.Framework;

namespace Calculator.Tests {

    [TestFixture]
    internal class PlayerCharacterTests {
        private PlayerCharacter sut_PC = new PlayerCharacter();
        private EnemyFactory sut_EF = new EnemyFactory();

        #region Nulls and Booleans
        [Test]
        public void ShouldHaveDefaultRandomName() {
            Assert.That(sut_PC.Name, Is.Not.Empty);
        }

        [Test]
        public void ShouldNotHaveANickname() {
            Assert.That(sut_PC.NickName, Is.Null);
        }

        [Test]
        public void ShouldBeNoob() {
            Assert.That(sut_PC.IsNoob, Is.True);
        }
        #endregion

        #region Assertion on Collections
        [Test]
        public void ShouldHaveNoEmptyDefaultWeapons() {
            Assert.That(sut_PC.Weapons, Is.All.Not.Empty);
        }

        [Test]
        public void ShouldHaveALongBox() {
            Assert.That(sut_PC.Weapons, Contains.Item("Long Bow"));
        }

        [Test]
        public void ShouldHaveAtLeastOneTypeOfSword() {
            Assert.That(sut_PC.Weapons, Has.Some.Contains("Sword"));
        }

        [Test] // Should have exactly 2 items ending in 'Bow'
        public void ShouldHaveTwoBows() {
            Assert.That(sut_PC.Weapons, Has.Exactly(2).EndsWith("Bow"));
        }

        [Test]
        public void ShouldNotHaveMoreThatOneTypeOfAGivenWeapon() {
            Assert.That(sut_PC.Weapons, Is.Unique);
        }

        [Test]
        public void ShouldNotHaveAStaffOfWonder() {
            Assert.That(sut_PC.Weapons, Has.None.EqualTo("Staff of Wonder"));
        }

        [Test]
        public void ShouldHaveAllExpectedWeapons() {
            var expectedWeapons = new[] {
                // The order does not need to match for this test
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };
            Assert.That(sut_PC.Weapons, Is.EquivalentTo(expectedWeapons));
        }

        [Test]
        public void ShouldHaveAllExpectedWeapons_AlphabeticalOrder() {
            Assert.That(sut_PC.Weapons, Is.Ordered);
        }
        #endregion

        #region Reference Equality
        [Test]
        public void ReferenceEquality_A() {
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            // player1 is not the same instance of player 2
            Assert.That(player1, Is.Not.SameAs(player2));
        }

        [Test]
        public void ReferenceEquality_B() {
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            var otherPlayer = player1;
            Assert.That(otherPlayer, Is.SameAs(player1));
        }
        #endregion

        #region Asserting on Object Types and Properties
        [Test]
        public void ShouldCreateNormalEnemy() {
            object enemy = sut_EF.Create(false);
            Assert.That(enemy, Is.TypeOf<NormalEnemy>());
        }

        [Test]
        public void ShouldCreateBossEnemy() {
            object enemy = sut_EF.Create(true);
            Assert.That(enemy, Is.TypeOf<BossEnemy>());
        }

        [Test]
        public void ShouldBeOfBaseType() {
            object enemy = sut_EF.Create(true);
            Assert.That(enemy, Is.InstanceOf<Enemy>());
        }

        [Test]
        public void ShouldHaveExtraPower() {
            object enemy = sut_EF.Create(true);
            Assert.That(enemy, Has.Property("ExtraPower"));
        }
        #endregion
    }
}