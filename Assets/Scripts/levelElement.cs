using UnityEngine;
using UnityEngine.UI;

public class levelElement : MonoBehaviour {

	public Sprite Lock;
	public Sprite Unlock;
	public int Index{ get; private set;}
	public Text infa;

	void Start(){
		GetComponent<Image> ().sprite = Saver.isLevelPlayable(Index) ? Unlock : Lock;
	}
		

	public void SetLevelNumber(){
		if(Saver.isLevelPlayable (Index)){
		ScenesParameters.CurrentLevel = Index;
			Application.LoadLevel (3);
		}
	}
	public void SetLevelIndex(int index){
	    if (Saver.isLevelPlayable(index))
	    {
            Index = index;
            infa.text = index.ToString();
        }
	    else
	    {
	        infa.gameObject.SetActive(false);
	    }
        
	}
}
