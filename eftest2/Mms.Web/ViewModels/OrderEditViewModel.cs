using Core.Web.ViewModel;
using Mms.Business.Edit;

namespace Mms.Web.ViewModels
{
    public class OrderEditViewModel : ViewModelEdit<OrderEdit>
    {
        public OrderEditViewModel()
        {
            ModelObject = OrderEdit.New();
        }
        
        public OrderEditViewModel(int id)
        {
            ModelObject = OrderEdit.Get(id);
        }
    }
}
