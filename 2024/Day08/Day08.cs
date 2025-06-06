using advent._2024.Day06;

namespace advent._2024.Day08;

public class Day08
{
    /*
     * Dla każdego typu anten:
     * [x] Znajdź wszystkie anteny danego typu
     * [x] Sporządź listę wszystkich możliwych połączeń między nimi
     * [x] Oblicz pozycje antynod
     * [x] Dodaj je do mapy sprawdzając też czy nie są poza mapą lub czy nie nachodzą na siebie
     * [] Automatyczne wykrywanie rodzajów anten
     * */

    private static Dictionary<char, AntennaType> Antennas = [];
    private static List<List<char>> Data = Helper.GetCharMatrix("../../../Day08/Data.txt");
    //private static List<List<char>> Data = Helper.GetCharMatrix("../../../TestData.txt");
    private static int sum = 0;
    
    public static void GetAnswer()
    {
        for (int i = 0; i < Data.Count; i++)
        {
            for (int j = 0; j < Data[i].Count; j++)
            {
                // it breaks lol
                char c = char.Parse(Data[i][j].ToString());
                if (Data[i][j] != '.' && Data[i][j] != '#' && !Antennas.ContainsKey(c))
                {
                    Antennas.TryAdd(c, new AntennaType(Data[i][j]));
                }
            }
        }
        
        Console.WriteLine(sum);
    }

    public class AntennaType
    {
        public List<Vector2Int> Positions  = [];
        private List<KeyValuePair<Vector2Int, Vector2Int>> Connections = [];
        private char Type { get; set; }

        public AntennaType(char type)
        {
            Type = type;
            GetData();
            ListPossibilities();
            CalculateAntinodes();
        }

        private void GetData()
        {
            Console.WriteLine($"Getting data for {Type}");
            for (int y = 0; y < Data.Count; y++)
                for (int x = 0; x < Data[y].Count; x++)
                    if (Data[y][x] == Type)
                        Positions.Add(new Vector2Int(y, x)); // [Y, X]
        }

        private void ListPossibilities()
        {
            if (Positions.Count <= 1) return;
            
            for (int i = 0; i < Positions.Count; i++)
            {
                for (int j = i + 1; j < Positions.Count; j++)
                {
                    Connections.Add(new KeyValuePair<Vector2Int, Vector2Int>(Positions[i], Positions[j]) );
                }
            }
        }

        private void CalculateAntinodes()
        {
            if (Positions.Count <= 1) return;
            
            foreach (var conn in Connections)
            {
                Vector2Int distance = new Vector2Int(conn.Key.X - conn.Value.X, conn.Key.Y - conn.Value.Y);

                Vector2Int antinode1 = new Vector2Int(conn.Key.X + distance.X, conn.Key.Y + distance.Y);
                Vector2Int antinode2 = new Vector2Int(conn.Value.X - distance.X, conn.Value.Y - distance.Y);
                
                if (antinode1.X <= Data[0].Count && antinode1.X >= 0 && antinode1.Y < Data.Count && antinode1.Y >= 0 && (Data[antinode1.X][antinode1.Y] == '.' || Data[antinode1.X][antinode1.Y] == '#'))
                {
                    Data[antinode1.X][antinode1.Y] = '#';
                    sum++;
                }
                
                if (antinode2.X <= Data[0].Count && antinode2.X >= 0 && antinode2.Y < Data.Count && antinode2.Y >= 0 && (Data[antinode2.X][antinode2.Y] == '.' || Data[antinode2.X][antinode2.Y] == '#'))
                {
                    Data[antinode2.X][antinode2.Y] = '#';
                    sum++;
                }
            }
            
        }
        
    }
}