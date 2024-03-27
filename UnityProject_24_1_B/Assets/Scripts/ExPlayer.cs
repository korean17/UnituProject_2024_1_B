using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExPlayer : MonoBehaviour
{
    public Rigidbody m_Rigidbody;                 //리지드 바디를 소스로 사용하게 받아 온다.
    public int Force = 100;                     //int 정수로 힘을 100으로 설장 한다.
    public int point = 0;                       //점수 사용할 변수 추가
    public float checkTime = 0;                //시간 측정을 위한 변수 (소수점)
    public Text m_Text;                         //UI 텍스트 접근

    void Start()
    {
        checkTime += Time.deltaTime;                        //프레임 시작을 더해서 시간을 측정
        if (checkTime >= 1.0f)                               //만약 1초가 지났을 경우
        {
            point += 1;                                     //point = point + 축약 (1점씩 더해준다.)
            checkTime = 0.0f;                               //1초가 지날경우 초기화 (0초 -> 1초 -> 0초 -> 1초)
        }

        m_Text.text = point.ToString();                     //UI 표시
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))                   //마우스 입력이 들어왔을때
        if (Input.GetKeyDown(KeyCode.Space))                 //스페이스 입력이 들어왔을때
        {
            m_Rigidbody.AddForce(transform.up * Force);               //transform.up(위쪽 방향)으로 리지드 바디에 Force 힘만큼 물리의 힘을 준다.
        }
       
    }

    private void OncollisionEnter(Collision collision)      //충돌이 시작되었을 때
    {
        if (collision != null)                              //충돌 물체가 존재할 경우
        {
            point = 0;                                      //충돌이 일어났을때 포인트를 0으로 해준다.
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f); //충돌했을때 위치를 초기화
            Debug.Log(collision.gameObject.name);           //해당 오브젝트의 이름을 출력한다.
        }
    }
}
