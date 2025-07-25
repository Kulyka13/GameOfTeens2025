using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private int rotationSpeed;
	private void Update()
	{
		Rotate();
	}
	private void Rotate()
	{
		float rotationInput = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime * 10);
	}
}
