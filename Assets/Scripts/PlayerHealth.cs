using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [field: SerializeField]
    public int MaxAmount { get; private set; }
    private float _amount;

    private void Awake()
    {
        _amount = MaxAmount;
        UIHandler.Instance.RepaintHealth(_amount, MaxAmount);
        
    }
    public void DealDamage(int damageAmount)
    {
        _amount -= damageAmount;
        UIHandler.Instance.RepaintHealth(_amount, MaxAmount);
        if (_amount <= 0f)
        {
            //Player is dead
            Time.timeScale = 0f;
            // Gameover Screen
            UIHandler.Instance.GameOver();
            
        }
    }

    public void Heal(int amount)
    {
        if (_amount == MaxAmount)
        {
            return;
        }
        _amount += amount;
        UIHandler.Instance.RepaintHealth(_amount, MaxAmount);
    }

    public void IncreaseMaxHealth()
    {
        MaxAmount += 1;
        UIHandler.Instance.RepaintHealth(_amount, MaxAmount);
        
    }

}
