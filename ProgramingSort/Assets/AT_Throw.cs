using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Throw : ActionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			blackboard.SetVariableValue("TimeSinceTrashThrown", Random.Range(-6f, -15f));

			List<GameObject> trashList = blackboard.GetVariableValue<List<GameObject>>("Trash");
			int rand = Random.Range(0, 2);
			Debug.Log(rand);

			GameObject spawnedTrash = GameObject.Instantiate(trashList[rand]);
			spawnedTrash.transform.SetParent(null);
			spawnedTrash.transform.position = agent.transform.position + Vector3.up * 2f;
			spawnedTrash.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
			spawnedTrash.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * 4f, ForceMode.Impulse);

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