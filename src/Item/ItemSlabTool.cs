using System.Text;
using Vintagestory.API.Common;
using Vintagestory.API.Config;

namespace StoneQuarry
{
    public class ItemSlabTool : Item
    {
        public string GetToolType()
        {
            if (Attributes.KeyExists("rockpolishedrate")) return "rockpolished";
            if (Attributes.KeyExists("rockrate")) return "rock";
            if (Attributes.KeyExists("stonerate")) return "stone";
            if (Attributes.KeyExists("stonebrickrate")) return "stonebrick";
            return "";
        }

        public override void GetHeldItemInfo(ItemSlot inSlot, StringBuilder dsc, IWorldAccessor world, bool withDebugInfo)
        {
            base.GetHeldItemInfo(inSlot, dsc, world, withDebugInfo);

            string type = GetToolType();
            if (type != "")
            {
                var result = Lang.Get(Code.Domain + ":info-slabtool-type-" + type);
                dsc.AppendLine(Lang.Get(Code.Domain + ":info-slabtool-heldinfo(result={0})", result));
            }
        }
    }
}