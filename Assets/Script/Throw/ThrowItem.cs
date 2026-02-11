using System;
using System.Globalization;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ThrowItem : MonoBehaviour
{
    [SerializeField]
    GameObject[] throwableArray;
    [SerializeField]
    GameObject throwable;
    [SerializeField]
    GameObject cinemachine;
    [SerializeField]
    float throwForce;

    [SerializeField]
    CinemachineCamera Vcam;

    [SerializeField]
    TMP_InputField input;

    [SerializeField]
    float oldForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        foreach (var t in throwableArray)
        {
            t.SetActive(false);
        }

        throwableArray[0].SetActive(true);
        throwable = throwableArray[0];
        Vcam.Follow = throwable.transform;
    }
    public void inputUpdate()
    {
        if (!input.text.Contains('.'))
        {
            input.text = input.text + ".0";
        }

        float result;

        if (float.TryParse(input.text, out result))
        {
            throwForce = result;
            oldForce = result;
        }
        else
        {
            input.text = oldForce.ToString();
            Debug.LogAssertion("Force input is not a proper float");
        }
    }

    public void switchThrowable()
    {
        int nextIndex = 0;
        for(int i = 0; i < throwableArray.Length; i++)
        {
            if (throwableArray[i].Equals(throwable))
            {
                if ((i == throwableArray.Length - 1))
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex = i + 1;
                }

                break;
            }
        }

        throwable.SetActive(false);

        throwable = throwableArray[nextIndex];

        throwable.SetActive(true);

        Vcam.Follow = throwable.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cinemachine.SetActive(true);

            transform.DetachChildren();

            Rigidbody rb = throwable.GetComponent<Rigidbody>();

            rb.useGravity = true;
            rb.isKinematic = false;

            rb.AddForce(throwable.transform.up * throwForce, ForceMode.Impulse);
        }
    }
}
