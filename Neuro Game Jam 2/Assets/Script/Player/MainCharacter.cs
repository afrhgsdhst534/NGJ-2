using UnityEngine;
public class MainCharacter : Character
{
    private FSM fsm;
    private float h;
    private float v;
    public float speed;
    public Vector3 move;
    private Camera cam => Camera.main;
    private Rigidbody rb => GetComponent<Rigidbody>();
    [SerializeField]private bool readyToJump;
    public float jumpForce;
    private float jumpCoolDown=0.3f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fsm = new FSM();
        fsm.AddState(new FSMStateIdle(fsm));
        fsm.AddState(new FSMStateWalk(fsm));
        fsm.SetState<FSMStateIdle>();
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            readyToJump = true;
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            readyToJump = false;
        }
    }
    private void Update()
    {
        jumpCoolDown -= Time.deltaTime;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        fsm.Update();
        transform.localEulerAngles = new Vector3(0, cam.transform.localEulerAngles.y, 0);
    }
    private void FixedUpdate()
    {
        Run();
    }
    private void Jump()
    {
        if (readyToJump&&jumpCoolDown<=0) {
            rb.AddForce(transform.up*jumpForce, ForceMode.Impulse);
            readyToJump = false;
            jumpCoolDown = 0.5f;
        }
    }
    protected override void Run()
    {
        move = transform.forward * v + transform.right * h;
        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
    }
}