
[System.Serializable]
public class GameData
{
    public int damage;
    public float rateOfFire;
    public float gold;
    public float luck;
    public int maxHealth;
    public int luckCount;
    public int damageCount;
    public int rateOfFireCount;
    public int maxHealthCount;
    public bool tutorialBool;

    public GameData()
    {
        damage = 5;
        rateOfFire = 2;
        tutorialBool = true;
        maxHealth = 4;
        luck = 0f;
        luckCount = 0;
        maxHealthCount = 0;
        rateOfFireCount = 0;
        damageCount = 0;
    }
}
