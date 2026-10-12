using System;
using UnityEngine;

public class StiflingDagger : Skill
{
    public SkillInfo info;

    public override void SkillUse()
    {
        HandleAnimation();
        ChangeCursor();
        HandleIcon();

    }

    private void HandleIcon()
    {
        throw new NotImplementedException();
    }

    private void ChangeCursor()
    {
        throw new NotImplementedException();
    }

    private void HandleAnimation()
    {
        throw new NotImplementedException();
    }
}
