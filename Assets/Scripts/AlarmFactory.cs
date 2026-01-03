using System.Collections.Generic;
using UnityEngine;

public class AlarmFactory : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private Alarm alarmPrefab;

    [Header("Guards to warn")]
    [SerializeField] private GuardRobot[] guards;

    [Header("Alarms to create")]
    [SerializeField] private int alarmsCount = 3;

    [Header("Possible positions")]
    private Vector3[] spawnPositions =
    {
        new Vector3(-8.94f, 0f, -2.52f),   
        new Vector3(-7.28f, 0f,  6.76f),   
        new Vector3(-1.35f, 0f,  7.06f),   
        new Vector3( 3.76f, 0f, 10.61f),  
        new Vector3( 9.59f, 0f,  3.36f),   
        new Vector3( 3.01f, 0f, -1.02f),   
        new Vector3(-8.02f, 0f, -4.92f),  
        new Vector3(-4.65f, 0f, -9.97f),   
        new Vector3( 6.90f, 0f, -10.80f),  
        new Vector3( 1.10f, 0f, -14.00f),  
        new Vector3(-6.89f, 0f, -14.81f),  
        new Vector3( 7.56f, 0f, -14.85f)  
    };

  
    private readonly List<Alarm> spawned = new List<Alarm>();
    public void SetAlarmsCount(int count)
    {
        alarmsCount = count;
    }
    public void CreateAlarms()
    {
        if (alarmPrefab == null)
        {
            return;
        }

        
        for (int i = 0; i < spawned.Count; i++)
        {
            if (spawned[i] != null) Destroy(spawned[i].gameObject);
        }
        spawned.Clear();

        int count = Mathf.Min(alarmsCount, spawnPositions.Length);

  
        List<int> available = new List<int>();
        for (int i = 0; i < spawnPositions.Length; i++)
            available.Add(i);

        for (int i = 0; i < count; i++)
        {
            int pick = Random.Range(0, available.Count);
            int idx = available[pick];
            available.RemoveAt(pick);

            Vector3 pos = spawnPositions[idx];

            Alarm alarm = Instantiate(alarmPrefab, pos, Quaternion.identity);
            spawned.Add(alarm);

            alarm.Init(guards);
        }
    }
}
