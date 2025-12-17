using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float laneChangeSpeed = 10f;

    // Lane positions
    private float[] lanes = { -6.15f, -0.2f, 6.51f };
    private int currentLane = 1; // start in middle lane

    void Update()
    {
        //  Always move forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        //  Lane input
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            currentLane = Mathf.Clamp(currentLane - 1, 0, 2);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            currentLane = Mathf.Clamp(currentLane + 1, 0, 2);
        }

        // Move to target lane
        Vector3 targetPosition = new Vector3(
            lanes[currentLane],
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            laneChangeSpeed * Time.deltaTime
        );
    }
}

