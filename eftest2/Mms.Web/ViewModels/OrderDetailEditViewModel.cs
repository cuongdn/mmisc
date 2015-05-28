using Core.Web.ViewModel;
using Mms.Business.Edit;

namespace Mms.Web.ViewModels
{
    public class OrderDetailEditViewModel : ViewModelEdit<OrderDetailEdit>
    {
        public OrderDetailEditViewModel()
        {
            ModelObject = OrderDetailEdit.New();
        }
        
        public OrderDetailEditViewModel(int id)
        {
            ModelObject = OrderDetailEdit.Get(id);
        }
    }
}
