using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Proximity-based detionation with an initial fuse.
/// </summary>
public class RadialDetonation : MonoBehaviour
{
    public UnityEvent detionationEvent;

    public float radius;

    public Player owner;
    bool detEnabled;
    public float detEnableTime;
    private void Start()
    {
        if (detEnableTime > 0)
        {
            StartCoroutine(EnableDetonation());
        }
        else
        {
            detEnabled = true;
        }
    }

    private void Update()
    {
        if (detEnabled)
        {
            Player player = PlayerManager.instance.GetClosestPlayer(transform.position, true);
            if (Vector2.Distance(player.transform.position, transform.position) >= radius * transform.localScale.x)
            {
                detionationEvent.Invoke();
            }
        }
    }
    IEnumerator EnableDetonation()
    {
        yield return new WaitForSeconds(detEnableTime);
        yield return detEnabled = true;
    }

    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.DrawWireArc(transform.position, Vector3.forward, Vector3.up, 360, radius);
#endif
    }
}
