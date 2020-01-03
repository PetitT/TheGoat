using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    public List<BaseAttack> attacks;

    [Header("Attack Phases")]
    public List<BaseAttack> P1Attacks; // frachement essaye de trouver un truc mieux que ça parce que c'est pas joli joli
    public List<BaseAttack> P2Attacks;
    public List<BaseAttack> P3Attacks;

    [Header("Stats")]
    public List<float> vulnerabilityTimer;
    public List<float> timeBetweenAttacks;
    public List<int> attacksBeforeVulnerability;

    private List<List<BaseAttack>> attackPhases = new List<List<BaseAttack>>();

    private WolfState currentState = WolfState.idle;
    private int currentPhase = 0;
    private float remainingVulnerability;
    private float remainingTimeBetweenAttacks;
    private int remainingAttacksBeforeVulnerability;
    private bool canAttack = true;

    private void Start()
    {
        TimelineListener.instance.onWolfStateChange += WolfStateChangeHandler;
        TimelineListener.instance.onPhaseChange += PhaseChangeHandler;

        foreach (var attack in attacks)
        {
            attack.onAttackFinished += FinishedAttackHandler;
        }

        attackPhases.Add(P1Attacks);
        attackPhases.Add(P2Attacks);
        attackPhases.Add(P3Attacks);

        remainingVulnerability = vulnerabilityTimer[currentPhase];
        remainingTimeBetweenAttacks = timeBetweenAttacks[currentPhase];
        remainingAttacksBeforeVulnerability = attacksBeforeVulnerability[currentPhase];
    }

    private void FinishedAttackHandler()
    {
        canAttack = true;
    }

    private void PhaseChangeHandler()
    {
        currentPhase++;
    }

    private void WolfStateChangeHandler(WolfState state)
    {
        currentState = state;
    }


    private void Update()
    {
        InputTest(); //to remove

        CheckCurrentState();
        Debug.Log(currentState.ToString());
    }

    private void CheckCurrentState()
    {
        switch (currentState)
        {
            case WolfState.attacking:
                if (canAttack)
                {
                    AttackCountdown();
                }
                break;

            case WolfState.vulnerable:
                VulnerabiltyCountdown();
                break;

            case WolfState.idle:
                break;

            default:
                break;
        }
    }

    private void AttackCountdown()
    {
        remainingTimeBetweenAttacks -= Time.deltaTime;
        if (remainingTimeBetweenAttacks <= 0)
        {
            remainingTimeBetweenAttacks = timeBetweenAttacks[currentPhase];
            if (remainingAttacksBeforeVulnerability > 0)
            {
                Attack();
            }
            else
            {
                currentState = WolfState.vulnerable;
                remainingAttacksBeforeVulnerability = attacksBeforeVulnerability[currentPhase];
            }
            remainingAttacksBeforeVulnerability--;
        }
    }

    private void Attack()
    {
        int random = UnityEngine.Random.Range(0, attackPhases[currentPhase].Count);
        attackPhases[currentPhase][random].Attack();
        canAttack = false;
    }

    private void VulnerabiltyCountdown()
    {
        remainingVulnerability -= Time.deltaTime;
        if (remainingVulnerability <= 0)
        {
            remainingVulnerability = vulnerabilityTimer[currentPhase];
            currentState = WolfState.attacking;
        }
    }

    private void InputTest()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            attacks[0].Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            attacks[1].Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            attacks[2].Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            attacks[3].Attack();
        }
    }
}
