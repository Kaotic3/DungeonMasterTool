namespace DungeonMasterv4
{
    public partial class MainWindow
    {
        public class BattleMonster
        {
            public int ID { get; set; }
            public string Creature { get; set; }
            public int CRBase { get; set; }
            public int CRRange { get; set; }
            public string Type { get; set; }
            public string Size { get; set; }
            public int AC { get; set; }
            public int HP { get; set; }
            public string Speed { get; set; }
            public string Alignment { get; set; }

            public string CreatureSet
            {
                get
                {
                    return $"{Creature},AC: {AC},HP: {HP}";
                }
            }
        }
    }
}
