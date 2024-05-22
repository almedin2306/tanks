using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    public float duration = 5f;
    public float damageIncrease = 50f; // Amount of damage increase

    public GameObject art = null;
    public Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TankMovement tank = other.gameObject.GetComponent<TankMovement>();
        if (tank != null)
        {
            StartCoroutine(PowerUp(tank));
        }
    }

    public IEnumerator PowerUp(TankMovement tank)
    {
        _collider.enabled = false;
        art.SetActive(false);
        ActPower(tank);
        yield return new WaitForSeconds(duration);
        DeactPower(tank);
        Destroy(gameObject);
    }

    public void ActPower(TankMovement tank)
    {
        // Apply damage increase to bullets
        PowerUpManager.Instance.ModifyBulletDamage(damageIncrease);
    }

    public void DeactPower(TankMovement tank)
    {
        // Reset bullet damage to default
        PowerUpManager.Instance.ResetBulletDamage();
    }
}
