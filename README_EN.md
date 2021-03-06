# MobPush-For-Unity
### This is a UnityPackage for MobPush. It's an convenient tool for you to quickly implement deliver message feature on your Unity Project on iOS/Android.

**supported original MobPush version:**

- [Android](https://github.com/MobClub/MobPush-for-Android) - V1.4.0
- [iOS](https://github.com/MobClub/MobPush-for-iOS) - V1.4.0

**Document Language :** **[中文](https://github.com/MobClub/MobPush-For-Unity)** | **English**

- - - - - - - - - - - -

### *Integration of general part*

#### Step 1 : Download MobPush.unitypackage
Download this git(master),import the MobPush.unitypackage to your Unity project.
Please notice that this operation could cover your original existed files!

#### Step 2 : Set up script and configurations
Make sure that the 'MobPush' component was added to your GameObject(such as 'Main Camera').Click'Add Component' from the right-hand side bar, and choose 'Mob Push'.
![](https://github.com/orangetell/MobPush-For-Unity/blob/master/images/add-component.jpg)

Then configurate the Build Settings.

**On Android Platform**
configurate gradle settings
![](https://github.com/orangetell/MobPush-For-Unity/blob/master/images/build-settings.jpg)
modify mainTemplate.gradle
![](https://github.com/orangetell/MobPush-For-Unity/blob/master/images/android-gradle-settings.png)
modify proguard-user.txt
![](https://github.com/orangetell/MobPush-For-Unity/blob/master/images/android-proguard-settings.jpg)

**On iOS Platform**
configurate the MobAppKey and MobAppSecret
![](https://github.com/orangetell/MobPush-For-Unity/blob/master/images/ios-settings.png)

#### Setp 3 ：interface
**setup**
```
public MobPush mobPush;

        void Start ()
	{	
		mobPush = gameObject.GetComponent();//初始化MobPush
		mobPush.onNotifyCallback = OnNitifyHandler;//消息回调监听
		mobPush.onTagsCallback = OnTagsHandler;//标签处理回调监听
		mobPush.onAliasCallback = OnAliasHandler;//别名处理回调监听
		mobPush.onDemoReqCallback = OnDemoReqHandler;//demo请求接口回调(为了方便测试，提供在客户端发送通知的接口，仅供测试时使用)
		mobPush.onRegIdCallback = OnRegIdHandler;//获取注册ID异步监听回调接口
	}
        void OnNitifyHandler (int action, Hashtable resulte)
	{
		Debug.Log ("OnNitifyHandler");
		if (action == ResponseState.CoutomMessage)
		{
			Debug.Log ("CoutomMessage:" + MiniJSON.jsonEncode(resulte));
		}
		else if (action == ResponseState.MessageRecvice)
		{
			Debug.Log ("MessageRecvice:" + MiniJSON.jsonEncode(resulte));
		}
		else if (action == ResponseState.MessageOpened) 
		{
			Debug.Log ("MessageOpened:" + MiniJSON.jsonEncode(resulte));
		}
	}
	
	void OnTagsHandler (int action, string[] tags, int operation, int errorCode)
	{
		
		Debug.Log ("OnTagsHandler  action:" + action + " tags:" + String.Join (",", tags) + " operation:" + operation + "errorCode:" + errorCode);
	}

	void OnAliasHandler (int action, string alias, int operation, int errorCode)
	{
		Debug.Log ("OnAliasHandler action:" + action + " alias:" + alias + " operation:" + operation + "errorCode:" + errorCode);
	}

	void OnRegIdHandler (string regId)
	{
		Debug.Log ("OnRegIdHandler-regId:" + regId);
	}

	void OnDemoReqHandler (bool isSuccess)
	{
		Debug.Log ("OnDemoReqHandler:" + isSuccess);
	}
  ```
**get registrationId**
```
mobPush.getRegistrationId ();
```
**operate tags**
```
String[] tags = { "tags1", "tags2", "tags3" };
mobPush.addTags (tags); //set
mobPush.getTags (); //get
mobPush.deleteTags (tags); //delete
```
**operate alias**
```
mobPush.addAlias ("alias");
mobPush.getAlias ();
mobPush.cleanAllAlias ();
```
**send local notification**
```
LocalNotifyStyle style = new LocalNotifyStyle ();
style.setContent ("Text");
style.setTitle ("title");
 
#if UNITY_ANDROID
	Hashtable extras = new Hashtable ();
	extras["key1"] = "value1";
	extras["key2"] = "value1";
	style.setExtras (extras);
#endif
mobPush.setMobPushLocalNotification (style);
```
**customize notification style**
```
CustomNotifyStyle style = new CustomNotifyStyle ();
 
		#if UNITY_IPHONE
 
			style.setType(CustomNotifyStyle.AuthorizationType.Badge | CustomNotifyStyle.AuthorizationType.Sound | CustomNotifyStyle.AuthorizationType.Alert);
 
		#elif UNITY_ANDROID
 
			style.setContent ("Content");
			style.setTitle ("Title");
			style.setTickerText ("TickerText");
 
		#endif
			
			mobPush.setCustomNotification(style);
  ```

**Please refer to the Demo.cs in the git and know the detail usage**

**Finally, if you have any other questions, please contact us on 7x24 hours.**

**We will provide FREE Technical supports:**

**Service QQ : 4006852216** 

**Email : support@mob.com**
