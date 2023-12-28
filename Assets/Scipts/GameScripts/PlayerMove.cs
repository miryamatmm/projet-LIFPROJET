using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true){
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow)){
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide){
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow)){
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide){
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)){
                if(isJumping == false){
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Running Jump");
                    StartCoroutine(JumpSequence());
                }
            }
            if(isJumping){
                if(!comingDown){
                    transform.Translate(Vector3.up * Time.deltaTime * 10, Space.World);
                }else{
                    transform.Translate(Vector3.up * Time.deltaTime * -10, Space.World);
                }
            }
        }
    }

    IEnumerator JumpSequence() {
        float initialHeight = transform.position.y;
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.35f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Goofy Running");
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z - 25);
    }
}
