using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xMax = 7.84f;
    public bool canMove = true;

    private void Update() {
        if (canMove) {
            Move();
        }
    }

    private void Move() {
        float inputX = Input.GetAxis("Horizontal");
        
        transform.position += Time.deltaTime * 20 * Vector3.right * inputX;
        float xPos = Mathf.Clamp(transform.position.x, -xMax, xMax);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
