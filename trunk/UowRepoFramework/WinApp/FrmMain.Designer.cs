namespace WinApp
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lcWrapper = new DevExpress.XtraLayout.LayoutControl();
            this.gcCategory = new DevExpress.XtraGrid.GridControl();
            this.bsProduct = new System.Windows.Forms.BindingSource(this.components);
            this.gvCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCategoryLk = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModelNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCategory = new DevExpress.XtraEditors.GridLookUpEdit();
            this.bsCategory = new System.Windows.Forms.BindingSource(this.components);
            this.rgvCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcgList = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colModelName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lcWrapper)).BeginInit();
            this.lcWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCategoryLk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcWrapper
            // 
            this.lcWrapper.Controls.Add(this.gcCategory);
            this.lcWrapper.Controls.Add(this.repCategory);
            this.lcWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcWrapper.Location = new System.Drawing.Point(0, 0);
            this.lcWrapper.Name = "lcWrapper";
            this.lcWrapper.Root = this.lcgList;
            this.lcWrapper.Size = new System.Drawing.Size(632, 278);
            this.lcWrapper.TabIndex = 0;
            this.lcWrapper.Text = "layoutControl1";
            // 
            // gcCategory
            // 
            this.gcCategory.DataSource = this.bsProduct;
            this.gcCategory.Location = new System.Drawing.Point(2, 26);
            this.gcCategory.MainView = this.gvCategory;
            this.gcCategory.Name = "gcCategory";
            this.gcCategory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCategoryLk});
            this.gcCategory.Size = new System.Drawing.Size(628, 250);
            this.gcCategory.TabIndex = 5;
            this.gcCategory.UseEmbeddedNavigator = true;
            this.gcCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCategory});
            // 
            // bsProduct
            // 
            this.bsProduct.DataSource = typeof(DataAccess.Model.Product);
            // 
            // gvCategory
            // 
            this.gvCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategoryId,
            this.colCategory,
            this.colProductId,
            this.colModelNumber,
            this.colModelName});
            this.gvCategory.GridControl = this.gcCategory;
            this.gvCategory.GroupCount = 1;
            this.gvCategory.Name = "gvCategory";
            this.gvCategory.OptionsNavigation.AutoFocusNewRow = true;
            this.gvCategory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCategoryId, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvCategory.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvCategory_CustomRowCellEdit);
            this.gvCategory.StartGrouping += new System.EventHandler(this.gvCategory_StartGrouping);
            this.gvCategory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCategory_FocusedRowChanged);
            this.gvCategory.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvCategory_RowUpdated);
            // 
            // colCategory
            // 
            this.colCategory.ColumnEdit = this.repCategoryLk;
            this.colCategory.FieldName = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 0;
            // 
            // repCategoryLk
            // 
            this.repCategoryLk.AutoHeight = false;
            this.repCategoryLk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCategoryLk.DataSource = this.bsCategory;
            this.repCategoryLk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repCategoryLk.DisplayMember = "CategoryName";
            this.repCategoryLk.Name = "repCategoryLk";
            this.repCategoryLk.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colProductId
            // 
            this.colProductId.FieldName = "ProductId";
            this.colProductId.Name = "colProductId";
            // 
            // colModelNumber
            // 
            this.colModelNumber.FieldName = "ModelNumber";
            this.colModelNumber.Name = "colModelNumber";
            this.colModelNumber.Visible = true;
            this.colModelNumber.VisibleIndex = 1;
            // 
            // repCategory
            // 
            this.repCategory.Location = new System.Drawing.Point(54, 2);
            this.repCategory.Name = "repCategory";
            this.repCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCategory.Properties.DataSource = this.bsCategory;
            this.repCategory.Properties.DisplayMember = "CategoryName";
            this.repCategory.Properties.PopupFormSize = new System.Drawing.Size(0, 100);
            this.repCategory.Properties.ValueMember = "CategoryId";
            this.repCategory.Properties.View = this.rgvCategory;
            this.repCategory.Size = new System.Drawing.Size(576, 20);
            this.repCategory.StyleController = this.lcWrapper;
            this.repCategory.TabIndex = 4;
            this.repCategory.EditValueChanged += new System.EventHandler(this.repCategory_EditValueChanged);
            // 
            // bsCategory
            // 
            this.bsCategory.DataSource = typeof(DataAccess.Model.Category);
            // 
            // rgvCategory
            // 
            this.rgvCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCategoryName});
            this.rgvCategory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.rgvCategory.Name = "rgvCategory";
            this.rgvCategory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.rgvCategory.OptionsView.ShowGroupPanel = false;
            // 
            // colCategoryName
            // 
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 0;
            // 
            // lcgList
            // 
            this.lcgList.CustomizationFormText = "lcgList";
            this.lcgList.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgList.GroupBordersVisible = false;
            this.lcgList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgList.Location = new System.Drawing.Point(0, 0);
            this.lcgList.Name = "lcgList";
            this.lcgList.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgList.Size = new System.Drawing.Size(632, 278);
            this.lcgList.Text = "lcgList";
            this.lcgList.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.repCategory;
            this.layoutControlItem1.CustomizationFormText = "Category:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(632, 24);
            this.layoutControlItem1.Text = "Category:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcCategory;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(632, 254);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // colModelName
            // 
            this.colModelName.FieldName = "ModelName";
            this.colModelName.Name = "colModelName";
            this.colModelName.Visible = true;
            this.colModelName.VisibleIndex = 2;
            // 
            // colCategoryId
            // 
            this.colCategoryId.FieldName = "CategoryId";
            this.colCategoryId.Name = "colCategoryId";
            this.colCategoryId.Visible = true;
            this.colCategoryId.VisibleIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 278);
            this.Controls.Add(this.lcWrapper);
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lcWrapper)).EndInit();
            this.lcWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCategoryLk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcWrapper;
        private DevExpress.XtraLayout.LayoutControlGroup lcgList;
        private DevExpress.XtraGrid.GridControl gcCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCategory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource bsProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colProductId;
        private DevExpress.XtraGrid.Columns.GridColumn colModelNumber;
        private System.Windows.Forms.BindingSource bsCategory;
        private DevExpress.XtraEditors.GridLookUpEdit repCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView rgvCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repCategoryLk;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colModelName;

    }
}

