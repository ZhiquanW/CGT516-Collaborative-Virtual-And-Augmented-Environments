using UnityEngine;

public class HandDetector : MonoBehaviour {
    public bool isAttachCargo;
    public GameObject targetCargo;


    private void OnTriggerEnter(Collider other) {
        float tmpOffsetY = Mathf.Abs(other.transform.position.y - this.transform.position.y);
        if (other.transform.CompareTag("cargo") && tmpOffsetY < 1.0f) {
            isAttachCargo = true;
            GantryCraneController.instance.caughtCargo = other.gameObject;
            var transform1 = this.transform;
            GantryCraneController.instance.offsetPos = other.transform.position - transform1.position;
            GantryCraneController.instance.refTransform = transform1;
        }
    }

    private void OnTriggerExit(Collider other) {
        
        if (other.transform.CompareTag("cargo")) {
            isAttachCargo = false;
            GantryCraneController.instance.dropCargo();
        }
    }
}
