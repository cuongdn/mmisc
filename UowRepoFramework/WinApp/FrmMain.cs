using System;
using System.Linq;
using DevExpress.XtraGrid.Columns;
using Repository.Pattern.UnitOfWork;
using StructureMap;
using DataAccess.Model;

namespace WinApp
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();

            using (var uow = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                var repo = uow.Repository<Category>();
                repCategory.Properties.DataSource = repo.Queryable().ToList();
            }

            using (var uow = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                var repo = uow.Repository<Product>();
                gcCategory.DataSource = repo.Query().Include(x => x.Category).Select().ToList();
            }

            var keyValue = repCategory.Properties.GetKeyValue(0);
            repCategory.EditValue = keyValue;
        }

        private void repCategory_EditValueChanged(object sender, EventArgs e)
        {
            var cat = repCategory.EditValue;
            if (cat != null)
            {
                gvCategory.ActiveFilter.Clear();
                gvCategory.ActiveFilter.Add(colCategoryId, new ColumnFilterInfo(colCategoryId, cat));
            }
        }
    }
}
