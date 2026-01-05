using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Çò
/// </summary>
public class ball : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float ShootSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Shoot(Vector3 dir)
    {
        rb.AddForce(dir* ShootSpeed);
        transform.SetParent(null);
        Destroy(gameObject,10f);
    }
}
