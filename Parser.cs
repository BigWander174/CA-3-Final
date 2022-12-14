namespace DeleteConsole
{
    internal class Parser
    {
        private string _info;
        private string[] _numbers;
        public Parser(string info)
        {
            _info = info;
            _numbers = GetOperation(info);
        }

        private string[] GetOperation(string info)
        {
            return info.Split(Operations.LogicalOperations.Keys.ToArray(), StringSplitOptions.None);
        }

        public string Rule
        {
            get
            {
                foreach (var number in _numbers)
                {
                    _info = _info.Replace(number, String.Empty);
                }

                return Operations.LogicalOperations[_info].ToEightBitBinary();
            }
        }

        public List<char> FirstLine
        {
            get
            {
                var converted = _numbers.Select(number => int.Parse(number).ToBinary()).ToList();

                var lengths = converted.Select(element => element.Length).ToList();

                var minIndex = lengths.IndexOf(lengths.Min());

                converted[minIndex] += new string('0', Math.Abs(converted[0].Length - converted[1].Length));

                var test = GetShuffle(converted);

                return test;
            }
        }

        private List<char> GetShuffle(List<string> binaries)
        {
            var subract = Enumerable.Range(0, binaries[0].Length * 2)
                                    .Select(i => ((i % 2 == 0) ? binaries[0] : binaries[1])[i / 2])
                                    .ToList();
            subract.Add('0');

            return subract;
        }
    }
}
