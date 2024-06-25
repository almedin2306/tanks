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
        PlayerStats tank = other.gameObject.GetComponent<PlayerStats>();
        if (tank != null)
        {
            StartCoroutine(PowerUp(tank));
        }
    }

    public IEnumerator PowerUp(PlayerStats tank)
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

    public void ActPower(PlayerStats tank)
    {
        // Apply damage increase to bullets
        tank.PlayerHealth = tank.PlayerHealth * 2;
    }

    public void DeactPower(PlayerStats tank)
    {
        // Reset bullet damage to default
        tank.PlayerHealth = tank.PlayerHealth / 2;

    }
}
