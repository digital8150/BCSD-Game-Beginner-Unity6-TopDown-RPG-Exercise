using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float h;
    float v;
    bool isHorizontal;

    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
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
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        Vector2 moveVect = isHorizontal ? new Vector2(h, 0) : new Vector2(0,v);
        rigid.linearVelocity = moveVect * Speed;
    }
}
