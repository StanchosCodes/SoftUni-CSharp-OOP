namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior testWarrior;
        private const int MinAttackHp = 30;
        [SetUp]
        public void SetUp()
        {
            this.testWarrior = new Warrior("Pesho", 50, 60);
        }

        [Test]
        public void ConstructorShouldReturnCorrectData()
        {
            string actualName = this.testWarrior.Name;
            int actualDamage = this.testWarrior.Damage;
            int actualHp = this.testWarrior.HP;

            string expectedName = "Pesho";
            int expectedDamage = 50;
            int expectedHp = 60;

            Assert.AreEqual(actualName, expectedName);
            Assert.AreEqual(actualDamage, expectedDamage);
            Assert.AreEqual(actualHp, expectedHp);
        }

        [TestCase("", 30, 20)]
        [TestCase("      ", 30, 20)]
        [TestCase(null, 30, 20)]
        public void NameShouldThrowExceptionIfNullEmptyOrWhiteSpace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
           {
               Warrior newWarrior = new Warrior(name, damage, hp);
           }, "Name should not be empty or whitespace!");
        }

        [TestCase("Pesho", 0, 20)]
        [TestCase("Pesho", -6, 20)]
        public void DamageShouldThrowExceptionIfNegativeOrZero(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior newWarrior = new Warrior(name, damage, hp);
            }, "Damage value should be positive!");
        }

        [TestCase("Pesho", 50, -1)]
        [TestCase("Pesho", 50, -10)]
        public void HpShouldThrowExceptionIfNegative(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior newWarrior = new Warrior(name, damage, hp);
            }, "HP should not be negative!");
        }

        [Test]
        public void WarriorCannotAttackIfHpIsBellow30()
        {
            Warrior newWarrior = new Warrior("Gosho", 30, 29);

            Assert.Throws<InvalidOperationException>(() =>
           {
               newWarrior.Attack(this.testWarrior);
           }, "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void EnemyCannotBeAttackedIfItsHpIsBelow30()
        {
            Warrior newWarrior = new Warrior("Gosho", 30, 29);
            

                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.testWarrior.Attack(newWarrior);
                }, $"Enemy HP must be greater than {MinAttackHp} in order to attack him!");
        }

        [Test]
        public void WarriorHpShouldBeGraterOrEqualToEnemysDamage()
        {
            Warrior newWarrior = new Warrior("Gosho", 30, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                newWarrior.Attack(this.testWarrior);
            }, "You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackShouldDecreaseWarriorsHpWithEnemysDamageIfWarriorsHpIsGrater()
        {
            Warrior enemy = new Warrior("Gosho", 40, 60);

            this.testWarrior.Attack(enemy);

            int actualWarriorHp = this.testWarrior.HP;
            int expectedWarrirHp = 20;

            Assert.AreEqual(actualWarriorHp, expectedWarrirHp);
        }

        [Test]
        public void AttackShouldDecreaseEnemysHpWithWarriorsDamageIfEnemysHpIsGrater()
        {
            Warrior enemy = new Warrior("Gosho", 30, 60);

            this.testWarrior.Attack(enemy);

            int actualWarriorHp = enemy.HP;
            int expectedWarrirHp = 10;

            Assert.AreEqual(actualWarriorHp, expectedWarrirHp);
        }

        [Test]
        public void AttackShouldSetEnemysHpToZeroIfWarriorsDamageIsGrater()
        {
            Warrior enemy = new Warrior("Gosho", 30, 40);

            this.testWarrior.Attack(enemy);

            int actualWarriorHp = enemy.HP;
            int expectedWarrirHp = 0;

            Assert.AreEqual(actualWarriorHp, expectedWarrirHp);
        }
    }
}