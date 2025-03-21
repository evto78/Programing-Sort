using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DepositTrash_AT : ActionTask {

		Transform targetBin;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			if(blackboard.GetVariableValue<GameObject>("TargetItem").tag == "Garbage")
            {
				targetBin = blackboard.GetVariableValue<GameObject>("GarCan").transform;
            }
			else if(blackboard.GetVariableValue<GameObject>("TargetItem").tag == "Recycling")
            {
				targetBin = blackboard.GetVariableValue<GameObject>("RecBin").transform;
			}

			//agent.transform.LookAt(targetBin);
			agent.transform.Translate((targetBin.position - agent.transform.position).normalized * 15f * Time.deltaTime);

			if(Vector3.Distance(agent.transform.position, targetBin.position) < 0.5f)
            {
				GameObject.Destroy(blackboard.GetVariableValue<GameObject>("TargetItem"));
            }

			EndAction(true);
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