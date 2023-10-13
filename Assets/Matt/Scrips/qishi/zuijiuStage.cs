using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine.AI;

public class zuijiuStage : Action
{

    /// <summary>
    ///  Transform willGo;
    /// </summary>
    public Transform record;
    public NavMeshAgent nav;
    
    public float xp;
    public float zp;
    public override void OnStart()
    {
        
        xp = Random.Range(-6, 6);
        zp = Random.Range(-6, 6);
        record.position = new Vector3(this.transform.position.x + xp, 0, this.transform.position.z + zp);
        
    }
   
    public override TaskStatus OnUpdate()
    {
       
       this.nav.SetDestination(record.position);
        
        // willGo.transform.position = new Vector3(x, 0, z);

        //if (transform.position == willGo.position)
        //{
        return TaskStatus.Success;
        //}
        //return TaskStatus.Failure;
    }

    
}
