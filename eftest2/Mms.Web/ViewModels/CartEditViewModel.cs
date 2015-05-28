using Core.Web.ViewModel;
using Mms.Business.Edit;

namespace Mms.Web.ViewModels
{
    public class CartEditViewModel : ViewModelEdit<CartEdit>
    {
        public CartEditViewModel()
        {
            ModelObject = CartEdit.New();
        }
        
        public CartEditViewModel(int id)
        {
            ModelObject = CartEdit.Get(id);
        }
    }
}
