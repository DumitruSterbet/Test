using Test.Models.Interfaces;
using Test.SserializationModels.Holiday;

namespace Test.Models.HolydayModels
{
    public class Name : IEntity
    {
        public int Id { set; get; }
        public string Lang { set; get; }
        public string Text { set; get; }
        public Name( NameD obj)
        {
            this.Lang = obj.Lang;
            this.Text = obj.Text;

        }

        public Name()
        {
        }
    }
}
