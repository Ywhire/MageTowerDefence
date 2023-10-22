using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [field:SerializeField]
    public CharacterController CharacterController { get; private set; }

    [field: SerializeField]
    public Animator Animator { get; private set; }

    [field: SerializeField]
    public float RotationSmooth { get; private set; }
    [field: SerializeField]
    public float Speed { get; private set; }
    [SerializeField, Header("Debug")]
    public bool Kill;

    private void Update()
    {
        AnimatorStateInfo stateInfo = Animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime < 1f && stateInfo.IsTag("Die"))
        {
            //Wait
            return;
        }
        else if (stateInfo.normalizedTime >= 1f && stateInfo.IsTag("Die"))
        {
            Destroy(gameObject);
            return;
        }
       
        Vector3 direction = Vector3.zero - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(direction.normalized), RotationSmooth * Time.deltaTime);

        CharacterController.Move(transform.forward * Speed * Time.deltaTime);
        if (Kill)
        {
            Destroy(gameObject);
        }
    }
}
