using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBox : MonoBehaviour
{ public float duration = 5f;
    public float damageIncrease = -10f; // Amount of damage increase
    public bool smth=false;
    public GameObject art = null;
    public Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TankMovementv2 tank = other.gameObject.GetComponent<TankMovementv2>();
        if (tank != null)
        {
            StartCoroutine(PowerUp(tank));
        }
    }

    public IEnumerator PowerUp(TankMovementv2 tank)
    {
        _collider.enabled = false;
        art.SetActive(false);
        ActPower(tank);
        smth = true;
        yield return new WaitForSeconds(duration);
        DeactPower(tank);
        smth = false;
        Destroy(gameObject);
    }

    public void ActPower(TankMovementv2 tank)
    {
        // Apply damage increase to bullets
        PowerUpManager.Instance.ModifyEnemyBulletDamage(damageIncrease);
    }

    public void DeactPower(TankMovementv2 tank)
    {
        // Reset bullet damage to default
        PowerUpManager.Instance.ResetEnemyBulletDamage();
    }
}
