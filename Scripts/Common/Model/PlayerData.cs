using System.Collections;
using System.Collections.Generic;


public class PlayerData
{
    private int _hp;
    public int HP { get; set; }

    private int _score;
    public int Score { get; set; }

    private int _level;
    public int Level { get; set; }

    private int _isHelmetArmed;
    public bool IsHelmetArmed { get; set; }

    public void SaveData(int hp, int score, int level, bool ishelmetArmed)
    {
        HP = hp;
        Score = score;
        Level = level;
        IsHelmetArmed = ishelmetArmed;
    }



}
