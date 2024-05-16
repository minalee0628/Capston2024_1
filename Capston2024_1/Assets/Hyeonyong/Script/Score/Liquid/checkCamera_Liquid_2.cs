using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkCamera_Liquid_2 : MonoBehaviour
{
    // �� �ڵ�� ī�޶� ���ϴ� ��ü�� �νĽ�Ű�� ���� ����ϴ� �ڵ��̴�. ���� ������ ������Ÿ�Ը� ���۵�
    public Camera cameraToCheck; // Camera ������Ʈ�� ���۷����� ���� ����
    public TextMeshProUGUI Score; // �׳� üũ������ �־�� ���̶� ���߿� ���� ����
    public TextMeshProUGUI Score2; // �׳� üũ������ �־�� ���̶� ���߿� ���� ����
    public GameObject Player; // OVRPlayerContoroller
    public GameObject Cam; // ī�޶� ������
    public GameObject RightHand; // ī�޶� ������'
    public GameObject Camera_light;


    FingerPrintLiquidScore2 fingerprintliquid;
    private int first_score = 0; //�и����� �ϱ� ���� ������ ���� ���
    private int second_score = 0; //�и����� �� �Ŀ� ������ ���� ���

    private bool first_check = false; //�и����� �ϱ� ���� ������ ������� Ȯ��
    private bool second_check = false;//�и����� �� �Ŀ� ������ ������� Ȯ��

    public GameObject HandTrigger;
    npcText failed;
    private bool first_Failed = false;
    private bool first_Failed_check = false; //�и� �� �� ���� x���� ��� �޽����� �� ���� ���� ����


    private bool second_Failed = false;


    public GameObject other;

    public GameObject other1;
    public GameObject other2;
    public GameObject other3;
    public GameObject other4;



    public bool doing = false; // ���� �ٸ� �۾��� ���������� Ȯ���ϴ� �ڵ�.



    public OnLight CheckLight;


    void Start()
    {
        fingerprintliquid = GetComponent<FingerPrintLiquidScore2>();

        failed = HandTrigger.GetComponent<npcText>();


        CheckLight = GetComponent<OnLight>();
    }


    private float MaxDistance = 5f; //����ĳ��Ʈ �Ÿ�(ī�޶�  �Կ� �Ÿ���� �����ص� ��)
    void Update()
    {
        if (fingerprintliquid.liquidTriggered == true)
        {
            doing = true;
        }

        /*
        if (fingerprintliquid.liquidTriggered == true && first_check != true && first_Failed == false)
        {
            first_Failed = true;
            //0424 �и��� ���� ������ ���� �ʾ��� ���
            failed.FailedFirstCamera_Liquid();
        }*/

        //������̱⸦ ���� ������ ������ ������ ���� �ʰ� �ٸ� ���Ź��� ������ ���
        /*
        if (fingerprintliquid.hairLiquidTriggered == true && second_check!=true)
        {
            second_Failed = true;

            doing = false;
        }*/

        //if (OVRInput.GetDown(OVRInput.Button.Three)) //X��ư�� ���� ���
        if (OVRInput.GetDown(OVRInput.Button.One)) //A��ư�� ���� ���
        {
            // Cube ������Ʈ�� Camera�� ���� ���̴��� Ȯ��
            if (cameraToCheck != null)
            {

                RaycastHit hit; //����ĳ��Ʈ�� �ε����� ��
                Vector3 rayDirection = cameraToCheck.transform.position - transform.position;
                // ī�޶�� ���ϴ� ��ü���� �Ÿ�
                // Cube�� Camera ���̿� �ٸ� ��ü�� �ִ��� Raycast�� ���� Ȯ��
                ///ó�� �õ� �ÿ��� �Ÿ� üũ x
                if (fingerprintliquid.liquidTriggered == false)
                {
                    if (Physics.Raycast(transform.position, rayDirection, out hit))
                    //ī�޶�� ��ü ���̿� ���� �ε��� ���z
                    {
                        //�ν��ϰ��� �ϴ� ��ü�� ī�޶�, �÷��̾� ������Ʈ�� ������ ���� ����
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other
                            && hit.collider.gameObject != other1 && hit.collider.gameObject != other2 && hit.collider.gameObject != other3 && hit.collider.gameObject != other4)
                        {
                            // �ٸ� ��ü�� ������ ������ "False" ���
                            // Check.text = "False1";
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("(��ü��)�ٸ� ��ü�� ������ �ִ�." + hiddenObjectName);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("�Ÿ�����");
                        return;
                    }
                }

                // 2��° �õ������� �������� �Կ��ϹǷ� �Ÿ� üũ O
                if (fingerprintliquid.liquidTriggered == true)
                {
                    /*
                    if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))
                    //ī�޶�� ��ü ���̿� ���� �ε��� ���z
                    {
                        if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other
                            && hit.collider.gameObject != other1)
                        {
                            // �ٸ� ��ü�� ������ ������ "False" ���
                            string hiddenObjectName = hit.collider.gameObject.name;
                            Debug.Log("�ٸ� ��ü�� ������ �ִ�." + hiddenObjectName);
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("�Ÿ�����");
                        return;
                    }*/




                    if (CheckLight.onLight == true)
                    {
                        if (Physics.Raycast(transform.position, rayDirection, out hit, MaxDistance))
                        //ī�޶�� ��ü ���̿� ���� �ε��� ���z
                        {
                            if (hit.collider.gameObject != cameraToCheck.gameObject && hit.collider.gameObject != gameObject && hit.collider.gameObject != Player && hit.collider.gameObject != gameObject && hit.collider.gameObject != Cam && hit.collider.gameObject != RightHand && hit.collider.gameObject != Camera_light && hit.collider.gameObject != other
                                && hit.collider.gameObject != other1 && hit.collider.gameObject != other2 && hit.collider.gameObject != other3 && hit.collider.gameObject != other4)
                            {
                                // �ٸ� ��ü�� ������ ������ "False" ���
                                string hiddenObjectName = hit.collider.gameObject.name;
                                Debug.Log("(��ü��)�ٸ� ��ü�� ������ �ִ�." + hiddenObjectName);
                                return;
                            }
                        }
                        else
                        {
                            Debug.Log("�Ÿ�����");
                            return;
                        }
                    }
                    else
                    {
                        Debug.Log("����Ʈ x ");
                        return;
                    }

                }



                    Vector3 viewportPoint = cameraToCheck.WorldToViewportPoint(transform.position);

                    if (viewportPoint.x > 0.1 && viewportPoint.x < 0.9 &&
                         viewportPoint.y > 0.1 && viewportPoint.y < 0.9 && viewportPoint.z > 0)
                    {
                        if (fingerprintliquid.liquidTriggered == false && first_check != true) // �и����� �ϱ� �� ������ ����� ���
                        {
                            first_score = 15;
                            first_check = true;
                            Debug.Log("��׿� �㱸�� �� ������ �����..");
                        }

                        if (fingerprintliquid.hairLiquidTriggered == true && second_check != true && second_Failed == false) // �и����� �� �� ������ ����� ���
                        {
                            second_score = 15;
                            second_check = true;
                            Debug.Log("������̱� ��� �� ������ �����..");


                            doing = false;
                        }

                        Score.text = "" + first_score;
                        Score2.text = "" + second_score;
                        Debug.Log("True");
                    }
                    else
                    {
                        Debug.Log("��ü�� ī�޶� �ȿ� ����.");

                    }
                }
            }
        }
    }
