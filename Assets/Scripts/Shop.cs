using UnityEngine;

public class Shop 
{
    public int upgradeDamageCount;
    public int DamageCost { get; private set; }
    private int _damageBaseCost;

    private int _upgradeRateOfFireCount;
    public float RateOfFireCost { get; private set; }
    private int _rateOfFireBaseCost;

    public float LuckCost { get; private set; }
    private int _luckBaseCost;

    private int _upgradeHealthCount;
    public float HealthGainCost { get; private set; }
    private int _healthGainBaseCost ;
    public int GainHealthAmount;

    private int _upgradeMaxHealthCount;
    public float MaxHealthCost { get; private set; }
    private int _maxHealthBaseCost;

    private int _upgradeLuckShopCount;

    public float LuckShopCost { get; private set; }
    private int _luckShopBaseCost; 

    private int _upgradeRateOfFireShopCount;
    public float RateOfFireShopCost { get; private set; }
    private int _rateOfFireShopBaseCost;

    private int upgradeDamageShopCount;
    public float DamageShopCost { get; private set; }
    private int _damageShopBaseCost;

    public Shop()
    {
        _damageBaseCost = 20;
        _rateOfFireBaseCost = 7;
        _luckBaseCost = 50;
        _healthGainBaseCost = 100;
        GainHealthAmount = 1;
        _maxHealthBaseCost = 75;
        _luckShopBaseCost = 25;
        _rateOfFireShopBaseCost = 4;
        _damageShopBaseCost = 10;

        DamageCost = _damageBaseCost;
        RateOfFireCost = _rateOfFireBaseCost;
        LuckCost = _luckBaseCost;
        HealthGainCost = _healthGainBaseCost;
        MaxHealthCost = _maxHealthBaseCost;
        LuckShopCost = _luckBaseCost;
        RateOfFireShopCost = _rateOfFireShopBaseCost;
        DamageShopCost = _damageShopBaseCost;
    }

    public void UpdateDamageCost()
    {
        upgradeDamageCount++;
        DamageCost = _damageBaseCost + upgradeDamageCount * _damageBaseCost / 2;

    }
    public void UpdateRateOfFireCost()
    {
        _upgradeRateOfFireCount++;
        RateOfFireCost = _rateOfFireBaseCost + _upgradeRateOfFireCount * _rateOfFireBaseCost / 2f;
    }
    public void UpdateLuckCost()
    {
        LuckCost += _luckBaseCost;
    }

    public void UpdateGainHealthCost()
    {
        _upgradeHealthCount++;
        HealthGainCost += _healthGainBaseCost * _upgradeHealthCount;
    }

    public void UpdateMaxHealthCost()
    {
        _upgradeHealthCount++;
        MaxHealthCost += _maxHealthBaseCost * _upgradeMaxHealthCount;
    }
    public void UpdateLuckShopCost()
    {
        _upgradeLuckShopCount++;
        LuckShopCost += _luckShopBaseCost;
    }

    public void UpdateRateOfFireShopCost()
    {
        _upgradeRateOfFireShopCount++;
        RateOfFireShopCost = _rateOfFireShopBaseCost + _upgradeRateOfFireShopCount * _rateOfFireShopBaseCost / 2f;
    }

    public void UpdateDamageShopCost()
    {
        upgradeDamageShopCount++;
        DamageShopCost = _damageShopBaseCost + upgradeDamageShopCount * _damageShopBaseCost / 2;
    }
}
