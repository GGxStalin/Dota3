using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{

    public SkillInfo SkillInfoExample;
    public List<GameObject> skillIcons = new List<GameObject>();

    private void Start()
    {
        AddSkill(SkillInfoExample, 0);

    }

    public void AddSkill(SkillInfo skillInfo, int iconNumber)
    {
        skillIcons[iconNumber].GetComponent<Image>().sprite = skillInfo.icon;
    }

}
