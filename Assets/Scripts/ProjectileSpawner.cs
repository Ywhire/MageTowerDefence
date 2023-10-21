using System;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private float _rateOfFire ;
    [field:SerializeField]
    public GameObject BasicSpell { get; private set; }
    [field:SerializeField]
    public Targeter Targeter{ get; private set; }

    private float _totalPassedTime;

    private int _baseDamage = 5;

    private float _totalDamage;
    private float _baseRateOfFire = 2f;

    private void Awake()
    {
        _totalDamage = _baseDamage;
        _rateOfFire = _baseRateOfFire;
        UIHandler.Instance.RepaintDamage(_totalDamage);
        UIHandler.Instance.RepaintBaseDamage(_totalDamage);
        UIHandler.Instance.RepaintRateOfFire(_rateOfFire);
        UIHandler.Instance.RepaintBaseRateOfFire(_rateOfFire);      
    }

    private void Update()
    {
        _totalPassedTime += Time.deltaTime;

        if (_totalPassedTime > _rateOfFire)
        {
            // Is there an enemy
            if (Targeter.CurrentTarget == null)
            {
                return;
            }
            _totalPassedTime = 0f;
            GameObject bSpell = Instantiate(BasicSpell, transform.position, Quaternion.identity);
            var projectileMovement = bSpell.GetComponent<ProjectileMovement>();

            projectileMovement.SetTarget(Targeter.CurrentTarget);

            projectileMovement.SetDamage(_totalDamage);
            
        }

    }

    public void UpgradeBaseDamage()
    {
        _baseDamage += 1;
        UIHandler.Instance.RepaintBaseDamage(_baseDamage);
    }
    public void UpgradeTotalDamage(int upgradeCount)
    {
        _totalDamage = _baseDamage + _baseDamage * upgradeCount * 1f / 20f;
        Debug.Log("Damage:" + _totalDamage);
        UIHandler.Instance.RepaintDamage(_totalDamage);
    }

    public void UpgradeRateOfFire()
    {
        _rateOfFire -= 1f/50f;
        UIHandler.Instance.RepaintRateOfFire(_rateOfFire);
    }

    public void UpgradeBaseRateOfFire()
    {
        _baseRateOfFire -= 1f / 50f;
        UIHandler.Instance.RepaintBaseRateOfFire(_rateOfFire);
    }
}
