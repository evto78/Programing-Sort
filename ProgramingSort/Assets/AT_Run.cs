using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Run : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			blackboard.SetVariableValue("Running", true);
			agent.transform.position = agent.transform.position - ((blackboard.GetVariableValue<Vector3>("RunFrom") - agent.transform.position).normalized * 5f * Time.deltaTime);
			agent.transform.LookAt(-blackboard.GetVariableValue<Vector3>("RunFrom"));
			agent.transform.position = new Vector3(agent.transform.position.x, 0, agent.transform.position.z);
			blackboard.GetVariableValue<GameObject>("DiggingEffect").SetActive(false);
			blackboard.GetVariableValue<GameObject>("SurprisedEffect").SetActive(true);
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