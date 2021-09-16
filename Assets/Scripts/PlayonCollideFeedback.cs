using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayonCollideFeedback : MonoBehaviour
{


    [SerializeField]
    private UnityEvent positive;
    [SerializeField]
    private UnityEvent negative;
    [SerializeField]
    private bool isBlue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        BallColor ballColorComponent = other.gameObject.GetComponent<BallColor>();
        Color currentColor = ballColorComponent.myColor;
        Color orange = new Color(1.0f, 0.5f, 0.0f);

        if (isBlue && currentColor == Color.blue)
        {
            positive.Invoke();
        }
        else if (!isBlue && currentColor == orange)
        {
            positive.Invoke();
        }
        else
        {
            negative.Invoke();
        }
    }

}
