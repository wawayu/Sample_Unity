using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace anysdk {
	public enum PushActionResultCode
	{
		kPushReceiveMessage = 0,/**value is callback of Receiving Message . */
		
		
	} ;
	public class AnySDKPush
	{
		private static AnySDKPush _instance;
		
		public static AnySDKPush getInstance() {
			if( null == _instance ) {
				_instance = new AnySDKPush();
			}
			return _instance;
		}

		/**
    	 *@brief start/register  Push services
   	 	 *@return void
    	 */

		public  void startPush()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKPush_nativeStartPush ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*@brief close Push services
    	 *@return void
    	 */

		public  void closePush()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKPush_nativeClosePush ();
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*@brief set alias
    	 *@param tags
     	*@return void
     	*/

		public  void setAlias(string alia)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKPush_nativeSetAlias (alia);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*@brief del alias
    	 *@param tags
     	*@return void
     	*/

		public  void delAlias(string alia)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKPush_nativeDelAlias (alia);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief set tag
    	 *@param tags
    	 *@return void
    	 */

		public  void setTags (List<string> tags)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			string value = AnySDKUtil.ListToString(tags);
			AnySDKPush_nativeSetTags (value);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief del tag
    	 *@param tags
    	 *@return void
    	 */

		public  void delTags (List<string> tags)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			string value = AnySDKUtil.ListToString(tags);
			AnySDKPush_nativeDelTags (value);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * set debugmode for plugin
		 * 
		 */

		public  void setDebugMode(bool bDebug)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			AnySDKPush_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 @brief set pListener The callback object for push result
    	 @param the MonoBehaviour object
    	 @param the callback of function
    	 */

		public  void setListener(MonoBehaviour gameObject,string functionName)
		{
#if UNITY_ANDROID 
			AnySDKUtil.registerActionCallback (AnySDKType.Push, gameObject, functionName);
#elif UNITY_IOS
			string gameObjectName = gameObject.gameObject.name;
			AnySDKPush_nativeSetListener(gameObjectName,functionName);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKPush_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			StringBuilder version = new StringBuilder();
			version.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKPush_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			AnySDKPush_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null) 
			{
				AnySDKPush_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				AnySDKPush_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return void
    	 */
		public  int callIntFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKPush_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return void
    	 */
		public  int  callIntFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null)
			{
				return AnySDKPush_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKPush_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKPush_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null)
			{
				return AnySDKPush_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKPush_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			return AnySDKPush_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return bool
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			if (param == null)
			{
				return AnySDKPush_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return AnySDKPush_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param AnySDKParam param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, AnySDKParam param)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			List<AnySDKParam> list = new List<AnySDKParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			AnySDKPush_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<AnySDKParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<AnySDKParam> param = null)
		{
#if UNITY_ANDROID ||  UNITY_IOS 
			StringBuilder value = new StringBuilder();
			value.Capacity = AnySDKUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				AnySDKPush_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				AnySDKPush_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM,CallingConvention=CallingConvention.Cdecl)]
		private static extern void AnySDKPush_RegisterExternalCallDelegate(IntPtr functionPointer);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeSetListener(string gameName, string functionName);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeStartPush();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeClosePush();
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeSetAlias(string alia);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeDelAlias(string alia);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeSetTags(string tags);

		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeDelTags(string tags);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeSetDebugMode(bool bDebug);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeCallFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern int AnySDKPush_nativeCallIntFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern float AnySDKPush_nativeCallFloatFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern bool AnySDKPush_nativeCallBoolFuncWithParam(string functionName, AnySDKParam[] param,int count);
		
		[DllImport(AnySDKUtil.ANYSDK_PLATFORM)]
		private static extern void AnySDKPush_nativeCallStringFuncWithParam(string functionName, AnySDKParam[] param,int count,StringBuilder value);
	}
	
}


