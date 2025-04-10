using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_NearCan : ConditionTask {

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if(blackboard.GetVariableValue<float>("PrepareTimer") > -0.01f)
            {
				foreach (GameObject can in blackboard.GetVariableValue<List<GameObject>>("TrashCans"))
				{
					if (Vector3.Distance(can.transform.position, agent.transform.position) < 3f)
					{
						return true;
					}
				}
            }
            else
            {
				blackboard.SetVariableValue("PrepareTimer", 5f);
            }

			return false;
		}
	}
}