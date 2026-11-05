using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    Animator animator;
    List<string> animParams = new List<string>{ "idle", "run", "attack", "death", 
        "skill1", "skill2", "skill3", "skill4", "skill5", "skill6"};

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetParam(string paramName)
    {
        foreach (string param in animParams) {
            animator.SetBool(param, false);
        }
        animator.SetBool(paramName, true);
    }
}
