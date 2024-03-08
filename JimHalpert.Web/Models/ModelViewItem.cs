namespace JimHalpert.Web.Models
{
    public class ModelViewItem<T> : ModelBase where T :  new()
    {
        public ModelViewItem()
        {
            Item = new T();
        }
        public T Item { get; set; }
    }
}