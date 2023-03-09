using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillCast : MonoBehaviour
{
    [Header("Cooldown Icons")]
    public Image[] CooldownIcons;
    [Header("Out Of Mana Icons")]
    public Image[] OutOfManaIcons;
    //Mana deðerleri.
    private bool faded = false;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };

    private Animator anim;

    private bool canAttack = true;

    private PlayerOnClick playerOnClick;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerOnClick = GetComponent<PlayerOnClick>();
    }



    void Start()
    {
        
    }


    void Update()
    {
        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }
    bool FadeAndWait(Image fadeImage, float fadeTime)
    {
        faded = false;
        if(fadeImage == null)
        {
            return faded;
        }
    }
}
