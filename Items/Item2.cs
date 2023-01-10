using KitchenData;
using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenDemoMod.Items
{
    public class Item2: CustomItemGroup
    {
        public override string UniqueNameID => "DemoItemGroup";

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new ItemGroup.ItemSet()
            {
                Min = 2,
                Max = 2,
                Items = new List<Item>
                {
                    Mod.Apple,
                    Mod.Item1
                }
            }
        };
    }
}
