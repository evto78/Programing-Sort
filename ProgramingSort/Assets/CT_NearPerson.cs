using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_NearPerson : ConditionTask {

		protected override string OnInit(){
			return null;
		}
		protected override void OnEnable() {
			
		}
		protected override void OnDisable() {
			
		}
		protected override bool OnCheck() {

			foreach(GameObject thing in GameObject.FindGameObjectsWithTag("Person"))
            {
				if (blackboard.GetVariableValue<bool>("Running"))
				{
					if (Vector3.Distance(agent.transform.position, thing.transform.position) < 5f)
					{
						blackboard.SetVariableValue("RunFrom", thing.transform.position);
						return true;
					}
				}
                else
                {
					if (Vector3.Distance(agent.transform.position, thing.transform.position) < 3f)
					{
						blackboard.SetVariableValue("RunFrom", thing.transform.position);
						return true;
					}
				}
            }

			if (blackboard.GetVariableValue<bool>("Running"))
			{
				if (Vector3.Distance(agent.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 5f)
				{
					blackboard.SetVariableValue("RunFrom", GameObject.FindGameObjectWithTag("Player").transform.position);
					return true;
				}
			}
			else
			{
				if (Vector3.Distance(agent.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 3f)
				{
					blackboard.SetVariableValue("RunFrom", GameObject.FindGameObjectWithTag("Player").transform.position);
					return true;
				}
			}

			blackboard.SetVariableValue("Running", true);
			return false;
		}
	}
}