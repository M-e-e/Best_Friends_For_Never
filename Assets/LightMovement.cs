using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityEngine;

public class LightMovement : MonoBehaviour
{
	[SerializeField] private StringConstant TagP1, TagP2;
	private GameObject P1, P2;
    // Start is called before the first frame update
    void Start()
    {
	    P1 = AtomicTags.FindByTag(TagP1.Value);
	    P2 = AtomicTags.FindByTag(TagP2.Value);

    }

    // Update is called once per frame
    void Update()
    {
	    Debug.Log("old   "+transform.position);
	    transform.position= new Vector3((float)(P1.transform.position.x + P2.transform.position.x) / 2,(float)(P1.transform.position.y + P2.transform.position.y) / 2, 0f);
	    Debug.Log("new   "+transform.position);

    }
}
