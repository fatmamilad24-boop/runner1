using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Movement")]
    public float forwardSpeed = 6f;
    public float laneSpeed = 8f;

    [Header("Lives")]
    public int maxLives = 3;

    [Header("Collectibles")]
    public int startingCoins = 0;
}
