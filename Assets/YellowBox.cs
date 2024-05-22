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
 TankMovement tank = other.gameObject.GetComponent<TankMovement>();
	if(tank!=null)
		{
			StartCoroutine(PowerUp(tank));	
		}
}
public IEnumerator PowerUp(TankMovement tank)
	{
		_collider.enabled=false;
		art.SetActive(false);
		ActPower(tank);
		yield return new WaitForSeconds(duration);
		DeactPower(tank);
		Destroy(gameObject);	
	}

public void ActPower(TankMovement tank)
	{
		tank.SpeedBoost();
	}

public void DeactPower(TankMovement tank)
 	{	
		tank.ResetSpeed();
	}
   
}
