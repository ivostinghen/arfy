// using UnityEngine;
// using UnityEngine.UI;

// using System.Collections;
// using UnityEngine.AI;
// public class PlayerGirl : MonoBehaviour {

//     Animator anim;
//     public float speed;
//     public NavMeshAgent agent;
//     public Controller controller; 
//     Vector3 current,previous ;
//     public LayerMask layerMask;
//     bool firstPress ;
//     public bool firstQuest;
// 	void Start () 
// 	{
//         // controller = GameObject.Find("Controller").GetComponent<Controller>();
//         // anim = GetComponentInChildren<Animator>();
//         agent = GetComponentInChildren<NavMeshAgent>();
// 	}
	
// 	void Update () 
//     {
//         // current = transform.position;
//         // var velocity = (current - previous) / Time.deltaTime;
//         // anim.SetFloat("Walk",velocity.magnitude);
//         if (Input.GetMouseButtonDown(0))
//         {
            
//             // if(controller.inScene)return;
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//             if (Physics.Raycast(ray, out hit ,100,layerMask))
//             {
//                 // agent.SetDestination(hit.point);
                
//                 if(!firstPress && hit.transform.name.Equals("Character"))
//                 {
//                     firstPress=true;
                    
//                     // controller.GetComponent<UIController>().DisableAssitance();
                
//                 }
//                 // if(hit.transform.gameObject.layer == 0)
//                 // {
                    

//                 // }
//                 //  if(hit.transform.gameObject.layer != 0  && Vector3.Distance(transform.position,hit.transform.position) < 3F)
//                 // {
//                 //     if(!firstQuest)
//                 //     {
//                 //         firstQuest = true;
//                 //         Destroy(GameObject.Find("TrackAssistance"));
//                 //     } 
//                 //     if(hit.transform.name.Equals("apple") || hit.transform.name.Equals("strawberry") )  //Ativando as frutas.
//                 //     {

//                 //         GameObject.Find("Controller").GetComponent<UIController>().ShowQuestion(hit.transform.gameObject);
//                 //     }
//                 //     else{   //Falando com o crocodilo.
//                 //         controller.GetComponent<Quest>().CallQuest();
//                 //     }
//                 // }
//             }
//         }
//         previous = transform.position;
// 	}
	
// 	public void Jump()
// 	{
// 		anim.SetTrigger("Jump");
// 	}

//     //  void OnTriggerEnter(Collider col)
//     // {
            
//     //     if(col.tag.Equals("Item"))
//     //     {
//     //         col.transform.GetChild(0).gameObject.SetActive(true);
//     //     }
//     //     // GetComponent<Collider>().enabled = false;
//     //     // transform.GetChild(0).gameObject.SetActive(true);
       
//     // }
//     // void OnTriggerExit(Collider col)
//     // {
//     //     if(col.tag.Equals("Item"))
//     //     {
//     //         col.transform.GetChild(0).gameObject.SetActive(false);
//     //     }

//     // }
// }
