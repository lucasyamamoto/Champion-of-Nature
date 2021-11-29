using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class BossAttack : MonoBehaviour
{
    [SerializeField] private List<CharacterSkill> attackSkills;
    private InputManager inputManager;
    private Animator animator;
    [SerializeField] private float skillCycleDuration;
    [SerializeField] private bool releaseProjectile;
    private bool blockAttack;
    private int currentSkill;

    public bool Block { get => blockAttack; set => blockAttack = value; }

    IEnumerator CycleSkillRandom()
    {
        while (true)
        {
            if (attackSkills[currentSkill] is RangedAttack)
            {
                ((RangedAttack)attackSkills[currentSkill]).releaseProjectile = false;
            }
            currentSkill = Random.Range(0, attackSkills.Count);
            animator.SetInteger("ElementalState", currentSkill);

            yield return new WaitForSecondsRealtime(skillCycleDuration);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        blockAttack = false;
        currentSkill = 0;

        StartCoroutine(CycleSkillRandom());
    }

    // Update is called once per frame
    void Update()
    {
        if (!blockAttack)
        {
            attackSkills[currentSkill].CurrentInput = inputManager.Attack();
        }

        if (attackSkills[currentSkill] is RangedAttack)
        {
            ((RangedAttack)attackSkills[currentSkill]).releaseProjectile = releaseProjectile;
        }
    }
}
