using Hololens.Obeya.Core.Enums;

namespace Hololens.Obeya.Core.Models
{
    public class MenuItemModel
    {
        public char Icon { get; set; }

        public string Title { get; set; }

        public ScreenTypes ScreenType { get; internal set; }
    }
}
