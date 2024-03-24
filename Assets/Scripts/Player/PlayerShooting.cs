using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Will be reorganized in future
    [SerializeField] private GameObject _weaponPrefab;

    private IWeapon _weapon;

    private bool _isShooting;

    private void Awake()
    {
        _weapon = _weaponPrefab.GetComponent<IWeapon>();
    }

    private void Update()
    {
        DetermineShooting();

        if (_isShooting)
        {
            _weapon.Shoot();
        }
    }

    private void DetermineShooting()
    {
        _isShooting = FireJoystickValues.Horizontal != 0f && FireJoystickValues.Vertical != 0f;
    }
}
