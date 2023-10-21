using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [field:SerializeField]
    public float Speed { get; private set; }
    
    [field: SerializeField]
    public float SpawnTime { get; private set; }

    //TODO: this is going to be list 
    [field: SerializeField]
    public GameObject SpawnObject { get; private set; }
    [field: SerializeField]
    public List<Transform> SpawnPoints { get; private set; }

    [field: SerializeField, Header("Info UI")]
    public TMPro.TMP_Text TMPWave { get; private set; }

    private int _waveCount;

    private float timer;

    private int _enemyCount;
    private int _enemySpawnCount;

    private const int defaultEnemyCount = 10;

    private void Start()
    {
        _enemySpawnCount = _enemyCount = defaultEnemyCount;
        _waveCount = 1;
        TMPWave.text = "Wave: " + _waveCount + "/10";
    }
    private void Update()
    {
        timer += Time.deltaTime;

        transform.Rotate(new Vector3(0,Speed * Time.deltaTime,0));

        if (timer > SpawnTime && _enemySpawnCount > 0)
        {
            timer = 0f;
            var index = Random.Range(0,SpawnPoints.Count);
            var e = Instantiate(SpawnObject, SpawnPoints[index].position , Quaternion.identity);
            e.GetComponent<Enemy>().DestroyEvent += DecreaseEnemy;
            _enemySpawnCount--;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 30);
    }
    
    private void DecreaseEnemy(Transform obj)
    {
        _enemyCount--;
        if (_enemyCount == 0)
        {
            
            NextWave();
        }
        obj.GetComponent<Enemy>().DestroyEvent -= DecreaseEnemy;
    }

    private void NextWave()
    {
        
        _waveCount++;
        _enemyCount = defaultEnemyCount + Random.Range(defaultEnemyCount * _waveCount / 2, 
            defaultEnemyCount * _waveCount);
        _enemySpawnCount = _enemyCount;

        SpawnTime -= SpawnTime * 25 / 100;

        TMPWave.text = "Wave: " + _waveCount + "/10";
    }

    
}
