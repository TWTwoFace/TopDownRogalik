using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    [Header("Properties")]
    [SerializeField] private float _cooldown;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnBulletDot;

    private float _cooldownTimer;

    private void Start()
    {
        _cooldownTimer = _cooldown;
    }

    private void Update()
    {
        _cooldownTimer -= Time.deltaTime;
    }
    public void Shoot()
    {
        if (_cooldownTimer <= 0)
        {
            Instantiate(_bulletPrefab, _spawnBulletDot.position, transform.rotation);
            _cooldownTimer = _cooldown;
        }
    }
}
