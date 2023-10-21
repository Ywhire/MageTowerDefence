using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float Gold { get; private set; } = 10000;
    public float MagicDust { get; private set; } = 10000;
    public float LuckIncreaseValue { get; private set; }

    [field: SerializeField]
    public ProjectileSpawner Spawner { get; private set; }
    [field: SerializeField]
    public PlayerHealth PlayerHealth { get; private set; }  
    [field:SerializeField]
    public Targeter Targeter { get; private set; }

    private Shop Shop;
    private float Luck;
    private float _baseLuck;

    private void Awake()
    {
        Shop = new Shop();
        LuckIncreaseValue = 0.1f;
        Luck = _baseLuck;
        UIHandler.Instance.RepaintCosts(Shop.DamageCost, Shop.RateOfFireCost, Shop.LuckCost, Shop.GainHealthAmount, Shop.HealthGainCost);
        UIHandler.Instance.RepaintMaterial(Gold, MagicDust);
        UIHandler.Instance.RepaintBaseLuck(_baseLuck);
        UIHandler.Instance.RepaintLuck(Luck);
    }
    private void Start()
    {
        if (MagicDust < Shop.DamageCost)
        {
            UIHandler.Instance.SpellDamageButton.interactable = false;
        }

        if (MagicDust < Shop.RateOfFireCost)
        {
            UIHandler.Instance.RateOfFireButton.interactable = false;
        }

        if (MagicDust < Shop.LuckCost)
        {
            UIHandler.Instance.LuckButton.interactable = false;
        }

        if (MagicDust < Shop.HealthGainCost)
        {
            UIHandler.Instance.GainHealthButton.interactable = false;
        }
    }
    private void Update()
    {
        if (Gold < Shop.DamageShopCost)
        {
            UIHandler.Instance.SpellDamageShopButton.interactable = false;
        }
        else
        {
            UIHandler.Instance.SpellDamageShopButton.interactable = true;
        }


        if (MagicDust < Shop.DamageCost)
        {
            UIHandler.Instance.SpellDamageButton.interactable = false;
        }
        else
        {
            UIHandler.Instance.SpellDamageButton.interactable = true;
        }
        
        if (MagicDust < Shop.RateOfFireCost)
        {
            UIHandler.Instance.RateOfFireButton.interactable = false;
        }
        else
        {
            UIHandler.Instance.RateOfFireButton.interactable= true;
        }

        if (MagicDust < Shop.LuckCost)
        {
            UIHandler.Instance.LuckButton.interactable = false;
        }
        else
        {
            UIHandler.Instance.LuckButton.interactable = true;
        }

        if (MagicDust < Shop.HealthGainCost)
        {
            UIHandler.Instance.GainHealthButton.interactable = false;
        }
        else
        {
            UIHandler.Instance.GainHealthButton.interactable = true;
        }
    }

    private void OnEnable()
    {
        Targeter.HasEnemy += HandleEnemy;
        UIHandler.Instance.Buy += DecreaseMagicDust;       
        UIHandler.Instance.ShopBuy += DecreaseGold;       
    }

    private void OnDisable()
    {
        Targeter.HasEnemy -= HandleEnemy;
        UIHandler.Instance.Buy -= DecreaseMagicDust;
    }

    private void DecreaseGold(int value)
    {
        //Seriliazation will be addded
        if (value == 0)
        {
            Gold -= Shop.MaxHealthCost;
            Shop.UpdateMaxHealthCost();
            PlayerHealth.IncreaseMaxHealth();
            
            UIHandler.Instance.RepaintMaxHealthCost(Shop.MaxHealthCost);
        }else if (value == 1)
        {
            Gold -= Shop.LuckShopCost;
            Shop.UpdateLuckShopCost();
            IncreaseBaseLuck();
            
            UIHandler.Instance.RepaintLuckShopCost(Shop.LuckShopCost);
        }
        else if (value == 2)
        {
            Gold -= Shop.RateOfFireShopCost;
            Shop.UpdateRateOfFireShopCost();
            Spawner.UpgradeBaseRateOfFire();
            
            UIHandler.Instance.RepaintRateOfFireShopCost(Shop.RateOfFireShopCost);
        }
        else if (value == 3)
        {
            Gold -= Shop.DamageShopCost;
            Shop.UpdateDamageShopCost();
            Spawner.UpgradeBaseDamage();
            
            UIHandler.Instance.RepaintDamageShopCost(Shop.DamageShopCost);
        }
        UIHandler.Instance.RepaintMaterial(Gold, MagicDust);
    }
    private void DecreaseMagicDust(int value)
    {
        if (value == 0)
        {
            MagicDust -= Shop.DamageCost;
            Shop.UpdateDamageCost();
            Spawner.UpgradeTotalDamage(Shop.upgradeDamageCount);           
            UIHandler.Instance.RepaintDamageCost(Shop.DamageCost);
        }
        else if (value == 1)
        {
            MagicDust -= Shop.RateOfFireCost;
            Shop.UpdateRateOfFireCost();
            Spawner.UpgradeRateOfFire();
            
            UIHandler.Instance.RepaintRateOfFireCost(Shop.RateOfFireCost);
        }
        else if (value == 2)
        {
            MagicDust -= Shop.LuckCost;
            Shop.UpdateLuckCost();
            IncreaseLuck();
            
            UIHandler.Instance.RepaintLuckCost(Shop.LuckCost);
        }
        else if (value == 3)
        {
            MagicDust -= Shop.HealthGainCost;
            Shop.UpdateGainHealthCost();
            PlayerHealth.Heal(Shop.GainHealthAmount);
            
            UIHandler.Instance.RepaintGainHealthCost(Shop.HealthGainCost);
        }
        
        UIHandler.Instance.RepaintMaterial(Gold, MagicDust);
    }

    private void IncreaseBaseLuck()
    {
        _baseLuck += LuckIncreaseValue;
        UIHandler.Instance.RepaintBaseLuck(_baseLuck);
    }
    private void IncreaseLuck()
    {
        Luck += LuckIncreaseValue;    
        UIHandler.Instance.RepaintLuck(Luck);
    }

    
    private void HandleEnemy(Enemy e)
    {
        e.Loot += IncreaseMaterial;
    }

    private void IncreaseMaterial(int gold, int magicDust, Enemy e)
    {
        var dice = UnityEngine.Random.Range(0, 100);
        var extraGold = 0;
        var extraMagicDust = 0;
        if (Luck > dice)
        {
            extraGold = dice + gold / 2;
            extraMagicDust = dice + magicDust / 2;
        }

        Gold += gold + extraGold;
        MagicDust += magicDust + extraMagicDust;
        UIHandler.Instance.RepaintMaterial(Gold, MagicDust);
        e.Loot -= IncreaseMaterial;
    }
}
