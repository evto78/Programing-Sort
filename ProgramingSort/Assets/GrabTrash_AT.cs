using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class GrabTrash_AT : ActionTask {

		Transform tempTarget;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			float closestDist = float.MaxValue;

            foreach (GameObject trash in GameObject.FindGameObjectsWithTag("Garbage"))
            {
				if(Vector3.Distance(agent.transform.position, trash.transform.position) < closestDist) { closestDist = Vector3.Distance(agent.transform.position, trash.transform.position); tempTarget = trash.transform; }
            }
			foreach (GameObject trash in GameObject.FindGameObjectsWithTag("Recycling"))
			{
				if (Vector3.Distance(agent.transform.position, trash.transform.position) < closestDist) { closestDist = Vector3.Distance(agent.transform.position, trash.transform.position); tempTarget = trash.transform; }
			}

			//agent.transform.LookAt(tempTarget);
			agent.transform.Translate((tempTarget.position - agent.transform.position).normalized * 15f * Time.deltaTime);

			if (Vector3.Distance(agent.transform.position, tempTarget.position) < 0.5f)
			{
				blackboard.SetVariableValue("TargetItem", tempTarget.gameObject);
				tempTarget.position = blackboard.GetVariableValue<Transform>("HolderPos").position;
				tempTarget.SetParent(blackboard.GetVariableValue<Transform>("HolderPos"));
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