using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SmartTank : AITank
{
    public Dictionary<GameObject, float> targetTanksFound = new Dictionary<GameObject, float>();
    public Dictionary<GameObject, float> consumablesFound = new Dictionary<GameObject, float>();
    public Dictionary<GameObject, float> basesFound = new Dictionary<GameObject, float>();

    public GameObject targetTank = null;
    public float targetTankDistance = -1f;
    public GameObject consumablePosition;
    public GameObject basePosition;

    protected float t;

    private void InitialiseStateMachine()
    {
        Dictionary<Type, FSMBase> states = new Dictionary<Type, FSMBase>();

        states.Add(typeof(SearchState), new SearchState(this));
        states.Add(typeof(AttackState), new AttackState(this));
        states.Add(typeof(RetreatState), new RetreatState(this));
        states.Add(typeof(DefendState), new DefendState(this));

        GetComponent<StateMachine>().SetStates(states);
    }

    /*******************************************************************************************************      
    WARNING, do not include void Start(), use AITankStart() instead if you want to use Start method from Monobehaviour.
    *******************************************************************************************************/
    public override void AITankStart()
    {
        //This method runs once at the beginning when pressing play in Unity.
        InitialiseStateMachine();
        
    }

    /*******************************************************************************************************       
    WARNING, do not include void Update(), use AITankUpdate() instead if you want to use Update method from Monobehaviour.
    *******************************************************************************************************/
    public override void AITankUpdate()
    {
        //This method runs once per frame.

        targetTanksFound = GetAllTargetTanksFound;
        consumablesFound = GetAllConsumablesFound;
        basesFound = GetAllBasesFound;

        if (targetTanksFound.Count > 0)
        {
            targetTank = targetTanksFound.First().Key;
            targetTankDistance = targetTanksFound.First().Value;
            Debug.Log(targetTankDistance);
        }
        else
        {
            targetTank = null;
            targetTankDistance = -1;
        }
    }

    /*******************************************************************************************************       
    WARNING, do not include void OnCollisionEnter(), use AIOnCollisionEnter() instead if you want to use Update method from Monobehaviour.
    *******************************************************************************************************/
    public override void AIOnCollisionEnter(Collision collision)
    {
        //This method is used for detecting collisions (unlikley you will need this).
    }

    public void SearchingFor()
    {
        Debug.Log("Search function");
        targetTank = null;
        consumablePosition = null;
        basePosition = null;
        FollowPathToRandomPoint(1f);
        t += Time.deltaTime;
        if (t > 10)
        {
            GenerateRandomPoint();
            t = 0;
        }
    }
}
