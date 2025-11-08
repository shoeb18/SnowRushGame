using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [SerializeField] float baseSpeed = 10f;
    [SerializeField] float boostSpeed = 20f;

    private Rigidbody2D rb;
    private SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRoation();
        CheckBoostSpeed();
    }

    void PlayerRoation()
    {
        // rotation
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    void CheckBoostSpeed()
    {
        // speed boost
        if (Input.GetKey(KeyCode.Space) && surfaceEffector2D)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
