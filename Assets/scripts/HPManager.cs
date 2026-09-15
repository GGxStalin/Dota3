using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] GameObject canvasIndicator;
    [SerializeField] float maxHP = 100;
    [SerializeField] float hp;
    [SerializeField] Slider HPSlider;
    public bool isDead = false;


    private void Start()
    {
        hp = maxHP;
        HPSlider.maxValue = maxHP;
        HPSlider.value = hp;
    }

    private void Update()
    {
        canvasIndicator.transform.LookAt(Camera.main.transform.position);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        HPSlider.value = hp;

        if (hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().isTrigger = true;
        isDead = true;
        Destroy(gameObject, 2);
    }


}