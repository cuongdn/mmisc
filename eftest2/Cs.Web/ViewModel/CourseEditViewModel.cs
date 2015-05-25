﻿using Core.Web.ViewModel;
using Cs.Business.Edit;
using Cs.Web.Lookup;

namespace Cs.Web.ViewModel
{
    public class CourseEditViewModel : ViewModelEdit<CourseEdit>
    {
        public DepartmentLookupHandler Departments
        {
            get { return GetObject(DepartmentLookupHandler.Get); }
        }

        public CourseEditViewModel()
        {
            // parameter ctor will call default ctor => new add query in this 
        }

        public CourseEditViewModel(int id)
        {
            ModelObject = CourseEdit.Get(id);
        }
    }
}