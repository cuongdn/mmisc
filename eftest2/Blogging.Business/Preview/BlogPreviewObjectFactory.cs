using Blogging.DbModel.Dto;
using Core.Business.ObjectFactories;

namespace Blogging.Business.Preview
{
    public class BlogPreviewObjectFactory : ObjectFactory<BlogPreview, BlogDto>
    {
        public override void Fetch()
        {
            base.Fetch();
        }
    }
}
