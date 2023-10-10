using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private int maxHp = 100;
    private int curHp;

    private Rigidbody rb;

    private Vector3 vector;

    private int pillCount;

    [SerializeField]
    public float horizontalSpeed = 2.0F;
    [SerializeField]
    public float verticalSpeed = 2.0F;
    [SerializeField]
    private Slider healthbar;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    private TMP_Text pills;
    [SerializeField]
    private Slider psychosisBar;
    [SerializeField]
    private Image meter;

    [SerializeField]
    private int speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        vector = new Vector3(0, 100, 0);
        SetHealthInitial(maxHp);
        pillCount = 0;
        pills.SetText("Pills: " + pillCount);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        if (curHp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(sceneName: "Lose Screen");
        }
        else if (pillCount == 3)
        {
            SceneManager.LoadScene(sceneName: "Win Screen");
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
            ++pillCount;
            pills.SetText("Pills: " + pillCount);
            Destroy(collider.gameObject);   
        }
        else if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("Ouch!");
            curHp -= 10;
            UpdateHealth(curHp);
        }
    }

    public void SetHealthInitial(int hp)
    {
        healthbar.maxValue = hp;
        healthbar.value = hp;
        curHp = hp;
    }

    public void UpdateHealth(int currentHp)
    {
        healthbar.value = currentHp;
    }

    public void SetPsychosisInitial(int hp)
    {
        psychosisBar.maxValue = 3;
        psychosisBar.value = pillCount;
    }
}