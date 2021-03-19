using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedSmallEnemyRobotMovement : SmallEnemyRobotMovement {

	protected override void Start () {
        base.Start();
        target = PlayerTarget.target.transform;		
	}
	

}
