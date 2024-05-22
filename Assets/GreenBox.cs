using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBox : MonoBehaviour
{

    public GameObject art=null;
    public Collider _collider;

    private void Awake()
    {
        _collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
	if (other.gameObject.CompareTag("TankFree_Blue"))
	{	
        PlayerStats tank = other.gameObject.GetComponent<PlayerStats>();
        if(tank!=null)
        {
            tank.ResetHealth();
            Destroy(gameObject);
        }
    }
  	}
   


}