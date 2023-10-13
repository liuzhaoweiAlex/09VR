using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityTransform;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityVector2;

public class MoveTowards : Conditional
{
    public NavMeshAgent nav;
    public Transform[] Player;
    Transform Target;
    public int hatredPlayer;
   
    public override TaskStatus OnUpdate()
    {
        if (Vector3.SqrMagnitude(transform.position - Player[hatredPlayer].position) < 0.2f)
        {
          
            this.nav.SetDestination(transform.position);
            return TaskStatus.Success;
        }
        else
        {
            this.nav.SetDestination(this.Player[hatredPlayer].position);
            
        }
       
      // transform. LookAt(Player[hatredPlayer]);
        return TaskStatus.Failure;
    }
  

  
}
