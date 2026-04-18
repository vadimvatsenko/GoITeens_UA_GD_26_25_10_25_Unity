using UnityEngine;
using UnityEngine.Events;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private UnityEvent<int> onTochCoin;

    private float currentZ = 0;

    private void Update()
    {
        currentZ += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(90f, 0, currentZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTochCoin?.Invoke(10);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
