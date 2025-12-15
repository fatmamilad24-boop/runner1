using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.enabled = false;
            }

            Debug.Log("Player hit obstacle");
        }
    }
}
