using System;
using ThirdParty;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public Bullet bulletPrefab;

	public Transform gun;

	private void Update()
	{
		Plane plane = new Plane(Vector3.up, base.transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if (plane.Raycast(ray, out distance))
		{
			Vector3 forward = Vector3.Normalize(ray.GetPoint(distance) - base.transform.position);
			Quaternion to = Quaternion.LookRotation(forward);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, to, 360f * Time.deltaTime);
			if (Input.GetMouseButtonDown(0))
			{
				this.bulletPrefab.Spawn(this.gun.position, this.gun.rotation);
			}
		}
	}
}
