using UnityEngine;
//
#pragma warning disable 0108
#pragma warning disable 0649
//
public class Death : MonoBehaviour
{
	[SerializeField] private Score scoreEngine;

	private void Start()
	{
		GetComponent<TMPro.TMP_Text>().text = scoreEngine.CurrentScore().ToString();
	}
}
