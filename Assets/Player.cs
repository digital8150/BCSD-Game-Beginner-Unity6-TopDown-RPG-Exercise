using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float h;
    float v;
    bool isHorizontal;

    public float Speed;
    Rigidbody2D rigid;
    void Start()
    {
        
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        Vector2 moveVect = isHorizontal ? new Vector2(h, 0) : new Vector2(0,v);
        rigid.linearVelocity = moveVect * Speed;
    }
}
