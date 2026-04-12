using UnityEngine;

public class ScaleCube : MonoBehaviour
{
    private Vector3 scale = Vector3.one * 5;
    private float _duration = 5;
    private float _time = 0;
    private void Start()
    {
        Debug.Log(transform.localScale);
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * 2;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float t = _time / _duration;
        transform.localScale = Vector3.Lerp(transform.localScale, scale, t);
    }
}
