using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 0.9f;

    private void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float movementSpeed) { this.movementSpeed = movementSpeed; }
}
