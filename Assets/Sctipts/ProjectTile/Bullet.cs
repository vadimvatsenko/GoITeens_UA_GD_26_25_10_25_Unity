using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float lifetime = 3f;
    
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SpawnBullet(Vector3 direction)
    {
        direction = direction.normalized;
        _rb.AddForce(direction * moveSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }
}
