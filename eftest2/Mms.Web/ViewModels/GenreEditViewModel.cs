using Core.Web.ViewModel;
using Mms.Business.Edit;

namespace Mms.Web.ViewModels
{
    public class GenreEditViewModel : ViewModelEdit<GenreEdit>
    {
        public GenreEditViewModel()
        {
            ModelObject = GenreEdit.New();
        }
        
        public GenreEditViewModel(int id)
        {
            ModelObject = GenreEdit.Get(id);
        }
    }
}
