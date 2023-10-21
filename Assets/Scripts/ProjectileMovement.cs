using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Transform _target;
    private Vector3 _lastPosition;
    private float _speed;
    private const float _acceleration = 5;
    private float _damage ;
    
    void Update()
    {
        Vector3 direction;
        if (_target == null)
        {
            direction  = (_lastPosition - transform.position).normalized;

            transform.Translate(_speed * _speed * Time.deltaTime * direction);

            _speed += Time.deltaTime * _acceleration;

            if ((_lastPosition - transform.position).sqrMagnitude <= 0.1f)
            {
                Destroy(gameObject);
            }
            return;
        }

        direction = (_target.position - transform.position).normalized;

        transform.Translate(_speed * _speed * Time.deltaTime * direction);

        _speed += Time.deltaTime * _acceleration;

        _lastPosition = _target.position;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
        {
            return;
        }
        other.GetComponent<Enemy>().DealDamage(_damage);
        Destroy(gameObject);

    }
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
}
