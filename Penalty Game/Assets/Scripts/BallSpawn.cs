using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Ball1Prefab;
    [SerializeField]
    private Vector2 sizeBall1;
    [SerializeField]
    private Vector2 centerBall1;

    [SerializeField]
    private GameObject Ball2Prefab;
    [SerializeField]
    private Vector2 sizeBall2;
    [SerializeField]
    private Vector2 centerBall2;

    private GameObject ball1Spawned, ball2Spawned;

    public void SpawnBalls()
    {
        Vector2 pos = centerBall1 + new Vector2(Random.Range(-sizeBall1.x / 2, sizeBall1.x/2), Random.Range(-sizeBall1.y / 2, sizeBall1.y / 2));
        ball1Spawned = Instantiate(Ball1Prefab, pos, Quaternion.identity);

        Vector2 pos2 = centerBall2 + new Vector2(Random.Range(-sizeBall2.x / 2, sizeBall2.x / 2), Random.Range(-sizeBall2.y / 2, sizeBall2.y / 2));
        ball2Spawned = Instantiate(Ball2Prefab, pos2, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(centerBall1, sizeBall1);
        Gizmos.color = Color.red;
        Gizmos.DrawCube(centerBall2, sizeBall2);

    }
    public void DespawnBalls()
    {
        Destroy(ball1Spawned);
        Destroy(ball2Spawned);
    }
}
