using Core.Web.ViewModel;
using Mms.Business.Edit;

namespace Mms.Web.ViewModels
{
    public class ArtistEditViewModel : ViewModelEdit<ArtistEdit>
    {
        public ArtistEditViewModel()
        {
            ModelObject = ArtistEdit.New();
        }
        
        public ArtistEditViewModel(int id)
        {
            ModelObject = ArtistEdit.Get(id);
        }
    }
}
