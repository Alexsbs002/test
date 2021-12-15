using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab44
{
    public class Task
    {
        protected string DefaultString = "Error! Try again!";
        public string Name = "";

        public InputOutput InOut = new InputOutput();
        public Task(string Name)
        {
            this.Name = Name;
        }
        public virtual void DoTask() { }
        public virtual void ShowName()
        {
            InOut.PrintString(Name);
        }
        public virtual void DoTask(Case0 _0, Case1 _1, Case2 _2, Case3 _3, Case4 _4)
        {
            string[] Names = { Name, _0.Name, _1.Name, _2.Name, _3.Name, _4.Name };

            string EnteredValue;
            do
            {
                InOut.PrintArray(Names);
                EnteredValue = InOut.ReadString();
                switch (EnteredValue)
                {
                    case "0":
                        _0.DoTask();
                        break;
                    case "1":
                        _1.DoTask();
                        break;
                    case "2":
                        _2.DoTask();
                        break;
                    case "3":
                        _3.DoTask();
                        break;
                    case "4":
                        _4.DoTask();
                        break;
                    default:
                        InOut.PrintString(DefaultString);
                        break;
                }
            } while (EnteredValue != "0");
        }
    }

    public class Case0 : Task
    {
        public Case0(string Name) : base(Name) { }
        public override void DoTask()
        { }
    }

    public class Case1 : Task
    {
        public Case1(string Name) : base(Name) { }
        public override void DoTask()
        {
            InOut.PrintString("Hello World!");
        }
    }

    public class Case2 : Task
    {
        int x;
        int y;
        int z;
        Calculations calc_obj = new Calculations();
        public Case2(string Name) : base(Name) { }
        public override void DoTask()
        {
            EnterValues();
            PrintResult(calc_obj.Calc(x, y, z));
        }
        public void EnterValues()
        {
            InOut.PrintString("Enter x");
            x = InOut.GetValidInt();

            InOut.PrintString("Enter y");
            do
            {
                y = InOut.GetValidInt();
                if (!CheckY(y))
                    InOut.PrintString("Error!");
            }
            while (!CheckY(y));

            InOut.PrintString("Enter z");
            do
            {
                z = InOut.GetValidInt();
                if (!CheckZ(z))
                    InOut.PrintString("Error!");
            }
            while (!CheckZ(z));
        }
        bool CheckY(int y)
        {
            if (y <= 0)
                return false;
            else
                return true;
        }
        bool CheckZ(int z)
        {
            if (z == 0)
                return false;
            else
                return true;
        }

        void PrintResult(double res)
        {
            InOut.PrintString("Result = " + res);
        }
    }

    public class Case3 : Task
    {
        public Case3(string Name) : base(Name) { }

        Calculations calc_obj = new Calculations();

        DateTime[,] InputDates = new DateTime[2, 2]; // 

        public override void DoTask()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    InOut.PrintString("Введите " + (i + 1) + "-ую дату " + (j + 1) + "-го отрезка времени:");
                    InputDates[i, j] = InOut.GetValidDate();
                }
            }
            InputDates = SortDates(InputDates);
            ShowResult(calc_obj.CalculateIntersectingDaysNumber(InputDates));
        }

        private DateTime[,] SortDates(DateTime[,] EnteredDate)
        {
            DateTime TempDate;
            for (int j = 0; j < 2; j++)
            {
                if (EnteredDate[1, j] < EnteredDate[0, j])
                {
                    TempDate = EnteredDate[1, j];
                    EnteredDate[1, j] = EnteredDate[0, j];
                    EnteredDate[0, j] = TempDate;
                }
            }

            return EnteredDate;
        }

        private void ShowResult(double IntersectingDaysNumber)
        {

            if (IntersectingDaysNumber > 100)
            {
                InOut.PrintString("Количество общих дней больше 100! Я не буду это считать!");
            }
            else
            {
                if (IntersectingDaysNumber == 0)
                {
                    InOut.PrintString("Введённые отрезки не пересекаются");
                }
                else
                {
                    InOut.PrintString($"Количество общих дней: {IntersectingDaysNumber}");
                }
            }


            //Доп задание 1
            if ((IntersectingDaysNumber > 0) && (IntersectingDaysNumber <= 100))
            {
                InOut.PrintString("от 0 до N");
                for (int i = 0; i <= IntersectingDaysNumber; i++)
                {
                    InOut.PrintString(Convert.ToString(i));
                }
            }

        }
    }

    public class Case4 : Task
    {
        private string[] values = new string[2]; //Создание и ограничение массива
        private ValidationException exc = new ValidationException(""); //Создание экземпляра класса (поле)

        public Case4(string Name) : base(Name) { }
        public override void DoTask()
        {
            InputStrings();
            Validate(values);
        }
        public void InputStrings()
        {
            for (int i = 0; i < 2; i++)
            {
                InOut.PrintString("Введите " + (i + 1) + "-ую строку");
                values[i] = InOut.ReadString();
            }
        }


        private void Validate(string[] values)
        {

            SymbolEqual(values);
            ConvertEqual(values);
            FlipEqual(values);
            RegexOK(values);
        }
        public string TrimAndRegister(string Event)
        {
            string argv = Event.ToLower().Trim();
            return argv; // Новое значение строки (с учетом регистра и удаленных пробелов)
        }            // Проверка на перевертыш
        public bool Flipped(string[] value)
        {
            char[] first = value[0].ToCharArray();
            Array.Reverse(first);
            string reversed_1 = new string(first);
            if (reversed_1 == value[1])
                return true;
            else
                return false;
        }


        string[] ihateregex = { "Email", "Phone", "IpV4" };
        string[] pattern =
            { @"^[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]",
                    @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",
                    @"(\b25[0-5]|\b2[0-4][0-9]|\b[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}" };

        // Проверка формата записи телефон? почта? ip?)
        void RegexOK(string[] value)
        {
            for(int i = 0; i < 2; i++)
            {
                isEmail(values[i]);
                isPhone(values[i]);
                isIpV4(values[i]);
            }
        }
        public bool isEmail(string value)
        {
            ValidationException e = new ValidationException("");
            // Проверяем паттерн
            {
                try
                {
                    if (Regex.IsMatch(value, pattern[0], RegexOptions.IgnoreCase)) // игнорим регистр 3 штука
                    {
                        InOut.PrintString($"Строка {value} является паттерном {ihateregex[0]}");
                    }
                    else
                        throw new ValidationException($"Exception: Строка {value} не является паттерном {ihateregex[0]}");
                }
                catch (ValidationException ex)
                {
                    e = ex;
                    ValidationException.OnException(e);
                    return false;
                }
            }
            return true;
        }
        public bool isPhone(string value)
        {
            ValidationException e = new ValidationException("");
            try
            {
                if (Regex.IsMatch(value, pattern[1], RegexOptions.IgnoreCase))
                {
                    InOut.PrintString($"Строка {value} является паттерном {ihateregex[1]}");
                }
                else
                    throw new ValidationException($"Exception: Строка {value} не является паттерном {ihateregex[1]}");
            }
            catch (ValidationException ex)
            {
                e = ex;
                ValidationException.OnException(e);
                return false;
            }
            return true;
        }
        public bool isIpV4(string value)
        {
            ValidationException e = new ValidationException("");
            try
            {
                if (Regex.IsMatch(value, pattern[2], RegexOptions.IgnoreCase))
                {
                    InOut.PrintString($"Строка {value} является паттерном {ihateregex[2]}");
                }
                else
                    throw new ValidationException($"Exception: Строка {value} не является паттерном {ihateregex[2]}");
            }
            catch (ValidationException ex)
            {
                e = ex;
                ValidationException.OnException(e);
                return false;
            }
            return true;
        }

        public bool SymbolEqual(string[] values)
        {
            // Проверка на одинаковые символы     
            try
            {
                if (values[0] == values[1])
                {
                    InOut.PrintString("Строки одинаковые");
                }
                else
                {
                    throw new ValidationException("Exception: Строки не одинаковые посимвольно");
                }
            }
            catch (ValidationException ex)
            {
                ValidationException.OnException(ex);
                return false;
            }
            return true;
        }

        // Конвертация регистра
        public bool ConvertEqual(string[] values)
        {
            try
            {
                if (TrimAndRegister(values[0]) == TrimAndRegister(values[1]))
                {
                    InOut.PrintString("Строки одинаковые, учитывая регистр и без пробелов");
                }
                else
                    throw new ValidationException("Строки не совпадают");
            }

            catch (ValidationException ex)
            {
                ValidationException.OnException(ex);
                return false;
            }
            return true;
        }
        public bool FlipEqual(string[] values)
        {
            try
            {
                if (Flipped(values) == true)
                {
                    InOut.PrintString("Строка 1 перевёртыш 2-ой");
                }
                else
                    throw new ValidationException("Не перевёртыш");
            }
            catch (ValidationException ex)
            {
                ValidationException.OnException(ex);
                return false;
            }
            return true;
        }
    }
}
