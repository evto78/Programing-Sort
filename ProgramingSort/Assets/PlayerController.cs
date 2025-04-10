using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //mechanical variables
    public int gCollected;
    public int rCollected;

    public TextMeshProUGUI grabageText;
    public TextMeshProUGUI recycingText;

    public int gLeft;
    public int rLeft;

    public TextMeshProUGUI grabageLeftText;
    public TextMeshProUGUI recycingLeftText;

    public GameObject garbage;
    public GameObject recycling;

    //movement variables
    Rigidbody rb;
    public float speed;

    // cam control variables
    public float sensitivity;
    public GameObject cam;
    float yaw = 0.0f;
    float pitch = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        gLeft = 0;
        rLeft = 0;
        foreach(GameObject rec in GameObject.FindGameObjectsWithTag("Recycling"))
        {
            rLeft++;
            if(Vector3.Distance(rec.transform.position, transform.position) < 1.5f && rCollected < 10)
            {
                Destroy(rec);
                rCollected++;
            }
        }
        foreach (GameObject gar in GameObject.FindGameObjectsWithTag("Garbage"))
        {
            gLeft++;
            if (Vector3.Distance(gar.transform.position, transform.position) < 1.5f && gCollected < 10)
            {
                Destroy(gar);
                gCollected++;
            }
        }

        grabageText.text = gCollected.ToString();
        recycingText.text = rCollected.ToString();

        grabageLeftText.text = gLeft.ToString();
        recycingLeftText.text = rLeft.ToString();

        CameraMove();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode.Acceleration);
        }
        if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            rb.velocity = rb.velocity / 1.1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(gCollected > 0)
            {
                GameObject spawnedTrash = Instantiate(garbage);
                spawnedTrash.transform.position = transform.position + transform.forward * 2f;
                spawnedTrash.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
                spawnedTrash.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
                gCollected--;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (rCollected > 0)
            {
                GameObject spawnedTrash = Instantiate(recycling);
                spawnedTrash.transform.position = transform.position + transform.forward * 2f;
                spawnedTrash.GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
                spawnedTrash.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
                rCollected--;
            }
        }
    }

    void CameraMove()
    {
        //get mouse input
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");

        //limit cam angle
        pitch = Mathf.Clamp(pitch, -85.0f, 85.0f);

        //set cam angle
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, transform.eulerAngles.z);
        cam.transform.eulerAngles = new Vector3(pitch, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
