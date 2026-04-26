using System;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 180f;
    [SerializeField] private int coinCost = 10;
    
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
            Destroy(this.gameObject);
        }
    }
}
