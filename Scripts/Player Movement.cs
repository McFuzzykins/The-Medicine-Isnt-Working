using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private int hp = 5;

    private Rigidbody rb;

    private Vector3 vector;

    [SerializeField]
    public float horizontalSpeed = 2.0F;
    [SerializeField]
    public float verticalSpeed = 2.0F;

    [SerializeField]
    private int speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vector = new Vector3(0, 100, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        if (hp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(sceneName: "Lose Screen");
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Door")
        {
            Debug.Log("Door");
        }
        else if (collider.gameObject.tag == "WinCon")
        {
            Debug.Log("You Win! Now burn it down!");
            SceneManager.LoadScene(sceneName: "Win Screen");
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Ouch!");
            hp -= 1;
        }
    }
}