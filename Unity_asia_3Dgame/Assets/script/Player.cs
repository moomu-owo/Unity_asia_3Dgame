
using UnityEngine;
using Invector.vCharacterController;  //引用 套件

public class Player : MonoBehaviour
{
    private float hp = 100;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    ///受傷
    public void Damage()
    {
        hp -= 35;
        ani.SetTrigger("damage");
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetTrigger("die");

        //鎖定移動與旋轉
        vThirdPersonController vt = GetComponent<vThirdPersonController>();
        vt.lockMovement = true;
        vt.lockRotation = true;
    }
}
