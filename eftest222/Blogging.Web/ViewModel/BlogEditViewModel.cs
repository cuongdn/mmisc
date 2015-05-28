using Blogging.Business.Edit;
using Blogging.Web.Lookup;
using Core.Web.ViewModel;

namespace Blogging.Web.ViewModel
{
    public class BlogEditViewModel : ViewModelBase<BlogEdit>
    {
        public CategoryLookupHandler Categories
        {
            get
            {
                return GetObject(CategoryLookupHandler.Get);
            }
        }

        public BlogEditViewModel()
        {
            ModelObject = BlogEdit.New();
        }

        public BlogEditViewModel(int id)
        {
            ModelObject = BlogEdit.Get(id);
        }
    }
}
