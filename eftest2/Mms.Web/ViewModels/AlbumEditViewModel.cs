using Core.Web.ViewModel;
using Mms.Business.Edit;

namespace Mms.Web.ViewModels
{
    public class AlbumEditViewModel : ViewModelEdit<AlbumEdit>
    {
        public AlbumEditViewModel()
        {
            ModelObject = AlbumEdit.New();
        }
        
        public AlbumEditViewModel(int id)
        {
            ModelObject = AlbumEdit.Get(id);
        }
    }
}
