﻿using System;
using System.Collections;


namespace com.mob.mobpush{
	public abstract class MobPushImpl {

		/// <summary>
		/// Init the PushSDK.
		/// </summary>
		public abstract void initPushSDK (string appKey, string appScrect);


		/// <summary>
		/// Add push receiver
		/// </summary>
		public abstract void addPushReceiver ();

		/// <summary>
		/// set APNs 环境
		/// </summary>
		public abstract void setAPNsForProduction (bool isPro);
		

		/// <summary>
		/// getRegistrationId.
		/// </summary>
		public abstract void getRegistrationId ();

		/// <summary>
		/// add Tags.
		/// </summary>
		public abstract void addTags (string tags);
		
		/// <summary>
		/// get Tags.
		/// </summary>
		public abstract void getTags ();

		/// <summary>
		/// delete tags.
		/// </summary>
		public abstract void deleteTags (string tags);

		/// <summary>
		/// Determine weather the APP-Client of platform is valid.
		/// </summary>
		public abstract void cleanAllTags ();
		
		/// <summary>
		/// add Alias.
		/// </summary>
		public abstract void addAlias (string alias);
		
		/// <summary>
		/// get Alias.
		/// </summary>
		public abstract void getAlias ();

		/// <summary>
		/// Determine weather the APP-Client of platform is valid.
		/// </summary>
		public abstract void cleanAllAlias();

		/// <summary>
		/// LocalNotification.
		/// </summary>
		public abstract void setMobPushLocalNotification (LocalNotifyStyle style);

		/// <summary>
		/// CustomNotification.
		/// </summary>
		public abstract void setCustomNotification (CustomNotifyStyle style);

		/// <summary>
		/// demo Req.
		/// type notify:1  AppNotify:2  Delayed:3
		/// iosProduction (ios only)
		/// </summary>
		public abstract void req (int type,  String content, int space, String extras);

	}
}
