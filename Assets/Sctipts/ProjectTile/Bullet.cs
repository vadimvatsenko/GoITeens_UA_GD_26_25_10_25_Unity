using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float lifetime = 3f;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        SpawnBullet(Vector3.forward);
    }

    public void SpawnBullet(Vector3 direction)
    {
        direction = direction.normalized;
        _rb.AddForce(direction * moveSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }
}
