using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ī�޶� ��� �ڵ�
public class GrabCamera : MonoBehaviour
{

    public Transform Camera; //ī�޶� ������
    public Transform RightHand; //������
    private bool grab = false; //�����հ� �浹 ���ΰ�?
    public static bool onCamera=false; //ī�޶� �տ� ����°�?

    public bool onCrime = false;

   // public GameObject Filter;
   // private bool onFilter = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log("��ư ����");
            //GrabOnHand(); 
            grab = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {

            PutDownCamera();
            grab = false;
        }*/

        /*
        if (onCamera == true && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            SetFilter(onFilter);
            onFilter = !onFilter;

            Debug.Log("���ͼ�ȯ.");
        }*/
    }


    private void OnTriggerEnter(Collider other)
    {
        // �� �ݸ����� �浹���� �� update�� ����
        /*if (grab==true &&other.CompareTag("RIGHTHAND"))
        {
                GrabOnHand();
        }*/
        if (other.CompareTag("Hand"))//0308 �ڷ�ƾ ���� �����հ� �浹�� �Ͼ ���
        {
            StartCoroutine(HandCheckCoroutine());
            grab = true;
            Debug.Log("�ڷ�ƾ ����");
        }
    
    }
    /*
    private void OnTriggerStay(Collider other)
    {
         �� �ݸ����� �浹 ���� ��
        if (other.CompareTag("RIGHTHAND"))
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("��ư ����");
                GrabOnHand(); 
                grab = true;
            }
        }
    }*/

    private void OnTriggerExit(Collider other) //0308 �ڷ�ƾ ���� �հ� �浹�� ���� ���
    {
        if (other.CompareTag("Hand"))
        {
            // �ڷ�ƾ �ߴ�
            StopCoroutine(HandCheckCoroutine());
            grab = false;
            Debug.Log("�ڷ�ƾ �ߴ�");
        }
    }

    // ���� �ִ��� üũ�ϴ� �ڷ�ƾ 0308


    IEnumerator HandCheckCoroutine()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)&&grab==true)
        {
            Debug.Log("��ư ����");
            GrabOnHand(); 
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {

            PutDownCamera();
            onCamera = false;
        }

        yield return new WaitForSeconds(0); 
        if (grab == true)
        {
            StartCoroutine(HandCheckCoroutine()); // ��������� �ڷ�ƾ ����
        }
    }




    private void GrabOnHand() // ī�޶� �������� �ڽ����� �ΰ� ��ġ�� �̵���Ų��.
    {
        onCamera = true;
        Debug.Log("��Ҵ�.");
        //Camera.transform.SetParent(RightHand);
        //Camera.transform.position = RightHand.transform.position;
        //Camera.transform.rotation = RightHand.transform.rotation;
    }
    private void PutDownCamera()//ī�޶�� �������� �ڽİ��踦 �����Ѵ�.
    {
        onCamera = false;
        Debug.Log("���Ҵ�.") ;

        if (onCrime == true)
        {
            Camera.transform.position += new Vector3(0f, 100f, 0f);
        }
    }
}