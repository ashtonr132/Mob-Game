using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipeObstacleGenerator : MonoBehaviour {

    public abstract void GenerateObstacles(Pipe pipe);
}
