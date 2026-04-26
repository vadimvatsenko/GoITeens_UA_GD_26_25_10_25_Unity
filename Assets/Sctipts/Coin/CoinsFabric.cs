using System.Collections.Generic;
using UnityEngine;

public class CoinsFabric : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject ground;
    [SerializeField] private int numsOfCouns = 10;
    
    private float _minX;
    private float _maxX;
    private float _minZ;
    private float _maxZ;

    private float _spawnY = 1;

    public List<GameObject> coins { get; private set; } = new List<GameObject>();

    private void Awake()
    {
        MeshRenderer groundRenderer = ground.GetComponent<MeshRenderer>();
        MeshRenderer coinRenderer = coinPrefab.GetComponent<MeshRenderer>();
        
        Bounds groundBounds = groundRenderer.bounds;
        Bounds coinBounds = coinRenderer.bounds;

        float offsetX = coinBounds.extents.x;
        float offsetZ =  coinBounds.extents.z;
        
        _minX = groundBounds.min.x + offsetX;
        _maxX = groundBounds.max.x - offsetX;
        _minZ = groundBounds.min.z + offsetZ;
        _maxZ = groundBounds.max.z - offsetZ;
    }

    private void Start()
    {
        GameObject coinFolder = new GameObject("CoinFolder");
        
        for (int i = 0; i < numsOfCouns; i++)
        {
            float x = Random.Range(_minX, _maxX);
            float z = Random.Range(_minZ, _maxZ);
            
            Vector3 spawnPosition = new Vector3(x, _spawnY, z);
            
            
            // додано
            GameObject coin 
                = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, coinFolder.transform);
            coins.Add(coin);
        }
    }
}
