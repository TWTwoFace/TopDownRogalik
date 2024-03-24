using System.Collections;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDeath;

    private void Start()
    {
        StartCoroutine(DeathCoroutine());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(_timeToDeath);
        Destroy(gameObject);
    }
}
