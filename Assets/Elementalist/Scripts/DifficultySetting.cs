using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DifficultySettings")]
public class DifficultySetting : ScriptableObject
{
    public List<GameObject> elementals;
    public EnemyDirectorSettings enemyDirectorSettings;
    public float playerSpeed;
    public float playerHealth;
    public float playerInvicinbility;
    public int levelScalingConstant;

    public int levelScalingOffset;
}
