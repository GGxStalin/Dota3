using UnityEngine;

[CreateAssetMenu(fileName = "SkillInfo", menuName = "Skill info")]
public class SkillInfo : ScriptableObject
{
    public Sprite icon;
    public string skillName = "skill";
    public string desc = "desc";
    public float distance = 1;
    public float damage = 1;
    public float manaCost = 1;
    public float cooldown = 1;
    public KeyCode key = KeyCode.None;
    public int skillLevel = 0;
}
