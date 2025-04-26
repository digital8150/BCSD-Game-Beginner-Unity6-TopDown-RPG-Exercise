using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float h;
    float v;
    bool isHorizontal;
    Vector3 dirVec;

    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
    GameObject scannedObject;
    void Start()
    {
        
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButton("Horizontal");
        bool vDown = Input.GetButton("Vertical");

        if(hDown)
            isHorizontal = true;
        else if(vDown)
            isHorizontal = false;

        //Anim
        if (anim.GetInteger("hAxisRaw") != (int)h)
        {
            anim.SetBool("isChanged", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != (int)v)
        {
            anim.SetBool("isChanged", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
        {
            anim.SetBool("isChanged", false);
        }

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if(vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown && h == -1)
            dirVec = Vector3.left;

        //Scan
        if (Input.GetButtonDown("Jump") && scannedObject != null)
        {
            Debug.Log($"½ºÄµ! : {scannedObject.name}");
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        Vector2 moveVect = isHorizontal ? new Vector2(h, 0) : new Vector2(0,v);
        rigid.linearVelocity = moveVect * Speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
        {
            scannedObject = rayHit.collider.gameObject;
        }
        else
        {
            scannedObject = null;
        }
    }
}
