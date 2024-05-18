using System.Collections;
using UnityEngine;

public class PackingEvidence : MonoBehaviour
{
    public GameObject EvidenceObj;  // 밀봉 전 증거물 object
    public GameObject PackedObj;    // 밀봉 후 증거물 object

    private bool isGrabbed = false;  // grab 상태 false로 초기화

    public void PackEvidence()
    {
        // 컨트롤러 Y버튼 누르면 증거물 packed
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            Debug.Log("Y 버튼 눌림, 증거물 밀봉 시작");

            PackedObj.transform.position = EvidenceObj.transform.position;
            PackedObj.transform.rotation = EvidenceObj.transform.rotation;

            EvidenceObj.SetActive(false);
            Debug.Log("EvidenceObj 비활성화");

            PackedObj.SetActive(true);
            Debug.Log("PackedObj 활성화");

            SoundManager.Instance.PlaySFX(SoundManager.SFX_list.FLAP_2); // 사운드 추가 - 정현우
        }
    }

    public void OnGrab()
    {
        isGrabbed = true;
        StartCoroutine(CheckGrabbed());
    }

    public void OffGrab()
    {
        isGrabbed = false;
        StopCoroutine(CheckGrabbed());
    }

    private IEnumerator CheckGrabbed()
    {
        while (isGrabbed)
        {
            PackEvidence();
            yield return null; // 다음 프레임까지 대기
        }
    }
}
