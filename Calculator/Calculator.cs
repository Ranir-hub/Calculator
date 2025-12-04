using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace Calculator;

public class Command<T> : ICommand
{
    private Action<T> _action;

    public Command(Action<T> action)
    {
        _action = action;
    }

    public void Execute(object? parameter)
    {
        _action((T)parameter);
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }
}

public class ValueMem : INotifyPropertyChanged
{
    private string _value;
    public int index;
    private string _history;
    public event PropertyChangedEventHandler? PropertyChanged;

    public string Value
    {
        get { return _value; }
        set
        {
            _value = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }

    public string History
    {
        get { return _history; }
        set
        {
            _history = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }
    public ValueMem(string value, int index, string history) { _value = value; this.index = index; _history = history; }
}

public class Calculator : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand SubFromMemory { get; private set; }
    public ICommand PlusToMemory { get; private set; }
    public ICommand DeleteFromMemory { get; private set; }
    public ICommand InputCommand { get; private set; }
    public ICommand FromJournalToDisplayCommand { get; private set; }
    public Calculator()
    {
        InputCommand = new Command<string>(Input);
        FromJournalToDisplayCommand = new Command<ValueMem>(x => {
            Display = x.Value;
            _firstOperand = Convert.ToDecimal(Display);
            enable = false;
            HistoryDisplay = x.History;
        });

        SubFromMemory = new Command<ValueMem>(x => Memory[x.index].Value = Convert.ToString(Convert.ToDecimal(x.Value) - Convert.ToDecimal(Display)));
        PlusToMemory = new Command<ValueMem>(x => Memory[x.index].Value = Convert.ToString(Convert.ToDecimal(x.Value) + Convert.ToDecimal(Display)));
        DeleteFromMemory = new Command<ValueMem>(x =>
        {
            int index = x.index;
            Memory.Remove(x);
            if (Memory.Count != 0)
            {
                for (int i = index; i < Memory.Count; i++)
                {
                    Memory[i].index = Memory[i].index - 1;
                }
            }
        });

        _operationMap.Add("+", (a, b) => { return a + b; });
        _operationMap.Add("-", (a, b) => { return a - b; });
        _operationMap.Add("x", (a, b) => { return a * b; });
        _operationMap.Add("/", (a, b) => { return a / b; });
        _operationMap.Add("x^2", (a, b) => { return (decimal)Math.Pow(Convert.ToDouble(b), 2); }); 
        _operationMap.Add("√", (a, b) => { return (decimal)Math.Sqrt(Convert.ToDouble(b)); }); 
        _operationMap.Add("1/x", (a, b) => { return 1 / b; }); 
        _operationMap.Add("%", (a, b) => { return a * (b/100); }); 
    }

    public ObservableCollection<ValueMem> Journal { get; } = new();
    public ObservableCollection<ValueMem> Memory { get; } = new();
    private decimal? _firstOperand = null;
    private decimal? _secondOperand = null;

    private Func<decimal, decimal, decimal>? _operation = null;
    private readonly Dictionary<string, Func<decimal, decimal, decimal>> _operationMap = new();

    bool enable = true;
    bool res = false;

    private string op = "";
    private string display = "0";
    public string Display
    {
        get => display;
        private set
        {
            display = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Display)));
        }
    }

    private string historydisplay;
    public string HistoryDisplay
    {
        get => historydisplay;
        private set
        {
            historydisplay = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryDisplay)));
        }
    }

    private void Reset()
    {
        _firstOperand = null;
        _secondOperand = null;
        _operation = null;
        HistoryDisplay = null;
        enable = true;
        res = false;
        Display = "0";
    }

    private void Calculate()
    {
        if (_operation == null) throw new Exception("O_o");
        if ((op == "/" || _operation == _operationMap["1/x"]) && _secondOperand == 0 )
        {
            if (_firstOperand == 0) Display = "Результат не определен";
            else Display = "Деление на ноль невозможно";
            _secondOperand = null;
        }
        else
        {
            Display = Convert.ToDouble(_operation(_firstOperand.Value, _secondOperand.Value).ToString()).ToString();
            Journal.Insert(0, new ValueMem(Display, 0, (_firstOperand.ToString() + op + _secondOperand.ToString() + "=")));
            _firstOperand = (decimal)Convert.ToDouble(Display);
            enable = false;
        }
    }

    private void Input(string value)
    {
        if (Display == "Результат не определен" || Display == "Деление на ноль невозможно") Reset();

        if (value == "C")
        {
            Reset();
        }
        else if (value == "CE")
        {
            Display = "0";
        }
        else if (value == "MS")
        {
            Memory.Insert(0, new ValueMem(Convert.ToDouble(Display).ToString(), 0, ""));
            Display = Convert.ToDouble(Display).ToString();
            for (int i = 1; i < Memory.Count; i++)
            {
                Memory[i].index = Memory[i].index + 1;
            }
            enable = false;
        }
        else if (value == "MC")
        {
            while (Memory.Count != 0)
            {
                Memory.RemoveAt(Memory.Count - 1);
            }
        }
        else if (value == "MR")
        {
            if (Memory.Count > 0) Display = Memory[0].Value;
            else Display = "0";
        }
        else if (value == "M+")
        {
            if (Memory.Count > 0)
            {
                Memory[0].Value = Convert.ToString(Convert.ToDecimal(Memory[0].Value) + Convert.ToDecimal(Display));
                enable = false;
            }
        }
        else if (value == "M-")
        {
            if (Memory.Count > 0)
            {
                Memory[0].Value = Convert.ToString(Convert.ToDecimal(Memory[0].Value) - Convert.ToDecimal(Display));
                enable = false;
            }
        }
        else if (value == "del")
        {
            if (_secondOperand == null && enable == false) return;
            if (res)
            {
                Reset();
            }
            Display = Display.Remove(Display.Length - 1, 1);
            if (Display.Length == 0)
            {
                Display = "0";
            }
        }
        else if (value == "√" || value == "x^2" || value == "1/x" || value == "%")
        {
            _operation = _operationMap[value];
            if (_firstOperand == null)
            {
                _firstOperand = 0;
                _secondOperand = Convert.ToDecimal(Display);
                Calculate();
                if (Display != "Результат не определен" && Display != "Деление на ноль невозможно") Journal.RemoveAt(0);

                value = value.Replace("x", Display);
                if (value == "%") HistoryDisplay = "0"; // need change
                else if (value.Contains("^2") || value.Contains("1/")) HistoryDisplay = value; // need change
                else HistoryDisplay = value + "(" + Display + ")"; // need change
                _secondOperand = null;
            }
            else if (_secondOperand == null)
            {
                decimal? old = _firstOperand;
                _secondOperand = Convert.ToDecimal(Display); 
                Calculate();
                if (Display != "Результат не определен" && Display != "Деление на ноль невозможно") Journal.RemoveAt(0);

                value = value.Replace("x", Display);
                if (value == "%") HistoryDisplay = Display; // need change
                else if (value.Contains("^2") || value.Contains("1/")) HistoryDisplay += value; // need change
                else HistoryDisplay += value + "(" + Display + ")"; // need change
                _firstOperand = old;
                _secondOperand = null;
                enable = true;
            }
            if(op != "") _operation = _operationMap[op];
        }
        else if (_operationMap.ContainsKey(value))
        {
            res = false;
            if (_firstOperand == null)
            {
                _firstOperand = Convert.ToDecimal(Display);
                enable = false;
            }
            else if (_secondOperand == null && enable == true) _secondOperand = Convert.ToDecimal(Display);

            if (_operation != null && _firstOperand.HasValue && _secondOperand.HasValue && enable == true)
            {
                Calculate();
                _secondOperand = null;
            }
            if (Display != "Результат не определен" && Display != "Деление на ноль невозможно") HistoryDisplay = Display + value;
            _operation = _operationMap[value];
            op = value;
        }
        else if (value == "=")
        {
            if (_secondOperand == null) _secondOperand = Convert.ToDecimal(Display);
            if (_operation != null && _firstOperand.HasValue && _secondOperand.HasValue)
            {
                HistoryDisplay = _firstOperand + op + _secondOperand + value;
                Calculate();
                res = true;
                enable = false;
            }
            else
            {
                HistoryDisplay = Convert.ToDouble(Display) + value;
                _firstOperand = Convert.ToDecimal(Display);
                Display = Convert.ToDouble(Display).ToString();
                Journal.Add(new ValueMem(Display, 0, HistoryDisplay));
            }
        }
        else if (value == "+-")
        {
            if ((Display[0]) == '-') Display.Remove(0, 1);
            else Display = "-" + Display;
        }
        else
        {
            if (Display == "0" && value != "," && value != "+-")
            {

                Display = value;
                enable = true;
            }
            else if (res)
            {
                Reset();
                Display = value;
            }
            else if (Display == _firstOperand.ToString() || enable == false)
            {
                if (value == ",")
                {
                    Display = "0,";
                }
                else
                {
                    Display = value;
                    enable = true;
                    _secondOperand = null;
                }
            }
            else if (value == ",")
            {
                if (Display.IndexOf(',') == -1)
                {
                    Display = Display + value;
                    enable = true;
                }
            }
            else
            {
                if (Display.Length < 16)
                {
                    Display = Display + value;

                    enable = true;
                }
            }
        }
    }
    private string _value;
    public string Value
    {
        get { return _value; }
        set
        {
            _value = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }

    private string _history;
    public string History
    {
        get { return _history; }
        set
        {
            _history = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(History)));
        }
    }
}