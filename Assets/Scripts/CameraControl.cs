using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    Vector3 spawmPoint;
    #region Old
    /*
    [SerializeField] GameObject parentXRef;
    [SerializeField] GameObject parentYRef;
    float cameraH, cameraV;
    float speedX = 360f,speedY = 360f;
    Vector3 direction;
    float moveSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        MoveCharacter();
    }

    void MoveCamera()
    {
        cameraH = Mathf.Clamp(Input.GetAxisRaw("Mouse X"),-90,90);
        
        cameraV = Mathf.Clamp(Input.GetAxisRaw("Mouse Y"), -90, 90);
        parentYRef.transform.Rotate(Vector3.up, cameraH * speedY * Time.deltaTime); //rotates based on parent x
        parentXRef.transform.Rotate(Vector3.right, -cameraV * speedX * Time.deltaTime);
    }
    void MoveCharacter()
    {
        bool leftKey = Input.GetKey(KeyCode.LeftArrow);
        bool rightKey = Input.GetKey(KeyCode.RightArrow);
        bool upKey = Input.GetKey(KeyCode.UpArrow);
        bool downKey = Input.GetKey(KeyCode.DownArrow);

        Vector3 movement = Vector3.zero;

        if (leftKey)
        {
            movement.x--;
        }
        if (rightKey)
        {
            movement.x++;
        }
        if (upKey)
        {
            movement.z++;
        }
        if (downKey)
        {
            movement.z--;
        }

        movement = movement.normalized;

        movement.x *= moveSpeed;
        movement.z *= moveSpeed;

        // we changed the coordinate space from World to Self because we want "up" to mean "in front of us" regardless of our orientation
        this.transform.Translate(movement * Time.deltaTime, Space.Self);
    }
    */
    #endregion

    [SerializeField] Camera playerCam;
    bool inDeskArea = false;
    public int score;
    public bool allowMove = true;
    // public parameters are serialized, which means they're saved inside the scene and editable from Unity's interface
    public float speedX = 1;
    public float speedZ = 1;

    Rigidbody rb;
    // We reference GameObjects here so they can be assigned from Unity's interface.
    public GameObject yParent;
    public GameObject xParent;

    public float rotateSpeedX = 90f;
    public float rotateSpeedY = 90f;

    bool onGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setSpawn();
    }
    void Update()
    {
        // subdividing Update between other functions makes it clean and readable
        
       
        if (allowMove)
        {
            HandleRotation();
            HandleMovement();
        }
       
    }

    


    #region character controller

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X"); // rotate around the Y axis to look left/right
        float mouseY = Input.GetAxis("Mouse Y"); // rotate around the X axis to look up/down 

        // rotation is split across two objects (one per axis) so it doesn't mix up and generate unwanted Z-rotation

        yParent.transform.Rotate(Vector3.up, mouseX * rotateSpeedY * Time.fixedDeltaTime);
        //yParent.transform.Rotate(0, mouseX * rotateSpeedY * Time.deltaTime, 0); // functionally the same

        xParent.transform.Rotate(Vector3.right, mouseY * rotateSpeedX * Time.fixedDeltaTime);
    }

    // Almost nothing changed (see Monday's version for comments)
    // There's only one change, at the very last line!
    void HandleMovement()
    {
        //rb.velocity = Vector3.zero;
        bool leftKey = Input.GetKey(KeyCode.A);
        bool rightKey = Input.GetKey(KeyCode.D);
        bool upKey = Input.GetKey(KeyCode.W);
        bool downKey = Input.GetKey(KeyCode.S);
        bool boost = Input.GetKey(KeyCode.LeftShift);

        if (boost)
        {
            speedX = 500f;
            speedZ = 500f;
        }
        else
        {
            speedX = 250f;
            speedZ = 250f;
        }

        Vector3 movement = Vector3.zero;
        if (onGround)
        {
            if (leftKey)
            {
                movement.x--;
            }
            if (rightKey)
            {
                movement.x++;
            }
            if (upKey)
            {
                movement.z++;
            }
            if (downKey)
            {
                movement.z--;
            }
        }
        

        movement = movement.normalized;

        movement.x *= speedX;
        movement.z *= speedZ;

        movement = transform.TransformDirection(movement); // gets forward based 
        // we changed the coordinate space from World to Self because we want "up" to mean "in front of us" regardless of our orientation
        // too inaccurate for character ! : rb.AddForce(movement, ForceMode.Force);

        Vector3 finalVelocity = movement * Time.fixedDeltaTime;
        finalVelocity.y = rb.velocity.y;
        rb.velocity = finalVelocity;
    }

    #endregion

    public void IncreaseScore()
    {
        score++;
        Debug.Log(score);
    }

    public void Respawn()
    {
        Debug.Log("Respawning...");
        transform.position = spawmPoint;
        

        
    }

    public void setSpawn()
    {
        spawmPoint = transform.position;
        Debug.Log(spawmPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
       
       if(other.tag == "Death")
        {
            Respawn();
        }

       else if (other.tag == "Checkpoint")
        {
            setSpawn();
   
        }

       else if(other.tag == "DeskTrigger")
        {
            if (!inDeskArea)
            {
                other.gameObject.GetComponent<DeskTrigger>().inArea = true;
                inDeskArea = true;
            }
           
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "DeskTrigger")
        {
            if (inDeskArea)
            {
                other.gameObject.GetComponent<DeskTrigger>().inArea = false;
                inDeskArea = false;
            }

        }
    }

    
    public void SwitchCam(GameObject newCam)
    {
        playerCam.gameObject.SetActive(false);
        newCam.SetActive(true);
    }

    public void ResetCam(GameObject currentCam)
    {
        
        currentCam.SetActive(false);
        playerCam.gameObject.SetActive(true);
    }



}



