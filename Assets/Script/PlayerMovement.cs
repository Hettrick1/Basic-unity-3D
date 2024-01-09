using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private GameObject spawnBullet;
    [SerializeField] private GameObject bullet;
    private Rigidbody rb;
    private bool isRunning;
    private Vector2 input;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 desiredRotation = new Vector3(0, input.x * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(desiredRotation));

        Vector3 movement = new Vector3(transform.forward.x * input.y * speed * Time.deltaTime, 0, transform.forward.z * input.y * speed * Time.deltaTime);
        rb.MovePosition(transform.position +  movement);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            speed = runSpeed;
        }
        else
        {
            isRunning = false;
            speed = walkSpeed;
        }
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void Shoot()
    {
        Instantiate(bullet, spawnBullet.transform.position, rb.rotation);
    }
}
