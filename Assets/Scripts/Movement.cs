using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 direction;
    Vector3 rotation;
    public float speed;
    public float rotationSpeed;
    public Spawner spawner;
    public static bool fall;
    public float extraSpeed;
    public GameObject DeathScreen;

    void Start()
    {
        direction = Vector3.forward;
        rotation = Vector3.right;
        fall = false;
    }

    
    void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            fall = true;
            DeathScreen.SetActive(true);
        }   
        if (fall == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = Quaternion.identity;
            if (direction.x == 0)
            {
    
                direction = Vector3.left;
                rotation = Vector3.forward;
                
            }
            else
            {
                direction = Vector3.forward;
                rotation = Vector3.right;
            }
            
        }

        speed += extraSpeed * Time.deltaTime;
        rotationSpeed += extraSpeed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * Time.deltaTime * speed;
        transform.position += movement;

        Vector3 rotations = rotation * Time.deltaTime * rotationSpeed;
        transform.Rotate(rotations);

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Score.score++;
            collision.gameObject.AddComponent<Rigidbody>();
            spawner.spawn_ground();
            StartCoroutine(DeleteGround(collision.gameObject));
        }
    }
    IEnumerator DeleteGround(GameObject deletedGrounds)
    {
        yield return new WaitForSeconds(2f);
        Destroy(deletedGrounds);
    }
}
