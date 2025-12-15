using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public float rotationSpeed = 100f;
    
    void Update()
    {
        // Rotate around X-axis (like a flipping coin)
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject scoreManagerObject = GameObject.Find("ScoreManager");
            
            if (scoreManagerObject != null)
            {
                ScoreManager scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
                if (scoreManager != null)
                {
                    scoreManager.AddScore(coinValue);
                }
            }
            
            Destroy(gameObject);
        }
    }
}