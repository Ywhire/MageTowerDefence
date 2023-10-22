using System;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    private readonly List<Transform> targets = new List<Transform>();

    public Action<Enemy> HasEnemy;

    public Transform CurrentTarget { get { return FindNearestEnemy(); } }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        //There is a target in the range
        targets.Add(other.transform);
        other.GetComponent<Enemy>().DestroyEvent += RemoveTarget;
        HasEnemy?.Invoke(other.GetComponent<Enemy>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }
        //Find the target in the list and remove immediately
        RemoveTarget(other.transform);
        
    }

    private void RemoveTarget(Transform target)
    {
        Debug.Log("remove Tartget" + target) ;
        targets.Remove(target);
        target.GetComponent<Enemy>().DestroyEvent -= RemoveTarget;
    }

    private Transform FindNearestEnemy()
    {
        float nearEnemyDistance = float.MaxValue;
        int enemyIndex = 0;
        if (targets.Count == 0)
        {
            return null;
        }
        for (int i = 0; i < targets.Count; i++)
        {
            //Ignore the y-axis which is height of the target
            Vector2 targetPosXZ = new Vector2(targets[i].position.x, targets[i].position.z);

            //Tower is positioned in origin so no need for unnecesarry distance check
            if (nearEnemyDistance > targetPosXZ.SqrMagnitude())
            {
                nearEnemyDistance = targetPosXZ.SqrMagnitude();
                enemyIndex = i;
            }
        }
        return targets[enemyIndex];
    }
}
