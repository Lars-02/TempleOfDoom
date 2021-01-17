using System;
using CODE_GameLib;
using CODE_GameLib.Entity;
using CODE_TempleOfDoom_DownloadableContent;
using Newtonsoft.Json.Linq;

namespace CODE_PersistenceLib.Factories
{
    public static class EnemyFactory
    {
        public static IEnemy CreateEnemy(JToken itemJToken, IRoom room, int lives = 3)
        {
            var x = itemJToken["x"].Value<int>();
            var y = itemJToken["y"].Value<int>();

            Enemy enemy;

            switch (itemJToken["type"].Value<string>())
            {
                case "horizontal":
                    var minX = itemJToken["minX"].Value<int>();
                    var maxX = itemJToken["maxX"].Value<int>();
                    enemy = new HorizontallyMovingEnemy(lives, x, y, minX, maxX);
                    break;
                case "vertical":
                    var minY = itemJToken["minY"].Value<int>();
                    var maxY = itemJToken["maxY"].Value<int>();
                    enemy = new VerticallyMovingEnemy(lives, x, y, minY, maxY);
                    break;
                default:
                    throw new ArgumentException($"invalid enemy type: {itemJToken["type"].Value<string>()}");
            }

            return new EnemyAdapter(enemy, new EnemyLocationAdapter(enemy, room));
        }
    }
}