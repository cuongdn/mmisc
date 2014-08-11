using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common.DI;
using DevExpress.XtraGrid.Columns;
using Repository.Pattern.UnitOfWork;
using DataAccess.Model;

namespace WinApp
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();

            using (var uow = Program.Container.GetInstance<IUnitOfWorkAsync>())
            {
                var repo = uow.Repository<Category>();
                //repCategory.Properties.DataSource = repo.Queryable().ToList();
                bsCategory.DataSource = repo.Queryable().ToList();
            }

            using (var uow = Program.Container.GetInstance<IUnitOfWorkAsync>())
            {
                var repo = uow.Repository<Product>();
                gcCategory.DataSource = new BindingList<Product>(repo.Query().Include(x => x.Category).Select().ToList());
            }
            gvCategory.FocusedRowHandle = 10;
            //var keyValue = repCategory.Properties.GetKeyValue(0);
            //repCategory.EditValue = keyValue;
        }

        private void repCategory_EditValueChanged(object sender, EventArgs e)
        {
            //var cat = repCategory.EditValue;
            //if (cat != null)
            //{
            //    gvCategory.ActiveFilter.Clear();
            //    gvCategory.ActiveFilter.Add(colCategoryId, new ColumnFilterInfo(colCategoryId, cat));
            //}
        }

        private void gvCategory_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column == colCategory)
            {
            }
        }

        private void gvCategory_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            
        }

        private void gvCategory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            MessageBox.Show(e.FocusedRowHandle.ToString());
        }

        private void gvCategory_StartGrouping(object sender, EventArgs e)
        {
        }
    }
}
