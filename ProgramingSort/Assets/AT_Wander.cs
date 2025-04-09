using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Wander : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			float oldValue = blackboard.GetVariableValue<float>("TimeSinceTrashThrown");
			blackboard.SetVariableValue("TimeSinceTrashThrown", oldValue + Time.deltaTime * Random.Range(0.6f, 1.4f));

			if(blackboard.GetVariableValue<Vector3>("WanderPos") == Vector3.zero)
            {
				blackboard.SetVariableValue("WanderPos", FindPos());
            }
            else
            {
				agent.GetComponent<NavMeshAgent>().destination = blackboard.GetVariableValue<Vector3>("WanderPos");

				if(Vector3.Distance(agent.transform.position, blackboard.GetVariableValue<Vector3>("WanderPos")) < 1f)
                {
					blackboard.SetVariableValue("WanderPos", Vector3.zero);
				}
			}
			EndAction(true);
		}

		Vector3 FindPos()
        {
			Vector3 rand = new Vector3(Random.Range(-1f,1f), 0, Random.Range(-1f, 1f)) * 40f;
			Vector3 posOnNav = Vector3.zero;
			NavMeshHit hit;
			if (NavMesh.SamplePosition(rand, out hit, 40f, NavMesh.AllAreas))
			{
				posOnNav = hit.position;
			}
			return posOnNav;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}