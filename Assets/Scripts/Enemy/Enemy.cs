using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    [field: SerializeField]
    public float HealthMaxAmount { get; private set; }
    private float _healthAmount;

    [SerializeField]
    private Slider _slider;
    
    private Camera _camera;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform _sliderTransform;
    [field: SerializeField]
    public int BaseDamage { get; private set; }

    public Action<Transform> DestroyEvent;
    // int values gold and magic dust respectively
    public Action<int, int, Enemy> Loot;

    private bool _killed = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        other.GetComponent<PlayerHealth>().DealDamage(BaseDamage);
        _killed = false;
        Destroy(gameObject);
    }
    private void Start()
    {
        _healthAmount = HealthMaxAmount;
        UpdateHealthBar();  

        _camera = Camera.main;
        _sliderTransform = _slider.GetComponent<Transform>();
    }

    private void Update()
    {
        _sliderTransform.rotation = _camera.transform.rotation;
    }
    private void OnDestroy()
    {
        DestroyEvent?.Invoke(transform);
        if (_killed)
        {
            var gold = UnityEngine.Random.Range(0, Convert.ToInt32(HealthMaxAmount / 2));
            var magicDust = UnityEngine.Random.Range(Convert.ToInt32(HealthMaxAmount / 2), Convert.ToInt32(HealthMaxAmount));

            Loot?.Invoke(gold, magicDust, this);
        }

    }

    private void UpdateHealthBar()
    {
        _slider.value = _healthAmount / HealthMaxAmount;
    }
    public void DealDamage(float damageAmount)
    {
        _healthAmount -= damageAmount;
        UpdateHealthBar();

        if (_healthAmount <= 0f)
        {
            //Enemy is dead
            Destroy(gameObject);
        } 
    }

    
}
