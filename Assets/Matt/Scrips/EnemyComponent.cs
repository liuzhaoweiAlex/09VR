using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner.Runtime.Tasks;
public class EnemyComponent : Conditional// MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform Player;
     Transform Target;
    public Transform[] patrolpoint;
    public int nextpoint = 0;
    public int point;
    public float attackCD;
    public bool walk_stage;
    public bool attack_stage;
    public bool canattack;
    public GameObject EnemyWeapon;
    public float enemy_Hp=100;
    public int bossstageone;
    public int bossstagetwo;
    Animator charAni;
    Transform charTrans;

    private void Update()
    {
        enemyAI();
    
        CharacterControl();
        
    }
    private void Start()
    {
        charAni = character.GetComponent<Animator>();
    }
    void enemyAI()
    {
        enemypatrol();
        enemyattack();
    }

    void enemypatrol()
    {if (walk_stage)
        {
            charAni.SetFloat("Foward", 1);
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 0);
            if (attack_stage)
            {
               
                    //this.nav.SetDestination(this .Target.position);
                    Target = Player;
            }
            if (!attack_stage)
            {
                Target = patrolpoint[nextpoint];
                if (Vector3.Distance(transform.position, Target.position) <= 2f)
                {
                    Target = patrolpoint[++nextpoint];
                    if (nextpoint >= point)
                    {
                        nextpoint = 0;
                    }

                }
                Target = patrolpoint[nextpoint];
              

            }
            this.nav.SetDestination(this.Target.position);
        }
    }
    void Bossstage()
    {
        if (enemy_Hp < bossstageone)
        {

        }
        else if(enemy_Hp < bossstagetwo)
        {

        }
        else
        {

        }
    }
    void enemyattack()
    {
        if (attack_stage)
        {
            attackCD += Time.deltaTime;
            if (attackCD > 2f)
            {
                canattack = true;

            }
            if (attackCD > 3f)
            {
                attackCD = 0;
            }
            if (attackCD < 2f)
            {
                canattack = false;
            }
            if (canattack)
            {
                EnemyWeapon.SetActive(true);
            }
            else if (!canattack)
            {
                EnemyWeapon.SetActive(false);
            }
        }
        if (!attack_stage)
        {
            attackCD = 0f;
            canattack= false;
            EnemyWeapon.SetActive(false);
        }
    }
    public GameObject character;

    void CharacterControl()
    {


        if (Input.GetKeyDown(KeyCode.W))
        {
            charAni.SetFloat("Foward", 1);
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 0);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            charAni.SetFloat("Foward", 0);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            charAni.SetFloat("Right", 1);
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 0);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            charAni.SetFloat("Right", 0);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            charAni.SetFloat("Right", -1);
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            charAni.SetFloat("Right", 0);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 1);//catch
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 2);//attack
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 3);//gethit
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            charAni.SetBool("NewBool", true);
            charAni.SetInteger("NextAni", 4);//death
        }

    }
}


