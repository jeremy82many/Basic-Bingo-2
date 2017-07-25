using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi.Multiplayer;
using System.Collections.Generic;

public class MultiplayerController : RealTimeMultiplayerListener {
//
	private static MultiplayerController _instance = null;

	private uint minimumOpponents = 1;
	private uint maximumOpponents = 1;
	private uint gameVariation = 0;

	public bool showingWaitingRoom = false;

	private byte _protocolVersion = 1;
	// Byte + Byte + 2 floats for position + 2 floats for velcocity + 1 float for rotZ
	private int _updateMessageLength = 506;//246
	private List<byte> _updateMessage;


	public MPUpdateListener updateListener;

	private MultiplayerController() {
		_updateMessage = new List<byte>(_updateMessageLength);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
	}
//
	public static MultiplayerController Instance {
		get {
			if (_instance == null) {
				_instance = new MultiplayerController();
			}
			return _instance;
		}
	}

	public void SignInAndStartMPGame() {
		if (! PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.localUser.Authenticate((bool success) => {
				if (success) {
					Debug.Log ("We're signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
				} else {
					Debug.Log ("Oh... we're not signed in.");
				}
			});
		} else {
			Debug.Log ("You're already signed in.");
			// We could also start our game now
		}
	}

	public bool CheckSignInSignOut(){
		if (!PlayGamesPlatform.Instance.localUser.authenticated) {
			return false;
		} else {
			return true;
		}
	}

	public void OnRoomSetupProgress (float percent)
	{
		//ShowMPStatus ("We are " + percent + "% done with setup");
		// show the default waiting room.
		if (!showingWaitingRoom) {
			showingWaitingRoom = true;
			GameController.GameCon.isMultiplayerGame = true;
			GameController.GameCon.inQueForOnlineMatch = true;
			PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI ();
			UIController.UICon.hidePlaymodeOnlineGroup ();
			UIController.UICon.loadPlaymodeMainGroup ();
			GameController.GameCon.computerPlay.interactable = false;
			GameController.GameCon.onlinePlay.interactable = false;
			GameController.GameCon.backPlayMode.interactable = false;
			GameController.GameCon.findingOpponent.SetActive (true);
		}

	}

	public void OnRoomConnected (bool success)
	{
		if (success) {
			//lobbyListener.HideLobby();
			updateListener = null;
			GameController.GameCon.SetupMultiplayerGame();
			if(GameController.GameCon._multiplayerReady){
				ButtonController.BtnCon.PlaymodeComputer ();
				showingWaitingRoom = false;
				GameController.GameCon.findingOpponent.SetActive (false);
				GameController.GameCon.inQueForOnlineMatch = false;
				GameController.GameCon.computerPlay.interactable = true;
				GameController.GameCon.onlinePlay.interactable = true;
				GameController.GameCon.backPlayMode.interactable = true;
			}
		} else {
			ShowMPStatus ("Uh-oh. Encountered some error connecting to the room.");
		}
	}

	public void OnLeftRoom ()
	{
		ShowMPStatus("We have left the room.");
		if (updateListener != null) {
			updateListener.LeftRoomConfirmed();
		}
	}

	public void OnParticipantLeft (Participant participant)
	{
		throw new System.NotImplementedException ();
	}

	public void OnPeersConnected (string[] participantIds)
	{
		foreach (string participantID in participantIds) {
			ShowMPStatus ("Player " + participantID + " has joined.");
		}
	}

	public void OnPeersDisconnected (string[] participantIds)
	{
		foreach (string participantID in participantIds) {
			ShowMPStatus ("Player " + participantID + " has left.");
			if (updateListener != null) {
				updateListener.PlayerLeftRoom (participantID);
			}
		}
	}

	public void OnRealTimeMessageReceived (bool isReliable, string senderId, byte[] data)
	{
		// We'll be doing more with this later...
		byte messageVersion = (byte)data[0];
		// Let's figure out what type of message this is.
		char messageType = (char)data[1];
		if (messageType == 'U' && data.Length == _updateMessageLength) { 
			float b1 = System.BitConverter.ToSingle(data, 2);
			float b2 = System.BitConverter.ToSingle(data, 6);
			float b3 = System.BitConverter.ToSingle(data, 10);
			float b4 = System.BitConverter.ToSingle(data, 14);
			float b5 = System.BitConverter.ToSingle(data, 18);
			float i1 = System.BitConverter.ToSingle(data, 22);
			float i2 = System.BitConverter.ToSingle(data, 26);
			float i3 = System.BitConverter.ToSingle(data, 30);
			float i4 = System.BitConverter.ToSingle(data, 34);
			float i5 = System.BitConverter.ToSingle(data, 38);
			float n1 = System.BitConverter.ToSingle(data, 42);
			float n2 = System.BitConverter.ToSingle(data, 46);
			float n4 = System.BitConverter.ToSingle(data, 50);
			float n5 = System.BitConverter.ToSingle(data, 54);
			float g1 = System.BitConverter.ToSingle(data, 58);
			float g2 = System.BitConverter.ToSingle(data, 62);
			float g3 = System.BitConverter.ToSingle(data, 66);
			float g4 = System.BitConverter.ToSingle(data, 70);
			float g5 = System.BitConverter.ToSingle(data, 74);
			float o1 = System.BitConverter.ToSingle(data, 78);
			float o2 = System.BitConverter.ToSingle(data, 82);
			float o3 = System.BitConverter.ToSingle(data, 86);
			float o4 = System.BitConverter.ToSingle(data, 90);
			float o5 = System.BitConverter.ToSingle(data, 94);
			float colb1 = System.BitConverter.ToSingle(data, 98);
			float colb2 = System.BitConverter.ToSingle(data, 102);
			float colb3 = System.BitConverter.ToSingle(data, 106);
			float colb4 = System.BitConverter.ToSingle(data, 110);
			float colb5 = System.BitConverter.ToSingle(data, 114);
			float coli1 = System.BitConverter.ToSingle(data, 118);
			float coli2 = System.BitConverter.ToSingle(data, 122);
			float coli3 = System.BitConverter.ToSingle(data, 126);
			float coli4 = System.BitConverter.ToSingle(data, 130);
			float coli5 = System.BitConverter.ToSingle(data, 134);
			float coln1 = System.BitConverter.ToSingle(data, 138);
			float coln2 = System.BitConverter.ToSingle(data, 142);
			float coln3 = System.BitConverter.ToSingle(data, 146);
			float coln4 = System.BitConverter.ToSingle(data, 150);
			float coln5 = System.BitConverter.ToSingle(data, 154);
			float colg1 = System.BitConverter.ToSingle(data, 158);
			float colg2 = System.BitConverter.ToSingle(data, 162);
			float colg3 = System.BitConverter.ToSingle(data, 166);
			float colg4 = System.BitConverter.ToSingle(data, 170);
			float colg5 = System.BitConverter.ToSingle(data, 174);
			float colo1 = System.BitConverter.ToSingle(data, 178);
			float colo2 = System.BitConverter.ToSingle(data, 182);
			float colo3 = System.BitConverter.ToSingle(data, 186);
			float colo4 = System.BitConverter.ToSingle(data, 190);
			float colo5 = System.BitConverter.ToSingle(data, 194);
			float bothPlayersReady = System.BitConverter.ToSingle(data, 198);
			float test1 = System.BitConverter.ToSingle(data, 202);
			float _lastUpdateTime = System.BitConverter.ToSingle(data, 206);
			float test2 = System.BitConverter.ToSingle(data, 210);
			float test3 = System.BitConverter.ToSingle(data, 214);
			float test4 = System.BitConverter.ToSingle(data, 218);
			float test5 = System.BitConverter.ToSingle(data, 222);
			float test6 = System.BitConverter.ToSingle(data, 226);
			float test7 = System.BitConverter.ToSingle(data, 230);
			float test8 = System.BitConverter.ToSingle(data, 234);
			float test9 = System.BitConverter.ToSingle(data, 238);
			float test10 = System.BitConverter.ToSingle(data, 242);
			float test11 = System.BitConverter.ToSingle(data, 246);
			float test12 = System.BitConverter.ToSingle(data, 250);
			float test13 = System.BitConverter.ToSingle(data, 254);
			float test14 = System.BitConverter.ToSingle(data, 258);
			float test15 = System.BitConverter.ToSingle(data, 262);
			float test16 = System.BitConverter.ToSingle(data, 266);
			float test17 = System.BitConverter.ToSingle(data, 270);
			float test18 = System.BitConverter.ToSingle(data, 274);
			float test19 = System.BitConverter.ToSingle(data, 278);
			float test20 = System.BitConverter.ToSingle(data, 282);
			float test21 = System.BitConverter.ToSingle(data, 286);
			float test22 = System.BitConverter.ToSingle(data, 290);
			float test23 = System.BitConverter.ToSingle(data, 294);
			float test24 = System.BitConverter.ToSingle(data, 298);
			float test25 = System.BitConverter.ToSingle(data, 302);
			float test26 = System.BitConverter.ToSingle(data, 306);
			float test27 = System.BitConverter.ToSingle(data, 310);
			float test28 = System.BitConverter.ToSingle(data, 314);
			float test29 = System.BitConverter.ToSingle(data, 318);
			float test30 = System.BitConverter.ToSingle(data, 322);
			float test31 = System.BitConverter.ToSingle(data, 326);
			float test32 = System.BitConverter.ToSingle(data, 330);
			float test33 = System.BitConverter.ToSingle(data, 334);
			float test34 = System.BitConverter.ToSingle(data, 338);
			float test35 = System.BitConverter.ToSingle(data, 342);
			float test36 = System.BitConverter.ToSingle(data, 346);
			float test37 = System.BitConverter.ToSingle(data, 350);
			float test38 = System.BitConverter.ToSingle(data, 354);
			float test39 = System.BitConverter.ToSingle(data, 358);
			float test40 = System.BitConverter.ToSingle(data, 362);
			float test41 = System.BitConverter.ToSingle(data, 366);
			float test42 = System.BitConverter.ToSingle(data, 370);
			float test43 = System.BitConverter.ToSingle(data, 374);
			float test44 = System.BitConverter.ToSingle(data, 378);
			float test45 = System.BitConverter.ToSingle(data, 382);
			float test46 = System.BitConverter.ToSingle(data, 386);
			float test47 = System.BitConverter.ToSingle(data, 390);
			float test48 = System.BitConverter.ToSingle(data, 394);
			float test49 = System.BitConverter.ToSingle(data, 398);
			float test50 = System.BitConverter.ToSingle(data, 402);
			float test51 = System.BitConverter.ToSingle(data, 406);
			float test52 = System.BitConverter.ToSingle(data, 410);
			float test53 = System.BitConverter.ToSingle(data, 414);
			float test54 = System.BitConverter.ToSingle(data, 418);
			float test55 = System.BitConverter.ToSingle(data, 422);
			float test56 = System.BitConverter.ToSingle(data, 426);
			float test57 = System.BitConverter.ToSingle(data, 430);
			float test58 = System.BitConverter.ToSingle(data, 434);
			float test59 = System.BitConverter.ToSingle(data, 438);
			float test60 = System.BitConverter.ToSingle(data, 442);
			float test61 = System.BitConverter.ToSingle(data, 446);
			float test62 = System.BitConverter.ToSingle(data, 450);
			float test63 = System.BitConverter.ToSingle(data, 454);
			float test64 = System.BitConverter.ToSingle(data, 458);
			float test65 = System.BitConverter.ToSingle(data, 462);
			float test66 = System.BitConverter.ToSingle(data, 466);
			float test67 = System.BitConverter.ToSingle(data, 470);
			float test68 = System.BitConverter.ToSingle(data, 474);
			float test69 = System.BitConverter.ToSingle(data, 478);
			float test70 = System.BitConverter.ToSingle(data, 482);
			float test71 = System.BitConverter.ToSingle(data, 486);
			float test72 = System.BitConverter.ToSingle(data, 490);
			float test73 = System.BitConverter.ToSingle(data, 494);
			float test74 = System.BitConverter.ToSingle(data, 498);
			float test75 = System.BitConverter.ToSingle(data, 502);
			// We'd better tell our GameController about this.
			if (updateListener != null) {
				updateListener.UpdateReceived(senderId, b1, b2, b3, b4, b5, i1, i2, i3, i4, i5, n1, n2, n4, n5, g1, g2, g3, g4, g5, o1, o2, o3, o4, o5, colb1, colb2, colb3, colb4, colb5, coli1, coli2, coli3, coli4, coli5, coln1, coln2, coln3, coln4, coln5, colg1, colg2, colg3, colg4, colg5, colo1, colo2, colo3, colo4, colo5, bothPlayersReady, test1, _lastUpdateTime, test2, test3, test4, test5, test6, test7, test8, test9, test10, test11, test12, test13, test14, test15, test16, test17, test18, test19, test20, test21, test22, test23, test24, test25, test26, test27, test28, test29, test30, test31, test32, test33, test34, test35, test36, test37, test38, test39, test40, test41, test42, test43, test44, test45, test46, test47, test48, test49, test50, test51, test52, test53, test54, test55, test56, test57, test58, test59, test60, test61, test62, test63, test64, test65, test66, test67, test68, test69, test70, test71, test72, test73, test74, test75);
			}
		}
	}

	public void TrySilentSignIn() {
		if (! PlayGamesPlatform.Instance.localUser.authenticated) {
			PlayGamesPlatform.Instance.Authenticate ((bool success) => {
				if (success) {
					Debug.Log ("Silently signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
				} else {
					Debug.Log ("Oh... we're not signed in.");
				}
			}, true);
		} else {
			Debug.Log("We're already signed in");
		}
	}

	public void SignOut() {
		PlayGamesPlatform.Instance.SignOut ();
	}

	public bool IsAuthenticated() {
		return PlayGamesPlatform.Instance.localUser.authenticated;
	}

	public void StartMatchMaking() {
		PlayGamesPlatform.Instance.RealTime.CreateQuickGame (minimumOpponents, maximumOpponents, gameVariation, this);
	}
		
	private void ShowMPStatus(string message) {
		Debug.Log(message);
	}

	public List<Participant> GetAllPlayers() {
		return PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants ();
	}

	public string GetMyParticipantId() {
		return PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId;
	}

	public void SendMyUpdate(float b1, float b2, float b3, float b4, float b5, float i1, float i2, float i3, float i4, float i5, float n1, float n2, float n4, float n5, float g1, float g2, float g3, float g4, float g5, float o1, float o2, float o3, float o4, float o5, Color colb1, Color colb2, Color colb3, Color colb4, Color colb5, Color coli1, Color coli2, Color coli3, Color coli4, Color coli5, Color coln1, Color coln2, Color coln3, Color coln4, Color coln5, Color colg1, Color colg2, Color colg3, Color colg4, Color colg5, Color colo1, Color colo2, Color colo3, Color colo4, Color colo5, float bothPlayersReady, float test1, float _lastUpdateTime, float test2, float test3, float test4, float test5, float test6, float test7, float test8, float test9, float test10, float test11, float test12, float test13, float test14, float test15, float test16, float test17, float test18, float test19, float test20, float test21, float test22, float test23, float test24, float test25, float test26, float test27, float test28, float test29, float test30, float test31, float test32, float test33, float test34, float test35, float test36, float test37, float test38, float test39, float test40, float test41, float test42, float test43, float test44, float test45, float test46, float test47, float test48, float test49, float test50, float test51, float test52, float test53, float test54, float test55, float test56, float test57, float test58, float test59, float test60, float test61, float test62, float test63, float test64, float test65, float test66, float test67, float test68, float test69, float test70, float test71, float test72, float test73, float test74, float test75) {
		_updateMessage.Clear ();
		_updateMessage.Add (_protocolVersion);
		_updateMessage.Add ((byte)'U');
		_updateMessage.AddRange (System.BitConverter.GetBytes (b1));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (b2));
		_updateMessage.AddRange (System.BitConverter.GetBytes (b3));
		_updateMessage.AddRange (System.BitConverter.GetBytes (b4));
		_updateMessage.AddRange (System.BitConverter.GetBytes (b5));
		_updateMessage.AddRange (System.BitConverter.GetBytes (i1));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (i2));
		_updateMessage.AddRange (System.BitConverter.GetBytes (i3));
		_updateMessage.AddRange (System.BitConverter.GetBytes (i4));
		_updateMessage.AddRange (System.BitConverter.GetBytes (i5));
		_updateMessage.AddRange (System.BitConverter.GetBytes (n1));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (n2));
		_updateMessage.AddRange (System.BitConverter.GetBytes (n4));
		_updateMessage.AddRange (System.BitConverter.GetBytes (n5));
		_updateMessage.AddRange (System.BitConverter.GetBytes (g1));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (g2));
		_updateMessage.AddRange (System.BitConverter.GetBytes (g3));
		_updateMessage.AddRange (System.BitConverter.GetBytes (g4));
		_updateMessage.AddRange (System.BitConverter.GetBytes (g5));
		_updateMessage.AddRange (System.BitConverter.GetBytes (o1));  
		_updateMessage.AddRange (System.BitConverter.GetBytes (o2));
		_updateMessage.AddRange (System.BitConverter.GetBytes (o3));
		_updateMessage.AddRange (System.BitConverter.GetBytes (o4));
		_updateMessage.AddRange (System.BitConverter.GetBytes (o5));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colb1.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colb2.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colb3.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colb4.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colb5.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coli1.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coli2.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coli3.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coli4.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coli5.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coln1.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coln2.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coln3.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coln4.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (coln5.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colg1.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colg2.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colg3.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colg4.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colg5.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colo1.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colo2.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colo3.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colo4.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (colo5.a));
		_updateMessage.AddRange (System.BitConverter.GetBytes (bothPlayersReady));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test1));
		_updateMessage.AddRange (System.BitConverter.GetBytes (_lastUpdateTime));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test2));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test3));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test4));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test5));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test6));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test7));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test8));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test9));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test10));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test11));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test12));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test13));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test14));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test15));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test16));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test17));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test18));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test19));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test20));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test21));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test22));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test23));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test24));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test25));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test26));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test27));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test28));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test29));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test30));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test31));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test32));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test33));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test34));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test35));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test36));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test37));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test38));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test39));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test40));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test41));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test42));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test43));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test44));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test45));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test46));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test47));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test48));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test49));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test50));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test51));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test52));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test53));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test54));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test55));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test56));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test57));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test58));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test59));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test60));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test61));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test62));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test63));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test64));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test65));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test66));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test67));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test68));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test69));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test70));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test71));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test72));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test73));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test74));
		_updateMessage.AddRange (System.BitConverter.GetBytes (test75));
		byte[] messageToSend = _updateMessage.ToArray(); 
		//Debug.Log ("Sending my update message  " + messageToSend + " to all players in the room");
		PlayGamesPlatform.Instance.RealTime.SendMessageToAll (false, messageToSend);
	}

	public void LeaveGame() {
		PlayGamesPlatform.Instance.RealTime.LeaveRoom ();
		GameController.GameCon.isMultiplayerGame = false;
		GameController.GameCon._multiplayerReady = false;
	}
}