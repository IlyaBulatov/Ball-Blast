using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInputControl : MonoBehaviour
{
    [SerializeField] private Cart cart;

    private void Update()
    {
        cart.SetMovementTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}