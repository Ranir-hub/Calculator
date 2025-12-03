using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Дисплей_РавенНулю_ПриЗапуске()
        {
            var calc = new Calculator.Calculator();
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_НаДисплееДолжноБыть1_КогдаВвели1()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");

            Assert.AreEqual("1", calc.Display);
        }

        [TestMethod]
        public void Дисплей_НаДисплееДолжноБыть12_КогдаВвели12()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");

            Assert.AreEqual("12", calc.Display);
        }

        [TestMethod]
        public void Дисплей_НаДисплееДолжноБыть12_ДажеПослеВводаПлюса()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");

            Assert.AreEqual("12", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетВводВторогоОперанда()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");

            Assert.AreEqual("34", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатСуммы_ПослеВводаРавно()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("46", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатДвойногоВычисленияСумме_ПослеВводаРавноДважды()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("80", calc.Display);
        }


        [TestMethod]
        public void Дисплей_ВторойОперандРавенДисплеюЕслиБылаНажатаОперация()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("-");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультТройногоВычисленияСумме_ПослеВводаРавноТрижды()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("114", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетРеузльтатВыполненияПервойОперации_ПриВводеВторойОперации()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("-");

            Assert.AreEqual("46", calc.Display);
        }


        [TestMethod]
        public void Дислей_ОтображаетЧисло_ПослеВводаЧислаПослеРавно()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("7");
            calc.InputCommand.Execute("8");
            Assert.AreEqual("78", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетЧисло_ПослеВводаЧислаРавно_И_Минуса()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("7");
            calc.InputCommand.Execute("8");
            calc.InputCommand.Execute("-");
            Assert.AreEqual("78", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетЧисло_ПослеВводаЧислаРавноМинуса_И_Числа()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("7");
            calc.InputCommand.Execute("8");
            calc.InputCommand.Execute("-");
            calc.InputCommand.Execute("9");
            Assert.AreEqual("9", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетЧисло_ДвухВыраженийСРавно()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("7");
            calc.InputCommand.Execute("8");
            calc.InputCommand.Execute("-");
            calc.InputCommand.Execute("9");
            calc.InputCommand.Execute("=");
            Assert.AreEqual("69", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетЧисло_ПоcлеОдногоЧислаОперацииИРавно()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("=");
            Assert.AreEqual("4", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетИсключение_ПоcлеДеленияНаНуль()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("/");
            calc.InputCommand.Execute("0");
            //Assert.ThrowsException<Exception>(() => calc.InputCommand.Execute("="));
        }

        [TestMethod]
        public void Дислей_ОтображаетРеузультатВвода_ПриВводеТретьегочисла()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");

            Assert.AreEqual("56", calc.Display);
        }

        [TestMethod]
        public void СохранениеЧислаВПамять()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("MS");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("MR");

            Assert.AreEqual("1", calc.Display);
        }

        [TestMethod]
        public void ВычитаниеИзПамяти()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("MS");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("M-");
            calc.InputCommand.Execute("MR");

            Assert.AreEqual("-1", calc.Display);
        }

        [TestMethod]
        public void СложениеСПамятью()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("MS");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("M+");
            calc.InputCommand.Execute("MR");

            Assert.AreEqual("3", calc.Display);
        }

        [TestMethod]
        public void ОчисткаПамяти()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("MS");
            calc.InputCommand.Execute("MC");
            calc.InputCommand.Execute("MR");

            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетВторойОперанд()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");

            Assert.AreEqual("34", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатСуммы_ПриОтсутсвииПервогоОперанда()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("12", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатСуммы()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("46", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатДвойнойСуммы()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("80", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатТройнойСуммы()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("114", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатВыполненияПервойОперации_ПриВводеВторой()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("-");

            Assert.AreEqual("46", calc.Display);
        }


        [TestMethod]
        public void Дисплей_ОтображаетРезультатВыполненияПервойОперации_ПриВводеВторойИЕщеРаз()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("-");
            calc.InputCommand.Execute("-");

            Assert.AreEqual("46", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатВведенияНовогоЧисла_ПослеВычисления()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");

            Assert.AreEqual("56", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатВыполненияВычисления_СРезультатомПредыдущегоВычисления()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("102", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатВыполненияНовогоВычечления()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("3");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("=");

            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("6");
            calc.InputCommand.Execute("-");
            calc.InputCommand.Execute("7");
            calc.InputCommand.Execute("8");
            calc.InputCommand.Execute("=");


            Assert.AreEqual("-22", calc.Display);
        }
        
    }
}