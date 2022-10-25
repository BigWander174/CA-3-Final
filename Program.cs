using DeleteConsole;

Console.WriteLine("Введите операцию: ");

string operation = Console.ReadLine();

var parser = new Parser(operation);

var cyclebuilder = new Calculator(parser);

Console.WriteLine(cyclebuilder.ResultLine);