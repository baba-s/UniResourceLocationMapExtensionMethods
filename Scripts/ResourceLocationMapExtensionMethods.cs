using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Kogane
{
	/// <summary>
	/// ResourceLocationMap 型の拡張メソッドを管理するクラス
	/// </summary>
	public static class ResourceLocationMapExt
	{
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// すべての IAssetBundleResource を返します
		/// </summary>
		public static IEnumerable<IResourceLocation> GetAllAssetBundleLocation
		(
			this ResourceLocationMap self
		)
		{
			var resourceType = typeof( IAssetBundleResource );

			return self.Locations.Values
					.SelectMany( x => x )
					.Where( x => x.ResourceType == resourceType )
					.GroupBy( x => x.PrimaryKey )
					.Select( x => x.FirstOrDefault() )
				;
		}
	}
}