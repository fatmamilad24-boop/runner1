using UnityEngine; // Add this line

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public float rotationSpeed = 100f;
    
    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(coinValue);
            }
            Destroy(gameObject);
        }
    }
}