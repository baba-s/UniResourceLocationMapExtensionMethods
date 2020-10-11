# UniResourceLocationMapExtensionMethods

Addressable の ResourceLocationMap 型の拡張メソッド

## 使用例

```cs
using Kogane;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;

public class Example : MonoBehaviour
{
    private void Start()
    {
        // 以下のパッケージと組み合わせることで
        // Addressable で管理しているすべてのアセットバンドルの情報を JSON で取得
        // https://github.com/baba-s/UniJsonAssetBundleResourceData
        var list = Addressables.ResourceLocators
            .OfType<ResourceLocationMap>()
            .SelectMany( x => x.GetAllAssetBundleLocation() )
            .Select( x => new JsonAssetBundleResourceData( x ) )
            .OrderBy( x => !x.IsCached ) // キャッシュされているかどうかで並べ替え
            .ThenBy( x => x.PrimaryKey ) // キーによって並べ替え
            .ToArray()
            ;

        foreach ( var x in list )
        {
            Debug.Log( x.ToPrettyJson() );
        }
    }
}
```
