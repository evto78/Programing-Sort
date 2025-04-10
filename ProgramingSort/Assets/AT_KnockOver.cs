using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_KnockOver : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			float oldVal = blackboard.GetVariableValue<float>("PrepareTimer");
			blackboard.SetVariableValue("PrepareTimer", oldVal - Time.deltaTime);
			blackboard.GetVariableValue<GameObject>("DiggingEffect").SetActive(true);
			blackboard.GetVariableValue<GameObject>("SurprisedEffect").SetActive(false);
			if (oldVal <= 0)
			{
				foreach (GameObject can in blackboard.GetVariableValue<List<GameObject>>("TrashCans"))
				{
					can.SendMessage("KnockOver", SendMessageOptions.DontRequireReceiver);
					agent.transform.LookAt(can.transform.position);
				}
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