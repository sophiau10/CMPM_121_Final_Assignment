using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterScript : MonoBehaviour
{
    public GameObject Button;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;
    public GameObject Button6;
    public GameObject Button7;
    public GameObject Platform1;
    public GameObject Platform2;
    public GameObject Platform3;
    public GameObject Platform4;
    public GameObject Platform5;
    public GameObject Platform6;
    public GameObject Platform7;
    public GameObject Door;
    public GameObject Key;
    public GameObject WinScene;

    public bool ButtonPressed1 = false;
    public float rotationSpeed = 5;
    public float movementSpeed = 5;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float threshold = 400;
    public float delay = 0;

    public Text countText;
    public Text healthText;
    public Text doorText;
    private int count = 0;
    private int health = 10;
    public bool isGrounded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        doorText.enabled = false;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        SetCountText();
        SetHealthText();
    }
    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("I hit somthing");
        if(col.gameObject.tag == "Fireball")
        {
            health = health - 1;
            SetHealthText();
        }
        if(col.name == "Door")
        {
            if (count == 1)
            {
                Door.GetComponent<Animator>().SetBool("HaveKey", true);
            }
            else
            {
                doorText.enabled = true;
            }
        }
        if (col.name == "WinScene")
        {
            SceneManager.LoadScene("You Win");
        }
        {
            Platform1.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button")
        {
            Platform1.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button2")
        {
            Platform2.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button2.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button3")
        {
            Platform3.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button3.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button4")
        {
            Platform4.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button4.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button5")
        {
            Platform5.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button5.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button6")
        {
            Platform6.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button6.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Button7")
        {
            Platform7.GetComponent<Animator>().SetBool("ButtonPressed", true);
            Button7.GetComponent<Animator>().SetBool("ButtonPressed", true);
        }
        if (col.name == "Key")
        {
            //Instantiate(particles, transform.position, transform.rotation);
            Debug.Log("We have hit " + col.name);
            Destroy(col.gameObject);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Keys: " + count.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Rotate left and right
        if (Input.GetAxis("Mouse X") < -.1)
        {
            transform.Rotate(Vector3.down * rotationSpeed);
        }
        if (Input.GetAxis("Mouse X") > .1)
        {
            transform.Rotate(Vector3.down * -rotationSpeed);
        }

        //move
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        //falling
        if (transform.position.y < threshold)
        {
            SceneManager.LoadScene("FallDeath");
        }
        if(health==0)
        {
            SceneManager.LoadScene("FireDeath");
        }

        if(doorText.enabled ==true)
        {
            delay++;
            if(delay>50)
            {
                doorText.enabled = false;
                delay = 0;
            }
        }
    }
}
