using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class characterScript : MonoBehaviour
{
    public GameObject Button;
    public GameObject Button2;
    public GameObject Platform1;
    public GameObject Platform2;
    public GameObject Key;

    public bool ButtonPressed1 = false;
    public float rotationSpeed = 5;
    public float movementSpeed = 5;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float threshold = 400;

    public Text countText;
    private int count = 0;
    public bool isGrounded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        SetCountText();
    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("I hit somthing");
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
        countText.text = "Keys Collected: " + count.ToString();
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
            transform.position = new Vector3(471.26f, 144.076f, 410.06f);
        }
    }
}
