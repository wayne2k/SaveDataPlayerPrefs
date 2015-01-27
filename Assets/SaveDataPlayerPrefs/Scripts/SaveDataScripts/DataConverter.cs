using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

namespace RollRoti.SaveDataPlayerPrefs
{
	public static class DataConverter 
	{
		public static string GetSerializedString (this System.Object data)
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			
			bf.Serialize (ms, data);
			
			string serializedData = Convert.ToBase64String (ms.GetBuffer ());
			
			ms.Close ();
			
			return serializedData;
		}

		public static string GetSerializedString (this UnityEngine.Object data)
		{
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			
			bf.Serialize (ms, data);
			
			string serializedData = Convert.ToBase64String (ms.GetBuffer ());
			
			ms.Close ();
			
			return serializedData;
		}

		public static System.Object GetSystemObject (this string serializeSstring)
		{
			System.Object _object;
			
			if (!string.IsNullOrEmpty (serializeSstring)) 
			{
				BinaryFormatter bf = new BinaryFormatter ();
				MemoryStream ms = new MemoryStream (Convert.FromBase64String (serializeSstring));
				
				try {
					_object = (System.Object) bf.Deserialize (ms);
				}
				catch {
					_object = null;
					Debug.LogError ("Couldnt create Object from String");
				}
				
				ms.Close ();
				
				return _object;
			}
			
			return null;
		}	

		public static UnityEngine.Object GetUnityEngineObject (this string serializeSstring)
		{
			UnityEngine.Object _object;
			
			if (!string.IsNullOrEmpty (serializeSstring)) 
			{
				BinaryFormatter bf = new BinaryFormatter ();
				MemoryStream ms = new MemoryStream (Convert.FromBase64String (serializeSstring));
				
				try {
					_object = (UnityEngine.Object) bf.Deserialize (ms);
				}
				catch {
					_object = null;
					Debug.LogError ("Couldnt create Object from String");
				}
				
				ms.Close ();
				
				return _object;
			}
			
			return null;
		}	

		public static byte[] ToByteArray (this string serializedString)
		{
			return System.Text.ASCIIEncoding.Default.GetBytes (serializedString);
		}
		
		public static string FromByteArray (this byte[] bytes)
		{
			return System.Text.ASCIIEncoding.Default.GetString (bytes);
		}
	}
}