using System;
using System.Collections.Generic;
using System.Reflection;

namespace FlatSquares.MonoGame
{
	public class AppDomain
	{
		static IEnumerable<Assembly> _assemblies;

		internal static IEnumerable<Assembly> Assemblies => _assemblies;

		static AppDomain()
		{
			//Ugly code but there is no other way to retreive assemblies meta information
			var appDomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
			var getAssembliesMethod = appDomain.GetType().GetRuntimeMethod("GetAssemblies", new Type[] { });
			_assemblies = getAssembliesMethod.Invoke(appDomain, new object[] { }) as Assembly[];
		}
	}
}
