using UnityEngine;
using System.Collections;

class Shop
{

    public static int levelAward = 5;

	private static int starScore{ get; set; }
	public static int StarScore{ 
		get{ 
			starScore = PlayerPrefs.GetInt ("StarScore");
			return starScore;
		}
		set{ 
			starScore = value;
			PlayerPrefs.SetInt ("StarScore", starScore);
		}
	}

	public static bool Buy(string name){
		if (10 <= StarScore) {
			StarScore = StarScore - 10;
			PlayerPrefs.SetString (name, "Buyed");
			return true;
		} else {
			return false;
		}
	}
	public static bool BuyHint(){
		if (StarScore>= 0) {
			StarScore = StarScore - 10;
			return true;
		} else {
			return false;
		}
	}
	public static bool CanBuyHint(){
		if (StarScore >= 10) {
			return true;
		} else {
			return false;
		}
	}


	public static void AddStar(int starIndex){
		StarScore = StarScore + starIndex;
	}
}
