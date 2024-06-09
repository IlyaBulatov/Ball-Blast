using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float vehicleWidth;

    [Header("Wheels")]
    [SerializeField] private Transform[] wheels;
    [SerializeField] private float wheelRadius;

    private Vector3 movementTarget;
    private float deltaMovement;
    private float lastPositionX;

    private void Start()
    {
        movementTarget = transform.position;
    }
    private void Update()
    {
        Move();

        RotateWheel();
    }
    private void Move()
    {
        lastPositionX = transform.position.x;

        transform.position = Vector3.MoveTowards
            (transform.position, movementTarget, movementSpeed * Time.deltaTime);

        deltaMovement = transform.position.x - lastPositionX;
    }
    private void RotateWheel()
    {
        float angle = (180 * deltaMovement) / (Mathf.PI * wheelRadius * 2);

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].Rotate(0, 0, -angle);
        }
    }
    public void SetMovementTarget(Vector3 target)
    {
        movementTarget = ClampMovementTarget(target);
    }
    private Vector3 ClampMovementTarget(Vector3 target)
    {
        float leftBorder = -8.75f + vehicleWidth * 0.5f;
        float rightBorder = 8.75f - vehicleWidth * 0.5f;

        Vector3 moveTarget = target;
        moveTarget.z = transform.position.z;
        moveTarget.y = transform.position.y;

        if(moveTarget.x < leftBorder) moveTarget.x = leftBorder;
        if(moveTarget.x > rightBorder) moveTarget.x = rightBorder;

        return moveTarget;
    }
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position - new Vector3
            (vehicleWidth * 0.5f, 0.5f, 0), 
            transform.position + new Vector3(vehicleWidth * 0.5f, -0.5f, 0));
    }
    #endif
}