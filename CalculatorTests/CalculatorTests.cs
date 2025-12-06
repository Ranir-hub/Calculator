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

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_НаДисплееДолжноБыть1_КогдаВвели1()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("1", calc.Display);
        }

        [TestMethod]
        public void Дисплей_НаДисплееДолжноБыть12_КогдаВвели12()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("12", calc.Display);
        }

        [TestMethod]
        public void Дисплей_НаДисплееДолжноБыть12_ДажеПослеВводаПлюса()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");

            Assert.AreEqual("12+", calc.HistoryDisplay);
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

            Assert.AreEqual("12+", calc.HistoryDisplay);
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

            Assert.AreEqual("12+34=", calc.HistoryDisplay);
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

            Assert.AreEqual("46+34=", calc.HistoryDisplay);
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

            Assert.AreEqual("46-46=", calc.HistoryDisplay);
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

            Assert.AreEqual("80+34=", calc.HistoryDisplay);
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

            Assert.AreEqual("46-", calc.HistoryDisplay);
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

            Assert.AreEqual("", calc.HistoryDisplay);
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

            Assert.AreEqual("78-", calc.HistoryDisplay);
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

            Assert.AreEqual("78-", calc.HistoryDisplay);
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

            Assert.AreEqual("78-9=", calc.HistoryDisplay);
            Assert.AreEqual("69", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетЧисло_ПоcлеОдногоЧислаОперацииИРавно()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("2+2=", calc.HistoryDisplay);
            Assert.AreEqual("4", calc.Display);
        }

        [TestMethod]
        public void Дислей_ОтображаетИсключение_ПоcлеДеленияНаНуль()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("/");
            calc.InputCommand.Execute("0");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("2/", calc.HistoryDisplay);
            Assert.AreEqual("Деление на ноль невозможно", calc.Display);
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

            Assert.AreEqual("46+", calc.HistoryDisplay);
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

            Assert.AreEqual("", calc.HistoryDisplay);
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

            Assert.AreEqual("", calc.HistoryDisplay);
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

            Assert.AreEqual("", calc.HistoryDisplay);
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

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ОтображаетРезультатСуммы_ПриОтсутсвииПервогоОперанда()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("0+12=", calc.HistoryDisplay);
            Assert.AreEqual("12", calc.Display);
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

            Assert.AreEqual("46-", calc.HistoryDisplay);
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

            Assert.AreEqual("46-", calc.HistoryDisplay);
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

            Assert.AreEqual("", calc.HistoryDisplay);
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

            Assert.AreEqual("46+56=", calc.HistoryDisplay);
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


            Assert.AreEqual("56-78=", calc.HistoryDisplay);
            Assert.AreEqual("-22", calc.Display);
        }

        [TestMethod]
        public void Дисплей_Отображает0ПослеНажатияУдаленияПриДисплееС0()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("del");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_Отображает0ПослеНажатияУдаленияПриДисплееС1Цифрой()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("del");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void ОчисткаВсего()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("C");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void ОчисткаДисплея()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("5");
            calc.InputCommand.Execute("CE");

            Assert.AreEqual("1+", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_КореньИзЧисла()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("√");

            Assert.AreEqual("√(0)", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_КореньИзЧислаОтДисплея()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("√");

            Assert.AreEqual("√(4)", calc.HistoryDisplay);
            Assert.AreEqual("2", calc.Display);
        }

        [TestMethod]
        public void Дисплей_КореньИзЧислаОтДисплеяСПараллельнымВычислением()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("4");
            calc.InputCommand.Execute("√");

            Assert.AreEqual("2+√(4)", calc.HistoryDisplay);
            Assert.AreEqual("2", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ВозведениеВКвадрат()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("x^2");

            Assert.AreEqual("(0)^2", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_ВозведениеВКвадратСПараллельнымВычислением()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("x^2");

            Assert.AreEqual("2+(2)^2", calc.HistoryDisplay);
            Assert.AreEqual("4", calc.Display);
        }

        [TestMethod]
        public void Дисплей_1ДелитьНаДисплей()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("1/x");

            Assert.AreEqual("1/(0)", calc.HistoryDisplay);
            Assert.AreEqual("Деление на ноль невозможно", calc.Display);
        }

        [TestMethod]
        public void Дисплей_1ДелитьНаДисплейСПараллельнымВычислением()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("2");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("1/x");

            Assert.AreEqual("2+1/(2)", calc.HistoryDisplay);
            Assert.AreEqual("0,5", calc.Display);
        }

        [TestMethod]
        public void Дисплей_0ПроцентовОт0()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("%");

            Assert.AreEqual("0", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_100ПроцентовОт100()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("%");

            Assert.AreEqual("100+100", calc.HistoryDisplay);
            Assert.AreEqual("100", calc.Display);
        }

        [TestMethod]
        public void Дисплей_50ПроцентовОт100Сложение()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("50");
            calc.InputCommand.Execute("%");

            Assert.AreEqual("100+50", calc.HistoryDisplay);
            Assert.AreEqual("50", calc.Display);
        }

        [TestMethod]
        public void Дисплей_50ПроцентовОт100Умножение()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("x");
            calc.InputCommand.Execute("50");
            calc.InputCommand.Execute("%");

            Assert.AreEqual("100x0,5", calc.HistoryDisplay);
            Assert.AreEqual("0,5", calc.Display);
        }

        [TestMethod]
        public void Дисплей_СменаОперации()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("x");
            calc.InputCommand.Execute("50");
            calc.InputCommand.Execute("%");

            Assert.AreEqual("100x0,5", calc.HistoryDisplay);
            Assert.AreEqual("0,5", calc.Display);
        }

        [TestMethod]
        public void Дисплей_СменаЗнакаНаПоложительный()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+-");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("-100", calc.Display);
        }

        [TestMethod]
        public void Дисплей_СменаЗнакаНаОтрицательный()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+-");
            calc.InputCommand.Execute("+-");

            Assert.AreEqual("", calc.HistoryDisplay);
            Assert.AreEqual("100", calc.Display);
        }

        [TestMethod]
        public void Дисплей_СменаЗнакаУВторогоОперанда()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+-");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("100+-100=", calc.HistoryDisplay);
            Assert.AreEqual("0", calc.Display);
        }

        [TestMethod]
        public void Дисплей_СменаЗнакаУРезультатаИСледующееВычислениеСНовымЗнаком()
        {
            var calc = new Calculator.Calculator();

            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("=");
            calc.InputCommand.Execute("+-");
            calc.InputCommand.Execute("+");
            calc.InputCommand.Execute("100");
            calc.InputCommand.Execute("=");

            Assert.AreEqual("-200+100=", calc.HistoryDisplay);
            Assert.AreEqual("-100", calc.Display);
        }
    }
}
