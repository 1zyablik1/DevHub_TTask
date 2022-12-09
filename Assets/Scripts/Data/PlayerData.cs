using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data", order = 51)]
public class PlayerData : ScriptableObject
{
    public float speed;
    public float speedInputMultyply;
    public float sideSpeed;
    public float maxXoffset;

    public bool isDeadSideObstacle;
}
