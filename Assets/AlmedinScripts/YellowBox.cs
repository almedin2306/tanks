using UnityEngine;
using System.Collections;


public class YellowBox : MonoBehaviour
{
    public float duration = 5f;
    public float increase = 5f;

	public GameObject art=null;
	public Collider _collider;

private void Awake()
{
 _collider= GetComponent<Collider>();
}

 private void OnTriggerEnter(Collider other)
{
 TankMovementv2 tank = other.gameObject.GetComponent<TankMovementv2>();
	if(tank!=null)
		{
			StartCoroutine(PowerUp(tank));	
		}
}
public IEnumerator PowerUp(TankMovementv2 tank)
	{
		_collider.enabled=false;
		art.SetActive(false);
		ActPower(tank);
		yield return new WaitForSeconds(duration);
		DeactPower(tank);
		Destroy(gameObject);	
	}

public void ActPower(TankMovementv2 tank)
	{
		tank.SpeedBoost();
	}

public void DeactPower(TankMovementv2 tank)
 	{	
		tank.ResetSpeed();
	}
   
}
