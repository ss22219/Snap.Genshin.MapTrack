using DGP.Genshin.Core.Plugins;
using System;

[assembly: SnapGenshinPlugin]
namespace Snap.Genshin.MapTrack
{
    /// <summary>
    /// 插件实例实现
    /// </summary>
    [ImportPage(typeof(MapPage), "原神地图跟踪", "\uE37a")]
    public class MapTrackPlugin: IPlugin
    { 
        public string Name
        {
            get => "原神地图跟踪";
        }

        public string Description
        {
            get => "网页空莹酒馆地图与游戏玩家位置同步跟踪";
        }

        public string Author
        {
            get => "ss22219";
        }

        public Version Version
        {
            get => new("0.0.0.1");
        }

        public bool IsEnabled
        {
            get => true;
        }
    }
}