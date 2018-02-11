using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerController : MonoBehaviour {

    public float speed = 10.0f;
    public LayerMask structure;
    public LayerMask ground;
    public LayerMask finish;
    public Transform feet;
    public float jumpHeight;
    public float gravity;
    public Text winText;

    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private int count;
    private CharacterController controller;

    // Use this for initialization
    void Start () {
        count = 1;
        gravity = 9.8f;
        jumpHeight = 3.0f;
        fallingVelocity = Vector3.zero;
        winText.text = "";
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * horiz * speed;
        Vector3 moveDirForward = transform.forward * vert * speed;

        controller.Move(moveDirSide * Time.deltaTime);
        controller.Move(moveDirForward * Time.deltaTime);
        bool isOnStructure = Physics.CheckSphere(feet.position, 0.1f, structure, QueryTriggerInteraction.Ignore);
        if (isOnStructure)
            fallingVelocity.y = 0f;
        else
            fallingVelocity.y -= gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isOnStructure)
        {
            fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
        }
        controller.Move(fallingVelocity * Time.deltaTime);

        bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
        if (isGrounded)
        {
            count++;
            winText.text = "Try:" + count;
            transform.position = new Vector3(-2.2f, 2f, -72.5f);
        }

        bool win = Physics.CheckSphere(feet.position, 0.1f, finish, QueryTriggerInteraction.Ignore);
        if (win)
        {
            winText.text = "You win in " + count + "try/tries";
        }

        if (Input.GetKeyDown("escape"))
        {
                Cursor.lockState = CursorLockMode.None;
        }
    }
}
